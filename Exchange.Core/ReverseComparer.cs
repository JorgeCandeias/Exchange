namespace Exchange.Core;

public class ReverseComparer<T> : IComparer<T>
{
    private readonly IComparer<T> _comparer;

    public ReverseComparer()
    {
        _comparer = Default;
    }

    public int Compare(T? x, T? y)
    {
        return -_comparer.Compare(x, y);
    }

    public static ReverseComparer<T> Default { get; } = new();
}