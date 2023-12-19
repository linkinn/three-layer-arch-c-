using System;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ThreeLayerArch.API.ViewModels;
using ThreeLayerArch.Business.Interfaces;
using ThreeLayerArch.Business.Models;

namespace ThreeLayerArch.API.Controllers
{
	[Route("api/products")]
	public class ProductController : MainController
	{
		private readonly IProductRepository _productRepository;
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductController(IProductRepository productRepository,
            IProductService productService, IMapper mapper, INotifier notifier
			) : base(notifier)
		{
			_productRepository = productRepository;
			_productService = productService;
			_mapper = mapper;
        }	

		[HttpGet]
		public async Task<IEnumerable<ProductViewModel>> GetAll()
		{
            return _mapper.Map<IEnumerable<ProductViewModel>>(await _productRepository.GetProductsSuppliers());
		}

		[HttpGet("{id:guid}")]
		public async Task<ActionResult<ProductViewModel>> GetById(Guid id)
		{
			var productViewModel = await GetProduct(id);

			if (productViewModel == null) return NotFound();

			return productViewModel;
		}

		[HttpPost]
		public async Task<ActionResult<ProductViewModel>> Add(ProductViewModel productViewModel)
		{
			if (!ModelState.IsValid) return CustomResponse(ModelState);

			await _productService.Add(_mapper.Map<Product>(productViewModel));

			return CustomResponse(HttpStatusCode.Created, productViewModel);
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> Update(Guid id, ProductViewModel productViewModel)
		{
			if (id != productViewModel.Id)
			{
				NoficationError("The ids entered are not the same!");
				return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

			var productUpdate = await GetProduct(id);

			productUpdate.Name = productViewModel.Name;
            productUpdate.Description = productViewModel.Description;
            productUpdate.Price = productViewModel.Price;
            productUpdate.Active = productViewModel.Active;

			await _productService.Update(_mapper.Map<Product>(productUpdate));

			return CustomResponse(HttpStatusCode.NoContent);
        }

		[HttpDelete("{id:guid}")]
		public async Task<ActionResult<ProductViewModel>> Delete(Guid id)
		{
			var produtor = await GetProduct(id);

			if (produtor == null) return NotFound();

			await _productService.Delete(id);

			return CustomResponse(HttpStatusCode.NoContent);
		}

		private async Task<ProductViewModel> GetProduct(Guid id)
		{
			return _mapper.Map<ProductViewModel>(await _productRepository.GetProductsSupplier(id));
		}
	}
}

