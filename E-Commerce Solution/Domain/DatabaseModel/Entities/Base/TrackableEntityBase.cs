using DatabaseModel.Entities.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities.Base
{
    public class TrackableEntityBase<TId> : EntityBase<TId>, ITrackableEntityBase
    {
        public TrackableEntityBase()
        {
            CreatedOn = DateTime.Now;
        }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long? UpdatedBy { get; set; }
    }
}
