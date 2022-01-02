using System.Collections.Generic;

namespace TVProgram.Models
{
    public class TVShow : IModel
    {
        public int IDShow { get; set; }
        public string NameShow { get; set; }

        /// <summary>
        /// It is realization of many to many relationship
        /// </summary>
        public IReadOnlyCollection<TVGenre> Genres { get; set; } = new List<TVGenre>();

        /// <summary>
        /// It is realization of one to many relationship
        /// </summary>
        public IReadOnlyCollection<TVProgram> Programs { get; set; } = new List<TVProgram>();
    }
}
