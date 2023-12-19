using ThreeLayerArch.Business.Models;

namespace ThreeLayerArch.Business.Interfaces
{
	public interface ISupplierRepository : IRepository<Supplier>
	{
		Task<Supplier> GetSupplierAddress(Guid id);

		Task<Supplier> GetSupplierProductsAddress(Guid id);

		Task<Address> GetAddressBySupplier(Guid supplierId);

		Task DeleteAddressSupplier(Address address);

    }
}

