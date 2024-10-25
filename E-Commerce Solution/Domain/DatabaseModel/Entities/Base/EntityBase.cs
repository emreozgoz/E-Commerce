using System.ComponentModel.DataAnnotations;
using DatabaseModel.Entities.Base.Interface;

namespace DatabaseModel.Entities.Base
{
    public class EntityBase<T> : IEntity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
