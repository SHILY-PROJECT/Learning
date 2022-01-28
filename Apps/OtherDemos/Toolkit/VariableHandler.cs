﻿namespace OtherDemos.Toolkit
{
    public class VariableHandler
    {
        public static string ExtractSizeFromBytes(long size)
        {
            var endOf = new[] { "Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            var index = default(int);

            while (index <= 10)
            {
                if (size <= (long)Math.Pow(2, (++index * 10)))
                {
                    var convertedSize = (size / Math.Pow(2, (index - 1) * 10));
                    var result = Convert.ToString(
                        Math.Round(convertedSize, Math.Truncate(convertedSize).ToString().Length switch { 1 => 2, 2 => 1, _ => 0 }));
                    return $"{result} {endOf[index - 1]}";
                }
            }
            return "HZ";
        }

    }
}
