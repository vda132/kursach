using System;
using System.Collections.Generic;
using System.Linq;

namespace TVProgram.Models
{
    static class DayOfWeek
    {
        // Days as static string
        // ToDo: Translate to russian
        public static string Monday => "Monday";
        public static string Tuesday => "Tuesday";
        public static string Wednesday => "Wednesday";
        public static string Thursday => "Thursday";
        public static string Friday => "Friday";
        public static string Saturday => "Saturday";
        public static string Sunday => "Sunday";

        public static Dictionary<string, int> Sort = new()
        {
            { Monday, 1 },
            { Tuesday, 2 },
            { Wednesday, 3 },
            { Thursday, 4 },
            { Friday, 5 },
            { Saturday, 6 },
            { Sunday, 7 }
        };

        /// <summary>
        /// To use linq queries
        /// </summary>
        public static string[] DaysOfWeek => 
            new string[] { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };

        /// <summary>
        /// Validate existing of weekday
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static bool CheckDayOfWeek(string dayOfWeek)
        {
            return DaysOfWeek.Contains(dayOfWeek);
        }

        public static bool Greater(string dayOfWeek, string comparableDayOfWeek)
        {
            return Compare(dayOfWeek, comparableDayOfWeek) == 1;
        }

        public static bool Less(string dayOfWeek, string comparableDayOfWeek)
        {
            return Compare(dayOfWeek, comparableDayOfWeek) == -1;
        }

        public static bool Equal(string dayOfWeek, string comparableDayOfWeek)
        {
            return Compare(dayOfWeek, comparableDayOfWeek) == 0;
        }

        /// <summary>
        /// Do compare of two days
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <param name="comparableDayOfWeek"></param>
        /// <returns></returns>
        private static int Compare(string dayOfWeek, string comparableDayOfWeek)
        {
            if (!DaysOfWeek.Contains(dayOfWeek) || !DaysOfWeek.Contains(comparableDayOfWeek))
                throw new ArgumentException();

            Sort.TryGetValue(dayOfWeek, out var dayOfWeekValue);
            Sort.TryGetValue(comparableDayOfWeek, out var comparableDayOfWeekValue);

            return dayOfWeekValue > comparableDayOfWeekValue ? 1 :
                   dayOfWeekValue < comparableDayOfWeekValue ? -1 : 0;
        }   
    }
}
