using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using food_pato.Models;
using food_pato.Utilities;

namespace food_pato.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventsController : Controller
    {
        private readonly DataContext _context;
        public EventsController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var mnList = _context.Events.OrderBy(m => m.EventsID).ToList();
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return View(mnList);
        }
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Events.Find(id);
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
            var deleBlog = _context.Events.Find(id);
            if (deleBlog == null)
            {
                return NotFound();
            }
            _context.Events.Remove(deleBlog);
            _context.SaveChanges();
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
            var vn = _context.Events.Find(id);
            if (vn == null)
            {
                return NotFound();
            }
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
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");

            return View(vn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Events vn)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Update(vn);
                _context.SaveChanges();
                if (!Functions.IsLogin())
                    return RedirectToAction("Index", "Login");
                return RedirectToAction("Index");
            }
            return View(vn);
        }
    }
}
