using System;
using ThreeLayerArch.Business.Interfaces;
using ThreeLayerArch.Business.Notifications;
using ThreeLayerArch.Business.Services;
using ThreeLayerArch.Data.Context;
using ThreeLayerArch.Data.Repository;

namespace ThreeLayerArch.API.Configurations
{
	public static class DependencyInjectioinConfiguration
	{
		public static IServiceCollection ResolveDependencies(this IServiceCollection services)
		{
			//Data
			services.AddScoped<MyDBContext>();

			services.AddScoped<IProductRepository, ProductRepository>();

			services.AddScoped<ISupplierRepository, SupplierRepository>();

            //Business
            services.AddScoped<ISupplierService, SupplierService>();

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<INotifier, Notifier>();
            return services;
		}
	}
}

