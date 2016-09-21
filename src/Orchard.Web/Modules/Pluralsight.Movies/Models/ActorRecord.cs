﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pluralsight.Movies.Models
{
    public class ActorRecord
    {
        public ActorRecord()
        {
            ActorMovies = new List<MovieActorRecord>();
        }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<MovieActorRecord> ActorMovies { get; set; }
    }
}