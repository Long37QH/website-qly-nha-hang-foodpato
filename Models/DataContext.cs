using food_pato.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace food_pato.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<slide> slides { get; set; }
        public DbSet<Intro> Intros { get; set; }
        public DbSet<Decorver> Decorvers { get; set; }
        public DbSet<OurMenu> OurMenu { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<View_Blog_Menu> BlogMenus { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<DatBan> DatBans { get; set; }
		public DbSet<BLComment> BLComment { get; set; }

	}
}
