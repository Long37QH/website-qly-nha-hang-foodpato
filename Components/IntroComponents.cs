using food_pato.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace food_pato.Components
{
    [ViewComponent(Name = "Intro")]
    public class IntroComponents:ViewComponent
	{
        private readonly DataContext _context;
        public IntroComponents(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofslide = (from p in _context.Intros
                               where (p.TrangThaiHD == true) && (p.TrangThaiBV == 1)
                               orderby p.IntroID descending
                               select p).Take(3).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofslide));
        }
    }
}
