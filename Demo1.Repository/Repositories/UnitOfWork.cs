using Demo1.Core.Entities;
using Demo1.Core.Interfaces;
using Demo1.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Repository.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
		public IGenericRepository<Product> ProductRepo { get; set; }
		public UnitOfWork(IGenericRepository<Product> _productRepo)
		{
            ProductRepo = _productRepo;
        }
    }
}
