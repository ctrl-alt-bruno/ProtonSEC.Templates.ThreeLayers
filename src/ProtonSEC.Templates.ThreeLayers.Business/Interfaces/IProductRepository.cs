using ProtonSEC.Templates.ThreeLayers.Business.Models;

namespace ProtonSEC.Templates.ThreeLayers.Business.Interfaces;

public interface IProductRepository : ICommandRepository<Product>, IQueryRepository<Product>
{
	Task<IEnumerable<Product>> GetProductsBySupplierIdAsync(Guid supplierId);
	Task<IEnumerable<Product>> GetAllProductsAndSuppliersAsync();
	Task<Product?> GetProductAndSupplierAsync(Guid id);
}
