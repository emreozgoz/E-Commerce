using DatabaseModel.Entities.Base;
using DatabaseModel.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities.Order
{
    public class OrderStatusHistory : EntityBase<long>
    {
        public DateTime ChangeDate { get; set; }  // Durum değişim tarihi
        public OrderStatus OldStatus { get; set; }  // Önceki durum
        public OrderStatus NewStatus { get; set; }  // Yeni durum
    }
}
