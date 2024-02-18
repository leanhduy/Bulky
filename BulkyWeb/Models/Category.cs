using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models;

public class Category
{
	[Key]
	public int ID { get; set; }
	[Required]
	[DisplayName("Category Name")]
	public string Name {  get; set; }	
	[DisplayName("Category Order")]
	public int DisplayedOrder { get; set; }
}
