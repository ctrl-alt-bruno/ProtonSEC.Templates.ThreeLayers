using Microsoft.AspNetCore.Mvc;
using ProtonSEC.Templates.ThreeLayers.Business.Interfaces;
using ProtonSEC.Templates.ThreeLayers.Business.Models;
using ProtonSEC.Templates.ThreeLayers.WebAPI.ViewModels;

namespace ProtonSEC.Templates.ThreeLayers.WebAPI.Controllers
{
	[Route("api/suppliers")]
	public class SuppliersController : MyControllerBase
	{
		private readonly ISupplierRepository _supplierRepository;
		private readonly ISupplierService _supplierService;

		public SuppliersController(ISupplierRepository supplierRepository, ISupplierService supplierService, INotifier notifier) : base(notifier)
		{
			_supplierRepository = supplierRepository;
			_supplierService = supplierService;
		}

		[HttpGet]
		public async Task<IEnumerable<SupplierViewModel>> GetAll()
		{
			return (await _supplierRepository.GetAllAsync()).Select(x => new SupplierViewModel(x));
		}

		[HttpGet("{id:guid}")]
		public async Task<ActionResult<SupplierViewModel>> GetById(Guid id)
		{
			Supplier? supplier = await _supplierRepository.GetByIdAsync(id);

			if (supplier == null)
				return NotFound();

			return new SupplierViewModel(supplier);
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
