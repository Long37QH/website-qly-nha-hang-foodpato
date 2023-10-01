using food_pato.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace food_pato.Components
{
    [ViewComponent(Name = "Blog")]
    public class BlogComponent : ViewComponent
    {
        private readonly DataContext _context;
        public BlogComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofBlog = (from p in _context.Blogs
                              where (p.TrangThaiHD == true) && (p.TrangThaiBV == 1)
                              orderby p.BlogID descending
                              select p).Take(3).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofBlog));
        }
    }
}
