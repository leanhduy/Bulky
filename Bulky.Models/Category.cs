using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models;

public class Category
{
	[Key]
	public int ID { get; set; }
	[Required]
	[MaxLength(30)]
	[DisplayName("Category Name")]
	public string Name {  get; set; }	
	[DisplayName("Category Order")]
	[Range(1, 100, ErrorMessage = "Displayed Order must be between 1-100")]
	public int DisplayedOrder { get; set; }
}
