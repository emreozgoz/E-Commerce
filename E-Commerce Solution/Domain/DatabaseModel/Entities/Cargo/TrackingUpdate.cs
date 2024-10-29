using DatabaseModel.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities.Cargo
{
    public class TrackingUpdate : EntityBase<long>
    {
        public DateTime UpdateDate { get; set; }  // Güncelleme tarihi
        public string UpdateDescription { get; set; }  // Güncelleme açıklaması
    }
}
