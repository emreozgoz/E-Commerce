using DatabaseModel.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities.Product
{
    public class DiscountRule : EntityBase<long>
    {
        public string Name { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
