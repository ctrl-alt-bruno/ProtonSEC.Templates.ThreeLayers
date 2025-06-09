using ProtonSEC.Templates.ThreeLayers.Business.Models;

namespace ProtonSEC.Templates.ThreeLayers.Business.Interfaces;

public interface ISupplierRepository : ICommandRepository<Supplier>, IQueryRepository<Supplier>
{
	Task<Supplier?> GetSupplierAndAddressAsync(Guid supplierId);
	Task<Supplier?> GetSupplierAndProductsAndAddressAsync(Guid supplierId);
	Task<Address?> GetSupplierAddressAsync(Guid supplierId);
	Task DeleteSupplierAddress(Address address);
}
