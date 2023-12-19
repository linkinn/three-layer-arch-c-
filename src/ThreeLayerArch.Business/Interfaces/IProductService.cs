using ThreeLayerArch.Business.Models;

namespace ThreeLayerArch.Business.Interfaces
{
	public interface IProductService : IDisposable
	{
        Task Add(Product product);

        Task Update(Product product);

        Task Delete(Guid id);
    }
}

