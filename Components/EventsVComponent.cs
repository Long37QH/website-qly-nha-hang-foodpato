using Microsoft.AspNetCore.Mvc;
using food_pato.Models;

namespace food_pato.Components
{
    [ViewComponent(Name = "EventsV")]
    public class EventsVComponent : ViewComponent
    {
        private DataContext _context;
        public EventsVComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofEvents = (from p in _context.Events
                                where (p.TrangThaiHD == true) && (p.TrangThaiBV == 1)
                                orderby p.EventsID descending
                                select p).Take(3).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofEvents));
        }
    }
}
