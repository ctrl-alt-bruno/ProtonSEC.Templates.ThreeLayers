using Microsoft.EntityFrameworkCore;
using ProtonSEC.Templates.ThreeLayers.Business.Interfaces;
using ProtonSEC.Templates.ThreeLayers.Business.Models;
using ProtonSEC.Templates.ThreeLayers.Data.Context;

namespace ProtonSEC.Templates.ThreeLayers.Data.Repository;

public class SupplierRepository : Repository<Supplier>, ISupplierRepository
{
	public SupplierRepository(MyDbContext dbContext) : base(dbContext)
	{
	}

	public async Task<Supplier?> GetSupplierAndAddressAsync(Guid supplierId)
	{
		return await DbContext.Suppliers
			.AsNoTracking()
			.Include(x => x.Address)
			.FirstOrDefaultAsync(x => x.Id == supplierId);
	}

	public async Task<Supplier?> GetSupplierAndProductsAndAddressAsync(Guid supplierId)
	{
		return await DbContext.Suppliers
			.AsNoTracking()
			.Include(x => x.Products)
			.Include(x => x.Address)
			.FirstOrDefaultAsync(x => x.Id == supplierId);
	}

	public async Task<Address?> GetSupplierAddressAsync(Guid supplierId)
	{
		return await DbContext.Addresses
		  .AsNoTracking()
		  .FirstOrDefaultAsync(x => x.SupplierId == supplierId);
	}

	public async Task DeleteSupplierAddress(Address address)
	{
		DbContext.Addresses.Remove(address);
		await SaveChangesAsync();
	}
}
