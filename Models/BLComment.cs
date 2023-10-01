using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace food_pato.Models
{
	[Table("BLComment")]
	public class BLComment
	{
		[Key]
		public long IDComments { get; set; }
		public int BlogID { get; set; }
		public string? Name { get; set; }
		public string? Email { get; set; }
		public string? BL { get; set; }
		public DateTime? Datetime { get; set; }

	}
}
