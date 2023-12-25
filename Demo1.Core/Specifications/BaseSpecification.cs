using Demo1.Core.Entities;
using Demo1.Core.Interfaces.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Core.Specifications
{
	public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
	{
		public Expression<Func<T, bool>> Criteria { get; set; }
		public List<Expression<Func<T, object>>> IncludesList { get; set; } = new List<Expression<Func<T, object>>>();

		public BaseSpecification()
		{

		}

        public BaseSpecification(Expression<Func<T, bool>> _criteria)
        {
			Criteria = _criteria;
        }
    }
}
