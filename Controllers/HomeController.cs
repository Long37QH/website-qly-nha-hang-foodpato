using food_pato.Models;
using food_pato.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace food_pato.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/Blog-{slug}-{id:long}.html",Name = "Blog_Details")]
        public IActionResult Blog_Details(long ? id)
        {
            Functions.GetID = (long)id;
            Functions.route = Request.Path.Value;
            if (id == null)
            {
                return NotFound();
            }
            var blog = _context.Blogs
                .FirstOrDefault(m => (m.BlogID == id) && (m.TrangThaiHD == true));
            if(blog == null)
            {
                return NotFound();
            }
            return View(blog);

        }
		[HttpPost]
		public IActionResult AddComment(int BlogID, string BL, string Name, string Email)
		{
			BLComment tm = new BLComment();
			tm.BlogID = BlogID;
			tm.Name = Name;
			tm.Email = Email;
			tm.BL = BL;
			tm.Datetime = DateTime.Now;
			string s = Functions.route;
			    _context.BLComment.Add(tm);
			    _context.SaveChanges();
			return Redirect(s);
		}
		[Route("/listblog-{slug}-{id:long}.html",Name ="List_Blog")]
        public IActionResult List_Blog(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var list = _context.BlogMenus.Where(m => (m.MenuID == id) && (m.TrangThaiHD == true)).Take(3).ToList();
            if (list == null)
            {
                return NotFound();
            }
            return View(list);
        }
        

        [Route("/decover-{slug}-{id:long}.html",Name = "Decover_Details")]
        public IActionResult Decover_Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var deco = _context.Decorvers
                .FirstOrDefault(m => (m.DicoverID == id) && (m.TrangThaiHD == true));
            if (deco == null)
            {
                return NotFound();
            }
            return View(deco);
        }
        [Route("/ourmenu-{id:long}", Name = "Ourmenu_Details")]
        public IActionResult Ourmenu_Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var deco = _context.OurMenu
                .FirstOrDefault(m => (m.OurID == id) && (m.TrangThaiHD == true));
            if (deco == null)
            {
                return NotFound();
            }
            return View(deco);
        }
		[Route("/Mon_Details-{id:long}", Name = "Mon_Details")]
		public IActionResult Mon_Details(long? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var Mon = _context.OurMenu
				.FirstOrDefault(m => (m.OurID == id) && (m.TrangThaiHD == true));
			if (Mon == null)
			{
				return NotFound();
			}
			return View(Mon);
		}
		[Route("/events-{slug}-{id:long}.html", Name = "Events_Details")]
        public IActionResult Events_Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var events = _context.Events.FirstOrDefault(m => (m.EventsID == id) && (m.TrangThaiHD == true));
            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}