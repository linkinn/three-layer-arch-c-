using ThreeLayerArch.Business.Models;

namespace ThreeLayerArch.Business.Interfaces
{
	public interface IProductRepository : IRepository<Product>
	{
		Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId);

        Task<IEnumerable<Product>> GetProductsSuppliers();

        Task<Product> GetProductsSupplier(Guid id);
    }
}

