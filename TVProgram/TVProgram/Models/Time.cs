using System;

namespace TVProgram.Models
{
    public class Time
    {
        private int hours;
        private int minutes;

        public int Hours
        {
            get => hours;
            set
            {
                ValidateHours(value);
                hours = value;
            }
        }

        public int Minutes
        {
            get => minutes;
            set
            {
                ValidateMinutes(value);
                minutes = value;
            }
        }

        /// <summary>
        /// Initialize Time
        /// </summary>
        /// <param name="hours">0 by default</param>
        /// <param name="minutes">0 by default</param>
        public Time(int hours = 0, int minutes = 0)
        {
            ValidateTime(hours, minutes);
            this.hours = hours;
            this.minutes = minutes;
        }

        private void ValidateTime(int hours, int minutes)
        {
            ValidateHours(hours);
            ValidateMinutes(minutes);
        }

        private void ValidateMinutes(int minutes)
        {
            var isValid = 0 <= minutes && minutes < 60;
            if (!isValid) throw new ArgumentException();
        }

        private void ValidateHours(int hours)
        {
            var isValid = 0 <= hours && hours < 24;
            if (!isValid) throw new ArgumentException();
        }

        public static Time FromString(string time)
        {
            var hours = int.Parse(time.Substring(0, 2));
            var minutes = int.Parse(time.Substring(3, 2));
            return new Time(hours, minutes);
        }

        public override string ToString()
        {
            return NumberToString(hours) + ":" + NumberToString(minutes);
        }

        private string NumberToString(int value)
        {
            return value < 10 ? "0" + value.ToString() : value.ToString();
        }

        public bool GreaterTo(Time time)
        {
            return CompareTo(time) is 1;
        }

        public bool GreaterOrEqualTo(Time time)
        {
            return CompareTo(time) is 1 or 0;
        }

        public bool EqualTo(Time time)
        {
            return CompareTo(time) is 0;
        }

        public bool LessOrEqualTo(Time time)
        {
            return CompareTo(time) is -1 or 0;
        }

        public bool LessTo(Time time)
        {
            return CompareTo(time) is -1;
        }

        private int CompareTo(Time time)
        {
            if (hours > time.hours)
                return 1;

            if (hours < time.hours)
                return -1;

            if (minutes > time.minutes)
                return 1;

            if (minutes < time.minutes)
                return -1;

            return 0;
        }

        public override bool Equals(object obj)
        {
            return obj is Time time &&
                   hours == time.hours &&
                   minutes == time.minutes;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(hours, minutes);
        }
    }
}
