using System;

namespace Domain.Entities
{
    public abstract class EntitieBase
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }
    }
}
