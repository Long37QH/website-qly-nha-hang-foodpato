using food_pato.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace food_pato.Controllers
{
	public class DatBanController : Controller
	{
        private readonly DataContext _context;
        public DatBanController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
		{
			return View();
		}
		public IActionResult Create()
		{
			var mnList = (from m in _context.Menus
						  select new SelectListItem()
						  {
							  Text = m.TenMenu,
							  Value = m.MenuID.ToString()
						  }).ToList();
			mnList.Insert(0, new SelectListItem()
			{
				Text = "---Select---",
				Value = String.Empty
			});
			ViewBag.mnList = mnList;
			return View();
		}
		[HttpPost]
		public IActionResult Create(DatBan db)
		{
			if (ModelState.IsValid)
			{
				_context.Add(db);
				_context.SaveChanges();
			}
			return RedirectToAction("Index");

		}
	}
}
