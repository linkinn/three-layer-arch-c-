using System;
using Microsoft.EntityFrameworkCore;
using ThreeLayerArch.Business.Interfaces;
using ThreeLayerArch.Business.Models;
using ThreeLayerArch.Data.Context;

namespace ThreeLayerArch.Data.Repository
{
	public class SupplierRepository : Repository<Supplier>, ISupplierRepository
	{
		public SupplierRepository(MyDBContext context) : base(context)
		{
		}

        public async Task<Supplier> GetSupplierAddress(Guid id)
        {
            Supplier? supplier = await Db.Supplier.AsNoTracking()
                .Include(a => a.Address)
                .FirstOrDefaultAsync(s => s.Id == id);
            return supplier;
        }

        public async Task<Supplier> GetSupplierProductsAddress(Guid id)
        {
            Supplier? supplier = await Db.Supplier.AsNoTracking()
                .Include(a => a.Address)
                .Include(p => p.Products)
                .FirstOrDefaultAsync(s => s.Id == id);
            return supplier;
        }

        public async Task<Address> GetAddressBySupplier(Guid supplierId)
        {
            Address? address = await Db.Address.AsNoTracking()
                .FirstOrDefaultAsync(s => s.SupplierId == supplierId);
            return address;
        }

        public async Task DeleteAddressSupplier(Address address)
        {
            Db.Address.Remove(address);
            await SaveChanges();
        }
    }
}

