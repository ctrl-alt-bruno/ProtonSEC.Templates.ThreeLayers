using Microsoft.AspNetCore.Mvc;
using ProtonSEC.Templates.ThreeLayers.WebAPI.ViewModels;

namespace ProtonSEC.Templates.ThreeLayers.WebAPI.Controllers
{
	[Route("api/products")]
	public class ProductsController : MyControllerBase
	{
		public ProductsController()
		{

		}

		[HttpGet]
		public async Task<IEnumerable<ProductViewModel>> GetAll()
		{
			throw new NotImplementedException();
		}

		[HttpGet("{id:guid}")]
		public async Task<ActionResult<ProductViewModel>> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		public async Task<ActionResult<ProductViewModel>> Add(ProductViewModel product)
		{
			throw new NotImplementedException();

		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> Update(Guid id, ProductViewModel product)
		{
			throw new NotImplementedException();

		}

		[HttpDelete("{id:guid")]
		public async Task<ActionResult<ProductViewModel>> Delete(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
