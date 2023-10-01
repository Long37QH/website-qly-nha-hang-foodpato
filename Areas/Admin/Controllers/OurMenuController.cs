using food_pato.Models;
using food_pato.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace food_pato.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OurMenuController : Controller
    {
        private readonly DataContext _context;

        public OurMenuController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var OurMenu = _context.OurMenu.OrderBy(m => m.OurID).ToList();
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return View(OurMenu);
        }
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.OurMenu.Find(id);
            if (mn == null)
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
            var deleBlog = _context.OurMenu.Find(id);
            if (deleBlog == null)
            {
                return NotFound();
            }
            _context.OurMenu.Remove(deleBlog);
            _context.SaveChanges();
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
			var mkList = (from m in _context.Menus
						  select new SelectListItem()
						  {
							  Text = m.TenMenu,
							  Value = m.MenuID.ToString()
						  }).ToList();
			mkList.Insert(0, new SelectListItem()
			{
				Text = "---Select---",
				Value = String.Empty
			});
			ViewBag.mkList = mkList;

			var mnList = (from m in _context.OurMenu.Where(m=>m.Cap==1)
                          select new SelectListItem()
                          {
                              Text = m.TieuDe,
                              Value = m.OurID.ToString()
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = String.Empty
            });
            ViewBag.mnList = mnList;
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");

            return View();
        }
        [HttpPost]
        public IActionResult Create(OurMenu ourMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ourMenu);
                _context.SaveChanges();
            }
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index");

        }
        public IActionResult Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var vn = _context.OurMenu.Find(id);
            if (vn == null)
            {
                return NotFound();
            }
            var mnList = (from m in _context.OurMenu.Where(m => m.Cap == 1)
                          select new SelectListItem()
                          {
                              Text = m.TieuDe,
                              Value = m.OurID.ToString()
                          }).ToList();
            
            ViewBag.mnList = mnList;
            var mkList = (from m in _context.Menus
                          select new SelectListItem()
                          {
                              Text = m.TenMenu,
                              Value = m.MenuID.ToString()
                          }).ToList();
            mkList.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = String.Empty
            });
            ViewBag.mkList = mkList;

            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");

            return View(vn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(OurMenu vn)
        {
            if (ModelState.IsValid)
            {
                _context.OurMenu.Update(vn);
                _context.SaveChanges();
                return RedirectToAction("Index");
                if (!Functions.IsLogin()) 
                    return RedirectToAction("Index", "Login");
            }
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return View(vn);
        }
    }
}
