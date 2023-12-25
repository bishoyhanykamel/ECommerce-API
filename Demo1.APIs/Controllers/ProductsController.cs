using AutoMapper;
using Demo1.APIs.Helpers.DTOs;
using Demo1.Core.Entities;
using Demo1.Core.Interfaces;
using Demo1.Core.Interfaces.Repositories;
using Demo1.Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo1.APIs.Controllers
{

	public class ProductsController : BaseAPIController
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			this._unitOfWork = unitOfWork;
			this._mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllProducts()
		{
			var specs = new ProductWithTypeAndCategorySpecification();
			var products = await _unitOfWork.ProductRepo.GetAllBySpecsAsync(specs);
			var productsDto = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);
			return Ok(productsDto);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductById(int id)
		{
			var specs = new ProductWithTypeAndCategorySpecification(P => P.Id == id);
			var product = await _unitOfWork.ProductRepo.GetBySpecsAsync(specs);
			var productDto = _mapper.Map<Product, ProductDto>(product);
			return Ok(productDto);
		}
	}
}
