using food_pato.Models;
using food_pato.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace food_pato.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly DataContext _context;

        public BlogController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var blogs= _context.Blogs.OrderBy(m => m.BlogID).ToList();
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return View(blogs);
        }
        public IActionResult Delete(long? id)
        {
            if(id==null|| id == 0)
            {

                return NotFound();
            }
            var mn=_context.Blogs.Find(id);
            if(mn==null)
            {
                return NotFound();
            }
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(long id)
        {
            var deleBlog=_context.Blogs.Find(id);
            if(deleBlog==null)
            {
                return NotFound();
            }
            _context.Blogs.Remove(deleBlog);
            _context.SaveChanges();
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index");
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
                Value=String.Empty
            });
            ViewBag.mnList=mnList;
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return View();    
        }
        [HttpPost]
        public IActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog);
                _context.SaveChanges();
            }
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index");

        }
        
    }
}
