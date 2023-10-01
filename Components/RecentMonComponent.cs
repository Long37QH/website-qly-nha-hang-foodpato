using food_pato.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace food_pato.Components
{
	[ViewComponent(Name = "RecentMon")]
	public class RecentMonComponent : ViewComponent
	{
		private readonly DataContext _context;
		public RecentMonComponent(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listOurMenu = (from p in _context.OurMenu
							   where (p.TrangThaiHD == true)
							   orderby p.OurID descending
							   select p).Take(6).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", listOurMenu));
		}
	}
}

