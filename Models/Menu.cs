using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace food_pato.Models
{
    [Table("Menu")]
    public class Menu
    {
        [Key]
        public int MenuID { get; set; }
        public string? TenMenu { get; set; }
        public bool ? TrangThai { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public int PhanCap { get; set; }
        public int ParentID { get; set; }
        public string? Link { get; set; }
        public int ThuTuSX { get; set; }
        public int ViTri { get; set; }
       
    }
}
