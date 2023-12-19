using ThreeLayerArch.Business.Models;

namespace ThreeLayerArch.Business.Interfaces
{
	public interface ISupplierService
	{
        Task Add(Supplier supplier);

        Task Update(Supplier supplier);

        Task Delete(Guid id);
    }
}

