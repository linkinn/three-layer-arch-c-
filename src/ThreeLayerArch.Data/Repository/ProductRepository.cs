using System;
using Microsoft.EntityFrameworkCore;
using ThreeLayerArch.Business.Interfaces;
using ThreeLayerArch.Business.Models;
using ThreeLayerArch.Data.Context;

namespace ThreeLayerArch.Data.Repository
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		public ProductRepository(MyDBContext context) : base(context)
		{
		}

        public async Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId)
        {
            return await Search(p => p.SupplierId == supplierId);
        }

        public async Task<Product> GetProductsSupplier(Guid id)
        {
            Product? product = await Db.Product.AsNoTracking()
                            .Include(s => s.Supplier)
                            .FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsSuppliers()
        {
            return await Db.Product.AsNoTracking()
                .Include(s => s.Supplier)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }
    }
}

