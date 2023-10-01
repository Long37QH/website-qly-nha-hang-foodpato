using Microsoft.AspNetCore.Mvc;
using food_pato.Models;
using food_pato.Utilities;

namespace food_pato.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DatBanController : Controller
    {
        private readonly DataContext _context;
        public DatBanController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var Db = _context.DatBans.OrderBy(m=>m.BanID).ToList();
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return View(Db);
        }
        public IActionResult Delete(long? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.DatBans.Find(id);
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
            var deleban = _context.DatBans.Find(id);
            if (deleban == null)
            {
                return NotFound();
            }
            _context.DatBans.Remove(deleban);
            _context.SaveChanges();
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return RedirectToAction("Index");
        }
    }
}
