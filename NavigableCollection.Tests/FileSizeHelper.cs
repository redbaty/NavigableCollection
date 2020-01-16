using System;

namespace NavigableCollection.Tests
{
    public static class FileSizeHelper
    {
        private static readonly string[] SizeSuffixes =
        {
                "bytes",
                "KB",
                "MB",
                "GB",
                "TB",
                "PB",
                "EB",
                "ZB",
                "YB"
        };

        private const long byteConversion = 1000;

        public static string GetHumanReadableFileSize(long value)
        {
            if (value < 0)
            {
                return "-" + GetHumanReadableFileSize(-value);
            }

            if (value == 0)
            {
                return "0.0 bytes";
            }

            var mag = (int) Math.Log(value, byteConversion);
            var adjustedSize = value / Math.Pow(1000, mag);


            return $"{adjustedSize:n2} {SizeSuffixes[mag]}";
        }
    }
}