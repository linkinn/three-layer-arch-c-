using ThreeLayerArch.Business.Interfaces;
using ThreeLayerArch.Business.Models;
using ThreeLayerArch.Business.Models.Validations;

namespace ThreeLayerArch.Business.Services
{
	public class ProductService : BaseService, IProductService
	{
        private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository, INotifier notifier) : base(notifier)
		{
            _productRepository = productRepository;
        }

        public async Task Add(Product product)
        {
            if(!ExecuteValidation(new ProductValidation(), product)) return;

            await _productRepository.Add(product);
        }

        public async Task Delete(Guid id)
        {
            await _productRepository.Delete(id);
        }

        
        public async Task Update(Product product)
        {
            if (!ExecuteValidation(new ProductValidation(), product)) return;

            await _productRepository.Update(product);
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }
    }
}

