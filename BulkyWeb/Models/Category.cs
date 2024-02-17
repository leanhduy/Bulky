using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models;

public class Category
{
	[Key]
	public int ID { get; set; }
	[Required]
	public string Name {  get; set; }	
	public int DisplayedOrder { get; set; }
}
