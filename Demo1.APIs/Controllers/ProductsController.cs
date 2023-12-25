using Demo1.Core.Entities;
using Demo1.Core.Interfaces;
using Demo1.Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Demo1.APIs.Controllers
{

	public class ProductsController : BaseAPIController
	{
		private readonly IUnitOfWork _unitOfWork;

		public ProductsController(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllProducts()
		{
			return Ok(await _unitOfWork.ProductRepo.GetAllAsync());
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProductById(int id)
		{
			return Ok(await _unitOfWork.ProductRepo.GetByIdAsync(id));
		}
	}
}
