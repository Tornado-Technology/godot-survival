using System;

namespace Survival.Scripts.Interfaces;

public struct EntityUid : IEquatable<EntityUid>, IComparable<EntityUid>
{
	public static readonly EntityUid FirstUid = new(1);

	public readonly int Id;

    public bool Valid => Id > 0;

    public EntityUid(int id)
    {
        Id = id;
    }

    public bool Equals(EntityUid other)
    {
        return Id == other.Id;
    }

    public bool Equals(object other)
    {
        if (ReferenceEquals(null, other))
            return false;

        return other is EntityUid id && Equals(id);
    }

    public int CompareTo(EntityUid other)
    {
        return Id.CompareTo(other.Id);
    }

    public static bool operator ==(EntityUid a, EntityUid b)
    {
        return a.Id == b.Id;
    }

    public static bool operator !=(EntityUid a, EntityUid b)
    {
        return !(a == b);
    }

    public static explicit operator int(EntityUid self)
    {
        return self.Id;
    }

    public override string ToString()
    {
        return Id.ToString();
    }
}