using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Pluralsight.Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pluralsight.Movies.Handlers
{
    //register life cycle events that we wanna use and register repositories
    //for movie parts records
    public class MovieHandler : ContentHandler
    {
        public MovieHandler(IRepository<MoviePartRecord> moviePartRepository)
        {
           //method for producing a storage filter using a particular repository
            Filters.Add(StorageFilter.For(moviePartRepository));
        }
    }
}