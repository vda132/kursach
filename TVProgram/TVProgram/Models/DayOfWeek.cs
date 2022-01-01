using System;
using System.Linq;

namespace TVProgram.Models
{
    static class DayOfWeek
    {
        // Days as static string
        public static string Monday => "Понедельник";
        public static string Tuesday => "Вторник";
        public static string Wednesday => "Среда";
        public static string Thursday => "Четверг";
        public static string Friday => "Пятница";
        public static string Saturday => "Суббота";
        public static string Sunday => "Воскресенье";

        /// <summary>
        /// To use linq queries
        /// </summary>
        private static string[] DaysOfWeek => 
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
    }
}
