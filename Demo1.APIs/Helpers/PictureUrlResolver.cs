using AutoMapper;
using Demo1.APIs.Helpers.DTOs;
using Demo1.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace Demo1.APIs.Helpers
{
	public class PictureUrlResolver : IValueResolver<Product, ProductDto, string>
	{
		private readonly IConfiguration appConfig;

		public PictureUrlResolver(IConfiguration appConfig)
        {
			this.appConfig = appConfig;
		}
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
		{
			if (!string.IsNullOrEmpty(source.PictureUrl))
				return $"{appConfig["BaseAPIUrl"]}{source.PictureUrl}";

			return null;
		}
	}
}
