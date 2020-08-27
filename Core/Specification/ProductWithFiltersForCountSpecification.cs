using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specification
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParms parms)
            : base(x =>
            (!parms.TypeId.HasValue || x.ProductTypeId == parms.TypeId)
            && (!parms.BrandId.HasValue || x.ProductBrandId == parms.BrandId))
        {

        }
    }
}
