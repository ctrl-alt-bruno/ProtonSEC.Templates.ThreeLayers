namespace ProtonSEC.Templates.ThreeLayers.Business.Models;

public class Product : Entity
{
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public decimal Value { get; set; }
	public DateTime CreationDate { get; set; }
	public bool Active { get; set; }
}
