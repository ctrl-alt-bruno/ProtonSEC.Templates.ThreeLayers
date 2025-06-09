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
        [StringLength(100)]
        public required string Region { get; set; }

        [Required]
        [StringLength(8)]
        public required string PostalCode { get; set; }

        [Required]
        [StringLength(100)]
        public required string City { get; set; }

        [Required]
        [StringLength(50)]
        public required string State { get; set; }

        public Guid SupplierId { get; set; }

        public Address ToAddressEntity()
        {
            return new Address()
            {
                City = City,
                State = State,
                Region = Region,
                Street = Street,
                PostalCode = PostalCode,
                SupplierId = SupplierId,
                Id = Id,
                Number = Number
            };
        }
    }
}