// ReSharper disable HeapView.BoxingAllocation

using System.Numerics;

namespace Framework.Input;

using Core.Conversion;

// TODO: make key subscriptable
public partial class Key :
    IFrom<Keys, Key>,
    IFrom<int, Key>
{
    private readonly int _code;

    private Key(int code)
    {
        _code = code;
    }

    public static Key From(Keys from) => new(from.GetHashCode());

    public static Key From(int from) => new(from);

    public int Code => _code;
}

public partial class Key :
    IEquatable<Keys>,
    IEquatable<int>,
    IEqualityOperators<Key, Key, bool>,
    IEqualityOperators<Key, Keys, bool>
{
    public bool Equals(Key other) => _code == other._code;

    public bool Equals(Keys other) => _code == other.GetHashCode();

    public bool Equals(int other)
    {
        return _code == other;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        return obj.GetType() == GetType() && Equals((Key)obj);
    }

    public override int GetHashCode()
    {
        return _code;
    }

    public static bool operator ==(Key? left, Key? right) => left!.Equals(right!);
    
    public static bool operator !=(Key? left, Key? right) => !(left == right);
    
    public static bool operator ==(Key? left, Keys right) => left!.Equals(right);
    
    public static bool operator !=(Key? left, Keys right) => !(left == right);
}

public partial class Key :
    IAsResolver,
    IAs<Keys>,
    IAs<string>,
    IAs<int>
{
    public T As<T>() => (this as IAs<T>)!.As();

    Keys IAs<Keys>.As() => (Keys)_code;

    string IAs<string>.As() => ToString();
    
    int IAs<int>.As() => _code;
    
    public override string ToString() => As<Keys>().ToString();
}