namespace SomeOfDemoTrash.Trashcan;

public delegate T LineOption<T>(List<T> list);

public static class ListExtensions
{
    public static T? GetLine<T>(this List<T> list, LineOption<T> lineOption, bool throwExceptionIfListIsEmptyOrNull = false)
    {
        if (list is null || list.Count == 0)
        {
            if (throwExceptionIfListIsEmptyOrNull)
                throw new Exception("Список пуст");
            return default;
        }

        return lineOption.Invoke(list);
    }
}

public static class LineOption
{
    private static readonly Random _rnd = new();

    public static T GetFirstLine<T>(this List<T> list) => list[0];

    public static T GetFirstLineWithRemoved<T>(this List<T> list)
    {
        var line = list[0];
        list.RemoveAt(0);
        return line;
    }

    public static T GetRandomLine<T>(this List<T> list) => list[_rnd.Next(list.Count)];

    public static T GetRandomLineWithRemoved<T>(this List<T> list)
    {
        var index = _rnd.Next(list.Count);
        var line = list[index];
        list.RemoveAt(index);
        return line;
    }

    public static T GetFirstLineWithMoveToEnd<T>(this List<T> list)
    {
        var line = list[0];
        list.RemoveAt(0);
        list.Add(line);
        return line;
    }
}