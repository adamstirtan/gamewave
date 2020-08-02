using System;

namespace FinalBoss.ObjectModel
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }
    }
}
