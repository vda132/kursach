using System;
using TVProgram.Models;

namespace TVProgram.DisplayModels
{
    class TVProgram
    {
        // properties
        public int IDChannel { get; set; }
        public string NameChannel { get; set; }
        public int IDShow { get; set; }
        public string NameShow { get; set; }
        public string StartWeekDay { get; set; }
        public string EndWeekDay { get; set; }
        public Time StartTime { get; set; }
        public Time EndTime { get; set; }

        // c-tor
        // get properties from main model
        public TVProgram(Models.TVProgram program)
        {
            IDChannel = program.IDChannel;
            NameChannel = program.Channel.NameChannel;
            IDShow = program.IDShow;
            NameShow = program.Show.NameShow;
            StartWeekDay = program.StartWeekDay;
            EndWeekDay = program.EndWeekDay;
            StartTime = program.StartTime;
            EndTime = program.EndTime;
        }

        // Form info about program event
        public string FormMessage()
        {
            var newLine = Environment.NewLine;
            return NameChannel + newLine +
                newLine +
                NameShow + newLine +
                StartWeekDay + " " + StartTime + " - " + EndWeekDay + " " + EndTime;
        }
    }
}
