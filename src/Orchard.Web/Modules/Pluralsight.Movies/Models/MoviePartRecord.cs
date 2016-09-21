﻿using Orchard.ContentManagement.Records;


namespace Pluralsight.Movies.Models
{
    public class MoviePartRecord:
        ContentPartRecord
    {
        public virtual string IMDB_Id { get; set; }
        public virtual int YearReleased { get; set; }
        public virtual MPAARating Rating { get; set; }
    }
   
}