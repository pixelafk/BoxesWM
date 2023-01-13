namespace Framework.Core.Conversion;

public interface IAsResolver
{
    public T As<T>() => (this as IAs<T>)!.As();
}

// /// <summary>
// /// Abstract class for implementation of <see cref="Framework.Core.Conversion.IAsResolver"/>
// /// </summary>
// [Obsolete("Method is Deprecated implement IAsResolver instead.")]
// public abstract class AsResolver :
//     IAsResolver
// {
//     public T As<T>() => (this as IAs<T>).As();
// }
