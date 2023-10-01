using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace food_pato.Models
{
	[Table("OurMenu")]
	public class OurMenu
	{
		[Key]
		public long OurID { get; set; }
		public string? TieuDe { get; set; }
		public int Cap { get; set; }
		public int CapCha { get; set; }
		public int ThuTuBV { get; set; }
		public int MenuID { get; set; }
		public string? TomTatBV { get; set; }
		public string? NoiDung { get; set; }
		public string? HinhAnh { get; set; }
		public string? Link { get; set; }
		public bool? TrangThaiHD { get; set; }
		public DateTime? NgayDangBV { get; set; }
		public Decimal GiaBan { get; set; }
	}
}
