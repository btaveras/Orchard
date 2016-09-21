using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pluralsight.Movies.Models
{
    public class MovieActorRecord
    {
        public virtual int Id { get; set; }
        public virtual MoviePartRecord MoviePartRecord { get; set;}
        public virtual ActorRecord ActorRecord { get; set;}
    }
}