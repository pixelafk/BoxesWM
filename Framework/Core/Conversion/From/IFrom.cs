namespace Framework.Core.Conversion;

public interface IFrom<in TFrom, out TReturn>
{
    public static abstract TReturn From(TFrom from);
}