using Orchard.ContentManagement.Records;
using System.Collections.Generic;

namespace Pluralsight.Movies.Models
{
    
    public class MoviePartRecord:
        ContentPartRecord
    {
        public MoviePartRecord()
        {
            MovieActors = new List<MovieActorRecord>();
        }
        public virtual string IMDB_Id { get; set; }
        public virtual int YearReleased { get; set; }
        public virtual MPAARating Rating { get; set; }

        public IList<MovieActorRecord> MovieActors { get; set; }
    }
   
}