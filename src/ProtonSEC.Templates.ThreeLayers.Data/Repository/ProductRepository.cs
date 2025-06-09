using Microsoft.EntityFrameworkCore;
using ProtonSEC.Templates.ThreeLayers.Business.Interfaces;
using ProtonSEC.Templates.ThreeLayers.Business.Models;
using ProtonSEC.Templates.ThreeLayers.Data.Context;

namespace ProtonSEC.Templates.ThreeLayers.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(MyDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsBySupplierIdAsync(Guid supplierId)
        {
            return await FindAsync(x => x.SupplierId == supplierId);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAndSuppliersAsync()
        {
            return await DbContext.Products.AsNoTracking()
                .Include(x => x.Supplier)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Product?> GetProductAndSupplierAsync(Guid id)
        {
            return await DbContext.Products.AsNoTracking()
                .Include(x => x.Supplier)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}