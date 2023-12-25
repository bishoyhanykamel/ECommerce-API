using Demo1.Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Demo1.Repository.Data.DbContexts
{
	public class CompanySeedContext
	{
		public static async Task SeedAsync(CompanyContext context, ILoggerFactory loggerFactory)
		{
			try
			{
				if (!context.ProductBrands.Any())
				{
					var brandsData = File.ReadAllText("../Demo1.Repository/Data/DataSeed/brands.json");
					var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
					foreach (var brand in brands)
						context.Set<ProductBrand>().Add(brand);
				
					await context.SaveChangesAsync();
				}

				if(!context.ProductTypes.Any())
				{
					var typesData = File.ReadAllText("../Demo1.Repository/Data/DataSeed/types.json");
					var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
					foreach(var type in types)
						context.Set<ProductType>().Add(type);
					
					await context.SaveChangesAsync();
				}
				if(!context.Products.Any())
				{
					var productsData = File.ReadAllText("../Demo1.Repository/Data/DataSeed/products.json");
					var products = JsonSerializer.Deserialize<List<Product>>(productsData);
					foreach (var product in products)
						context.Set<Product>().Add(product);
					await context.SaveChangesAsync();
				}
			}
			catch (Exception e)
			{
				var logger = loggerFactory.CreateLogger<CompanySeedContext>();
				logger.LogError(e, "Error in data seeding");
			}

		}
	}
}
