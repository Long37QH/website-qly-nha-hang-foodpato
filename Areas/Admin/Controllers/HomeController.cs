using food_pato.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace food_pato.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Thêm 2 lênh sau vào các action của các controller
            // để kiểm tra trang thái đăng nhập
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            return View();
        }
        public IActionResult Logout()
        {
            Functions._UserID = 0;
            Functions._UserName = string.Empty;
            Functions._Email = string.Empty;
            Functions._Message = string.Empty;
            Functions._MessageEmail = string.Empty;
            return RedirectToAction("Index", "Home");

        }

    }
}
