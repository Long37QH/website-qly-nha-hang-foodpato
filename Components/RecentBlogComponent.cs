using Microsoft.AspNetCore.Mvc;
using food_pato.Models;

namespace food_pato.Components
{
    [ViewComponent(Name ="RecentBlog")]

    public class RecentBlogComponent:ViewComponent

    {
        private readonly DataContext _context;
        public RecentBlogComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult>InvokeAsync()
        {
            var listfBlog =(from b in _context.Blogs
                           where (b.TrangThaiHD == true) && (b.TrangThaiBV == 1)
                           orderby b.BlogID descending
                           select b).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default",listfBlog));
        }
    }
}
