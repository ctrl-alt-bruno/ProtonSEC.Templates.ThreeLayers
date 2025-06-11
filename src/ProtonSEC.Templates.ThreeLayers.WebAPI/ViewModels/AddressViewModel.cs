using System.ComponentModel.DataAnnotations;
using ProtonSEC.Templates.ThreeLayers.Business.Models;

namespace ProtonSEC.Templates.ThreeLayers.WebAPI.ViewModels
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(200)]
        public required string Street { get; set; }

        [Required]
        [StringLength(50)]
        public required string Number { get; set; }

        public string? Complement { get; set; }

        [Required]
        [StringLength(10)]
        public required string PostalCode { get; set; }

        [Required]
        [StringLength(100)]
        public required string Region { get; set; }

        [Required]
        [StringLength(100)]
        public required string City { get; set; }

        [Required]
        [StringLength(10)]
        public required string State { get; set; }

        public Guid SupplierId { get; set; }

        public Address ToAddressEntity()
        {
            return new Address()
            {
                Id = Id,
                Street = Street,
                Number = Number,
                Complement = Complement,
                PostalCode = PostalCode,
                Region = Region,
                City = City,
                State = State,
                SupplierId = SupplierId,
                Supplier = new Supplier()
                {
                    Id = SupplierId
                }
            };
        }
    }
}