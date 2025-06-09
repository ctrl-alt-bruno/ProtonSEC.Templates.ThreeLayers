using ProtonSEC.Templates.ThreeLayers.Business.Interfaces;
using ProtonSEC.Templates.ThreeLayers.Business.Models;
using ProtonSEC.Templates.ThreeLayers.Business.Models.Validation;

namespace ProtonSEC.Templates.ThreeLayers.Business.Services;

public class ProductService(IProductRepository productRepository, INotifier notifier)
	: BaseService(notifier), IProductService
{
	public async Task AddAsync(Product product)
	{
		if (!Validate(new ProductValidation(), product))
			return;

		await productRepository.AddAsync(product);
	}

	public async Task UpdateAsync(Product product)
	{
		if (!Validate(new ProductValidation(), product))
			return;

		await productRepository.UpdateAsync(product);
	}

	public async Task DeleteAsync(Guid productId)
	{
		await productRepository.DeleteAsync(productId);
	}

	public void Dispose()
	{
		productRepository.Dispose();
	}
}
