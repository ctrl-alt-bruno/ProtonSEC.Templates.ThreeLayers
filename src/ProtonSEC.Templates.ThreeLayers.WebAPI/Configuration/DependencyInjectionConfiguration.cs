using ProtonSEC.Templates.ThreeLayers.Business.Interfaces;
using ProtonSEC.Templates.ThreeLayers.Business.Notifications;
using ProtonSEC.Templates.ThreeLayers.Business.Services;
using ProtonSEC.Templates.ThreeLayers.Data.Context;
using ProtonSEC.Templates.ThreeLayers.Data.Repository;

namespace ProtonSEC.Templates.ThreeLayers.WebAPI.Configuration;

public static class DependencyInjectionConfiguration
{
     public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
     {
          // Data
          services.AddScoped<MyDbContext>();
          services.AddScoped<IProductRepository, ProductRepository>();
          services.AddScoped<ISupplierRepository, SupplierRepository>();
          
          // Business
          services.AddScoped<ISupplierService, SupplierService>();
          services.AddScoped<IProductService, ProductService>();
          services.AddScoped<INotifier, Notifier>();
          
          return services;
     }
}