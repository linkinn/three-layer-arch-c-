using ThreeLayerArch.Business.Interfaces;
using ThreeLayerArch.Business.Models;
using ThreeLayerArch.Business.Models.Validations;

namespace ThreeLayerArch.Business.Services
{
    public class SupplierService : BaseService, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository,INotifier notifier) : base(notifier)
        {
            _supplierRepository = supplierRepository;
        }

        public async Task Add(Supplier supplier)
        {
            if (!ExecuteValidation(new SupplierValidation(), supplier)
                || !ExecuteValidation(new AddressValidation(), supplier.Address)) return;

            if (_supplierRepository.Search(s => s.Document == supplier.Document).Result.Any())
            {
                Notify("There is already a supplier with this document informed!");

                return;
            }

            await _supplierRepository.Add(supplier);
        }

        public async Task Update(Supplier supplier)
        {
            if (!ExecuteValidation(new SupplierValidation(), supplier)) return;

            if (_supplierRepository.Search(s => s.Document == supplier.Document && s.Id != supplier.Id).Result.Any())
            {
                Notify("There is already a supplier with this document informed!");

                return;
            }

            await _supplierRepository.Update(supplier);
        }

        public async Task Delete(Guid id)
        {
            var supplier = await _supplierRepository.GetSupplierProductsAddress(id);

            if (supplier == null)
            {
                Notify("Supplier not exist!");

                return;
            }

            if (supplier.Products.Any())
            {
                Notify("The supplier has products registered!");

                return;
            }

            var address = await _supplierRepository.GetAddressBySupplier(id);

            if (address != null)
            {
                await _supplierRepository.DeleteAddressSupplier(address);
            }

            await _supplierRepository.Delete(id);
        }

        public void Dispose()
        {
            _supplierRepository?.Dispose();
        }
    }
}

