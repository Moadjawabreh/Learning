using System.ComponentModel.DataAnnotations;

namespace Learning.Models
{
	public class Categ
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
	}
}