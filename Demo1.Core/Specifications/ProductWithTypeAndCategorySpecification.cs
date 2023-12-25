using Demo1.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Core.Specifications
{
	public class ProductWithTypeAndCategorySpecification : BaseSpecification<Product>
	{
        public ProductWithTypeAndCategorySpecification()
        {
            IncludesList.Add(P => P.ProductBrand);
            IncludesList.Add(P => P.ProductType);
        }
    }
}
