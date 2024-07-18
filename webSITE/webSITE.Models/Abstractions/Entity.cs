using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webSITE.Domain.Abstractions
{
    public abstract class Entity : IEquatable<Entity>
    {
        public int Id { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;

            if (obj.GetType() != GetType()) return false;

            if (obj is not Entity other) return false;

            return other.Id == Id;
        }

        public bool Equals(Entity? other)
        {
            if (other is null) return false;

            if (other.GetType() != GetType()) return false;

            return other.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator==(Entity? left, Entity? right)
        {
            if(left is null) return false;

            if(right is null) return false;

            return left.Equals(right);
        }

        public static bool operator!=(Entity? left, Entity? right)
        {
            return !(left == right);
        }
    }
}
