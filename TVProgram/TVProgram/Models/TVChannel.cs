using System.Collections.Generic;

namespace TVProgram.Models
{
    class TVChannel
    {
        public int IDChannel { get; set; }
        public string NameChannel { get; set; }

        /// <summary>
        /// It is realization of one to many relationship
        /// </summary>
        public IReadOnlyCollection<TVProgram> Programs { get; set; } = new List<TVProgram>()
    }
}
