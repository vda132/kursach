using System.Collections.Generic;

namespace TVProgram.Models
{
    public class TVChannel : IModel
    {
        // properties
        public int IDChannel { get; set; }
        public string NameChannel { get; set; }

        /// <summary>
        /// It is realization of one to many relationship
        /// </summary>
        public IReadOnlyCollection<TVShow> Shows { get; set; } = new List<TVShow>();

        /// <summary>
        /// It is realization of one to many relationship
        /// </summary>
        public IReadOnlyCollection<TVProgram> Programs { get; set; } = new List<TVProgram>();
    }
}
