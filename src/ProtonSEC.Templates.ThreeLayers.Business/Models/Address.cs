namespace ProtonSEC.Templates.ThreeLayers.Business.Models;

public class Address : Entity
{
	public string? Street { get; set; }
	public string? Number { get; set; }
	public string? Complement { get; set; }
	public string? PostalCode { get; set; }
	public string? Region { get; set; }
	public string? City { get; set; }
	public string? State { get; set; }
}
