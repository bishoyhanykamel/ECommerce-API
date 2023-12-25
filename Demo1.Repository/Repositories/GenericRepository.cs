using Demo1.Core.Entities;
using Demo1.Core.Interfaces.Repositories;
using Demo1.Repository.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Repository.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly CompanyContext dbCtx;

		public GenericRepository(CompanyContext _dbCtx)
        {
			dbCtx = _dbCtx;
		}
        public async Task<IEnumerable<T>> GetAllAsync()
			=> await dbCtx.Set<T>().ToListAsync();
		

		public async Task<T> GetByIdAsync(int id)
			=>	 await dbCtx.Set<T>().FindAsync(id);
		
	}
}
