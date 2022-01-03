using System.Collections.Generic;

namespace TVProgram.Models
{
    public class TVGenre : IModel
    {
        // properties
        public int IDGenre { get; set; }
        public string NameGenre { get; set; }

        /// <summary>
        /// It is realization of many to many relationship
        /// </summary>
        public IReadOnlyCollection<TVShow> Shows { get; set; } = new List<TVShow>();
    }
}
