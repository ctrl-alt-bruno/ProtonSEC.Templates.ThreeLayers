using System.ComponentModel.DataAnnotations;
using ProtonSEC.Templates.ThreeLayers.Business.Models;

namespace ProtonSEC.Templates.ThreeLayers.WebAPI.ViewModels
{
	public class SupplierViewModel
	{
		public Guid Id { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		[Required]
		[StringLength(20)]
		public string Document { get; set; }

		public int SupplierType { get; set; }

		public bool Active { get; set; }

		public AddressViewModel? Address { get; set; }

		public IEnumerable<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();

		public SupplierViewModel()
		{
			Name = Document = String.Empty;
		}
		
		public SupplierViewModel(Supplier supplier)
		{
			Name = supplier.Name;
			Document = supplier.Document;
			SupplierType = (int)supplier.SupplierType;
			Active = supplier.Active;
			Address = null;
			Products = [];
		}

		public Supplier ToSupplierEntity()
		{
			return new Supplier()
			{
				Id = Id,
				Name = Name,
				Document = Document,
				SupplierType = (SupplierTypes)SupplierType,
				Active = Active,
				Address = null,
				Products = Products.Select(p => p.ToEntity()).ToList()
			};
		}
	}
}
