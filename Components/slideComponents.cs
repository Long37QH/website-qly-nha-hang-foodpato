using food_pato.Models;
using Microsoft.AspNetCore.Mvc;

namespace food_pato.Components
{
	[ViewComponent(Name = "slide")]
	public class slideComponents : ViewComponent
	{
        private readonly DataContext _context;
        public slideComponents(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofslide = (from p in _context.slides
                               where (p.TrangThaiHD == true) && (p.TrangThaiBV == 2)
                               orderby p.SlideID descending
                               select p).Take(3).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofslide));
        }
    }
}
