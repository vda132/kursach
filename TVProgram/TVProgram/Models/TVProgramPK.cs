namespace TVProgram.Models
{
    /// <summary>
    /// To create base crud provider
    /// </summary>
    class TVProgramPK
    {
        public int IDChannel { get; set; }
        public int IDShow { get; set; }
        public string StartDayOfWeek { get; set; }
        public Time StartTime { get; set; }
    }
}
