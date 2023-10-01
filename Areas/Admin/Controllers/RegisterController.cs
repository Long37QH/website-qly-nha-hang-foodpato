using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using food_pato.Areas.Admin.Models;
using food_pato.Models;
using food_pato.Utilities;
namespace food_pato.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly DataContext _context;
        public RegisterController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminUser user)
        {
            if (user == null)
            {
                return NotFound();
            }
            //Kiểm tra sư tồn tại của Email trong csdl
            var check = _context.AdminUsers.Where(m => m.Email == user.Email).FirstOrDefault();
            
            if (check != null)
            {
                //Hiển thị thông báo , có thể làm cách khác 
                Functions._MessageEmail = "Duplicate Email!";
                return RedirectToAction("Index", "Register");
            }


            Functions._MessageEmail = string.Empty;
            user.Password = Functions.MD5Password(user.Password);
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index","Login");
        }
    
    }


}
