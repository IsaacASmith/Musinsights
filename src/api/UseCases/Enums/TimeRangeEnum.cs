using System;

namespace UseCases.Enums
{
    public enum TimeRange
    {
        ShortTerm, MediumTerm, LongTerm
    }

    public static class TimeRangeHelper
    {
        public static TimeRange ParseTimeRange(string timeRange)
        {
            if (Enum.TryParse(timeRange, out TimeRange result))
            {
                return result;
            }

            return TimeRange.ShortTerm;
        }
    }
}
