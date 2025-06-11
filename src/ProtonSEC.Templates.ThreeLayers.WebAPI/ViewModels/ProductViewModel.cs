using System.ComponentModel.DataAnnotations;
using ProtonSEC.Templates.ThreeLayers.Business.Models;

namespace ProtonSEC.Templates.ThreeLayers.WebAPI.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(2000)]
        public string? Description { get; set; }

        [Required]
        public decimal Value { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Active { get; set; }

        [Required]
        public Guid SupplierId { get; set; }

        public string SupplierName { get; set; }

        public ProductViewModel()
        {
            Name = SupplierName = string.Empty;
        }

        public ProductViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Value = product.Value;
            CreationDate = product.CreationDate;
            Active = product.Active;
            SupplierId = product.SupplierId;
            SupplierName = product.Supplier != null ? product.Supplier.Name : string.Empty;
        }

        public Product ToEntity()
        {
            return new Product()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Value = Value,
                CreationDate = CreationDate,
                Active = Active,
                SupplierId = SupplierId,
                Supplier = new Supplier()
                {
                    Id = SupplierId,
                    Name = SupplierName
                }
            };
        }
    }
}