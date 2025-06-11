using ProtonSEC.Templates.ThreeLayers.Business.Interfaces;
using ProtonSEC.Templates.ThreeLayers.Business.Models;
using ProtonSEC.Templates.ThreeLayers.Business.Models.Validation;

namespace ProtonSEC.Templates.ThreeLayers.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, INotifier notifier) : base(notifier)
        {
            _productRepository = productRepository;
        }

        public async Task AddAsync(Product product)
        {
            if (!Validate(new ProductValidation(), product))
                return;

            await _productRepository.AddAsync(product);
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            if (!Validate(new ProductValidation(), product))
                return false;

            Product? productToUpdate = await _productRepository.GetByIdAsync(product.Id);

            if (productToUpdate == null)
                return false;
			 
            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Value = product.Value;
            productToUpdate.Active = product.Active;

            await _productRepository.UpdateAsync(product);

            return true;
        }

        public async Task<bool> DeleteAsync(Guid productId)
        {
            Product? productToDelete = await _productRepository.GetByIdAsync(productId);
            
            if (productToDelete == null)
                return false;
            
            await _productRepository.DeleteAsync(productId);
            
            return true;
        }

        public void Dispose()
        {
            _productRepository.Dispose();
        }
    }
}