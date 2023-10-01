using Microsoft.AspNetCore.Mvc;
using food_pato.Models;

namespace food_pato.Components
{
	[ViewComponent(Name = "OurFood")]
	public class OurFoodComponent : ViewComponent
	{
		private readonly DataContext _context;
		public OurFoodComponent(DataContext context)
		{
			_context = context;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var listOurMenu = (from p in _context.OurMenu
							   where (p.TrangThaiHD == true)
							   orderby p.OurID descending
							   select p).ToList();
			return await Task.FromResult((IViewComponentResult)View("Default", listOurMenu));
		}
	}
}
