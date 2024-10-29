using DatabaseModel.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities.Product
{
    public class ProductVariant : EntityBase<long>
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
