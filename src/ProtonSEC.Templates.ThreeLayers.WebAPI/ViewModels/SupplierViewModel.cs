using System.ComponentModel.DataAnnotations;
using ProtonSEC.Templates.ThreeLayers.Business.Models;

namespace ProtonSEC.Templates.ThreeLayers.WebAPI.ViewModels;

public class SupplierViewModel
{
	public Guid Id { get; set; }

	[Required]
	[StringLength(100)]
	public required string Name { get; set; }

	[Required]
	[StringLength(14)]
	public required string Document { get; set; }

	public int SupplierType { get; set; }

	public bool Active { get; set; }

	public AddressViewModel? Address { get; set; }

	public IEnumerable<ProductViewModel>? Products { get; set; }

	public Supplier ToSupplierEntity()
	{
		return new Supplier()
		{
			Active = Active,
			Address = null,
			Document = Document,
			Id = Id,
			Name = Name,
			Products = [],
			SupplierType = (SupplierTypes)SupplierType
		};
	}
}
