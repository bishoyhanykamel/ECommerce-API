using Demo1.Core.Entities;
using Demo1.Core.Interfaces.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Repository
{
	public class SpecificationEvaluator<T>  where T : BaseEntity
	{
		public IQueryable<T> BuildQuery(IQueryable<T> mainQuery, ISpecification<T> specs)
		{
			var GeneratedQuery = mainQuery;

			if(specs.Criteria != null)
				GeneratedQuery = GeneratedQuery.Where(specs.Criteria);

			GeneratedQuery = specs.IncludesList.Aggregate(GeneratedQuery, (query, exp) => query.Include(exp));

			return GeneratedQuery;
		}
	}
}
