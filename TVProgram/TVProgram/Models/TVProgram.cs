using System;

namespace TVProgram.Models
{
    class TVProgram : IModel
    {
        // properties
        public int IDChannel { get; set; }
        public TVChannel Channel { get; set; }
        public int IDShow { get; set; }
        public TVShow Show { get; set; }
        public string StartWeekDay { get; set; }
        public string EndWeekDay { get; set; }
        public Time StartTime { get; set; }
        public Time EndTime { get; set; }
    }
}
