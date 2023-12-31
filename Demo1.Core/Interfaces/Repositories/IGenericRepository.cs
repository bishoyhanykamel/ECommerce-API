﻿using Demo1.Core.Entities;
using Demo1.Core.Interfaces.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Core.Interfaces.Repositories
{
	public interface IGenericRepository<T> where T : BaseEntity
 	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);

		Task<IEnumerable<T>> GetAllBySpecsAsync(ISpecification<T> specs);
		Task<T> GetBySpecsAsync(ISpecification<T> specs);
	}
}
