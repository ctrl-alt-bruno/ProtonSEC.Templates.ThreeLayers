using Microsoft.AspNetCore.Mvc;
using ProtonSEC.Templates.ThreeLayers.WebAPI.ViewModels;

namespace ProtonSEC.Templates.ThreeLayers.WebAPI.Controllers
{
	[Route("api/suppliers")]
	public class SuppliersController : MyControllerBase
	{
		public SuppliersController()
		{

		}

		[HttpGet]
		public async Task<IEnumerable<SupplierViewModel>> GetAll()
		{
			throw new NotImplementedException();
		}

		[HttpGet("{id:guid}")]
		public async Task<IEnumerable<SupplierViewModel>> GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		[HttpPost]
		public async Task<IEnumerable<SupplierViewModel>> Add(SupplierViewModel supplier)
		{
			throw new NotImplementedException();
		}

		[HttpPut]
		public async Task<ActionResult<SupplierViewModel>> Update(Guid id, SupplierViewModel supplier)
		{
			throw new NotImplementedException();
		}

		[HttpDelete("{id:guid}")]
		public async Task<ActionResult<SupplierViewModel>> Delete(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
