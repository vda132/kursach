using System;

namespace TVProgram.Models
{
    class Time
    {
        private int _hours;
        private int _minutes;

        public int Hours
        {
            get => _hours;
            set
            {
                ValidateHours(value);
                _hours = value;
            }
        }

        public int Minutes
        {
            get => _minutes;
            set
            {
                ValidateMinutes(value);
                _minutes = value;
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
            _hours = hours;
            _minutes = minutes;
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

        public override string ToString()
        {
            return NumberToString(_hours) + ":" + NumberToString(_minutes);
        }

        private string NumberToString(int value)
        {
            return value < 10 ? "0" + value.ToString() : value.ToString();
        }
    }
}
