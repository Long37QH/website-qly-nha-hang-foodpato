using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace food_pato.Models
{
    [Table("DatBan")]
    public class DatBan
    {
        [Key]
        public long BanID { get; set; }
        public string ? TenKH { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int SoNguoi { get; set; }
        public string? Date { get; set; }
        public string? Time { get; set; }
        public int MenuID { get; set; }

    }
}
