using Demo1.APIs.Helpers.Mappers;
using Demo1.Core.Entities;
using Demo1.Core.Interfaces.Repositories;
using Demo1.Core.Interfaces;
using Demo1.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Demo1.APIs.Extensions
{
	public static class ApplicationServicesExtension
	{
		public static IServiceCollection AddAppServices(this IServiceCollection services)
		{

			services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddAutoMapper(typeof(MapperProfiles));

			return services;
		}
	}
}
