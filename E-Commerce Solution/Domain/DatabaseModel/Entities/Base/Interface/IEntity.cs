using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel.Entities.Base.Interface
{
    public interface IEntity<TId>
    {
        public TId Id { get; set; }
    }
}
