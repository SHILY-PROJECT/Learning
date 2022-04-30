namespace SomeOfDemoTrash.Trashcan;

public delegate T ReturnStringSettings<T>(List<T> list);

public static class ListExtensions
{
    private static readonly Random _rnd = new();

    public static T? GetLine<T>(this List<T> list, Func<List<T>, T> returnStringSettings, bool throwExceptionIfListIsInvalid = false)
    {
        if (list is null || list.Count == 0)
        {
            if (throwExceptionIfListIsInvalid)
                throw new Exception("List is empty or null.");
            return default;
        }

        return returnStringSettings.Invoke(list);
    }

    public static void Shuffle<T>(this IList<T> list)
    {
        var n = list.Count;

        while (n-- > 1 && _rnd.Next(n + 1) is int k)
        {
            (list[n], list[k]) = (list[k], list[n]);
        }
    }
}

public static class ReturnStringSettings
{
    private static readonly Random _rnd = new();

    public static T FirstLineWithMoveToEnd<T>(this List<T> list)
    {
        var line = list[0];
        list.RemoveAt(0);
        list.Add(line);
        return line;
    }

    public static T FirstLineWithRemoved<T>(this List<T> list)
    {
        var line = list[0];
        list.RemoveAt(0);
        return line;
    }

    public static T RandomLine<T>(this List<T> list)
        => list[_rnd.Next(list.Count)];

    public static T RandomLineWithRemoved<T>(this List<T> list)
    {
        var index = _rnd.Next(list.Count);
        var line = list[index];
        list.RemoveAt(index);
        return line;
    }
}