using DatabaseModel.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities.Product
{
    public class ProductImage : EntityBase<long>
    {
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
    }
}
