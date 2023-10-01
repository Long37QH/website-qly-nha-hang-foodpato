using food_pato.Models;
using food_pato.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace food_pato.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DecorverController : Controller
    {
        private readonly DataContext _context;
        public DecorverController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Decovers = _context.Decorvers.OrderBy(m => m.DicoverID).ToList();
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return View(Decovers); 

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
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Decorver decorver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(decorver);
                _context.SaveChanges();
            }
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index");

        }
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Decorvers.Find(id);
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
            var deleDecorver = _context.Decorvers.Find(id);
            if (deleDecorver == null)
            {
                return NotFound();
            }
            _context.Decorvers.Remove(deleDecorver);
            _context.SaveChanges();
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index");
        }
    }
}
