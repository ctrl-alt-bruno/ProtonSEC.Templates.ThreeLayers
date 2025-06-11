using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProtonSEC.Templates.ThreeLayers.Business.Interfaces;
using ProtonSEC.Templates.ThreeLayers.Business.Models;
using ProtonSEC.Templates.ThreeLayers.WebAPI.ViewModels;

namespace ProtonSEC.Templates.ThreeLayers.WebAPI.Controllers
{
	[Route("api/products")]
	public class ProductsController : MyControllerBase
	{
		private readonly IProductRepository _productRepository;
		private readonly IProductService _productService;

		public ProductsController(IProductRepository productRepository, IProductService productService, INotifier notifier) : base(notifier)
		{
			_productRepository = productRepository;
			_productService = productService;
		}

		[HttpGet]
		public async Task<IEnumerable<ProductViewModel>> GetAll()
		{
			return (await _productRepository.GetAllAsync()).Select(x => new ProductViewModel(x));
		}

		[HttpGet("{id:guid}")]
		public async Task<ActionResult<ProductViewModel>> GetById(Guid id)
		{
			Product? product = await _productRepository.GetByIdAsync(id);

			if (product == null)
				return NotFound();

			return new ProductViewModel(product);
		}

		[HttpPost]
		public async Task<ActionResult<ProductViewModel>> Add(ProductViewModel product)
		{
			if (!ModelState.IsValid)
				return CustomResponse(ModelState);

			await _productService.AddAsync(product.ToEntity());

			return CustomResponse(HttpStatusCode.Created, product);
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> Update(Guid id, ProductViewModel product)
		{
			if (id != product.Id)
				Notify("error");

			if (!ModelState.IsValid)
				return CustomResponse(ModelState);

			await _productService.UpdateAsync(product.ToEntity());

			return CustomResponse(HttpStatusCode.NoContent);
		}

		[HttpDelete("{id:guid}")]
		public async Task<ActionResult<ProductViewModel>> Delete(Guid id)
		{
			bool deleted = await _productService.DeleteAsync(id);

			if (!deleted)
				return NotFound();

			return CustomResponse(HttpStatusCode.NoContent);
		}
	}
}
