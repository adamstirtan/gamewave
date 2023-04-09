using System;
using System.Linq;

using FinalBoss.ObjectModel.Attributes;

namespace FinalBoss.ObjectModel
{
    public abstract class BaseEntity
    {
        [NotMergable]
        public long Id { get; set; }

        [NotMergable]
        public DateTimeOffset Created { get; set; }

        [NotMergable]
        public DateTimeOffset LastModified { get; set; }

        public void Merge<T>(T target, T source)
        {
            Type type = typeof(T);

            var properties = type
                .GetProperties()
                .Where(x =>
                    !Attribute.IsDefined(x, typeof(NotMergableAttribute)) &&
                    x.CanRead && x.CanWrite);

            foreach (var property in properties)
            {
                var value = property.GetValue(source, null);

                if (value != null)
                {
                    property.SetValue(target, value, null);
                }
            }
        }
    }
}