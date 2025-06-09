using ProtonSEC.Templates.ThreeLayers.Business.Interfaces;
using ProtonSEC.Templates.ThreeLayers.Business.Models;
using ProtonSEC.Templates.ThreeLayers.Business.Models.Validation;

namespace ProtonSEC.Templates.ThreeLayers.Business.Services
{
    public class SupplierService(ISupplierRepository supplierRepository, INotifier notifier)
        : BaseService(notifier), ISupplierService
    {
        public async Task AddAsync(Supplier supplier)
        {
            if (!Validate(new SupplierValidation(), supplier) || !Validate(new AddressValidation(), supplier.Address))
                return;

            if (supplierRepository.FindAsync(s => s.Document == supplier.Document).Result.Any())
            {
                Notify("The supplier already exists.");
                return;
            }

            await supplierRepository.AddAsync(supplier);
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            if (!Validate(new SupplierValidation(), supplier))
                return;

            if (supplierRepository.FindAsync(s => s.Document == supplier.Document && s.Id != supplier.Id).Result.Any())
            {
                Notify("The supplier already exists.");
                return;
            }

            await supplierRepository.UpdateAsync(supplier);
        }

        public async Task DeleteAsync(Guid supplierId)
        {
            Supplier? supplier = await supplierRepository.GetSupplierAndProductsAndAddressAsync(supplierId);

            if (supplier == null)
            {
                Notify("The supplier does not exist.");
                return;
            }

            if (supplier.Products.Any())
            {
                Notify("The supplier has products.");
                return;
            }

            Address? address = await supplierRepository.GetSupplierAddressAsync(supplierId);

            if (address != null)
            {
                await supplierRepository.DeleteSupplierAddress(address);
            }

            await supplierRepository.DeleteAsync(supplierId);
        }

        public void Dispose()
        {
            supplierRepository.Dispose();
        }
    }
}