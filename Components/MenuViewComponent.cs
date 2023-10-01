using Microsoft.AspNetCore.Mvc;
using food_pato.Models;
namespace food_pato.Components
{
    [ViewComponent(Name = "MenuView")]
    public class MenuViewComponent:ViewComponent
    {
        private DataContext _context;
        public MenuViewComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ListofMenu = (from m in _context.Menus
                              where (m.TrangThai == true) && (m.ViTri == 1)
                              select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", ListofMenu));
        }
    }
}
