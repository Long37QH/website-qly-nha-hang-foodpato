using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace food_pato.Models
{
    [Table("Decorver")]
    public class Decorver
	{

        [Key]
        public long DicoverID { get; set; }
        public string? TieuDe { get; set; }
        public string? TomTatBV { get; set; }
        public string? NoiDung { get; set; }
        public string? HinhAnh { get; set; }
        public string? Link { get; set; }
        public bool? TrangThaiHD { get; set; }
        public int ThuTuBV { get; set; }
        public int MenuID { get; set; }
        public int PhanLoai { get; set; }
        public int TrangThaiBV { get; set; }
        public DateTime? NgayDangBV { get; set; }
    }
}
