using food_pato.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace food_pato.Components
{
    [ViewComponent(Name = "Decorver")]
    public class DecorverComponents : ViewComponent
    {
        private readonly DataContext _context;
        public DecorverComponents(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofslide = (from p in _context.Decorvers
                               where (p.TrangThaiHD == true) && (p.TrangThaiBV == 1)
                               orderby p.DicoverID descending
                               select p).Take(3).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofslide));
        }
    }
}
