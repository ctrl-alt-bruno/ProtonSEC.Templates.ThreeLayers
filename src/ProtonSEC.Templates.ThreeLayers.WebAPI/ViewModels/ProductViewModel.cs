using System.ComponentModel.DataAnnotations;
using ProtonSEC.Templates.ThreeLayers.Business.Models;

namespace ProtonSEC.Templates.ThreeLayers.WebAPI.ViewModels;

public class ProductViewModel
{
	public Guid Id { get; set; }

	[Required]
	public Guid SupplierId { get; set; }

	[Required]
	[StringLength(200)]
	public required string Name { get; set; }

	[Required]
	[StringLength(1000)]
	public required string Description { get; set; }

	[Required]
	public decimal Value { get; set; }

	public DateTime CreationDate { get; set; }

	public bool Active { get; set; }

	public required string SupplierName { get; set; }

	public Product ToProductEntity()
	{
		return new Product()
		{
			Active = Active,
			CreationDate = CreationDate,
			Description = Description,
			Id = Id,
			Name = Name,
			SupplierId = SupplierId,
			Value = Value
		};
	}
}
