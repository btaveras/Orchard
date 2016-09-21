using Orchard.Environment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Environment.Extensions.Models;
using Orchard.ContentManagement;
using Orchard.Taxonomies.Models;
using Orchard.Taxonomies.Services;

namespace Pluralsight.Movies.Handlers
{
    public class MovieFeatureEventHandler : IFeatureEventHandler
    {
        private readonly IContentManager _contentManager;
        private readonly ITaxonomyService _taxonomyService;

        public MovieFeatureEventHandler(ITaxonomyService taxonomyService,
            IContentManager contentManager)
        {
            _taxonomyService = taxonomyService;
            _contentManager = contentManager;
        }
        public void Disabled(Feature feature)
        {
          
        }

        public void Disabling(Feature feature)
        {
           
        }

        public void Enabled(Feature feature)
        {
            //If genre taxonomy is not defined create genre taxonomy
            // create genre taxonomy
            // create several genre terms in the taxonomy
            if(_taxonomyService.GetTaxonomyByName("Genre") == null)
            {
                var genre = _contentManager.New<TaxonomyPart>("Taxonomy");
                genre.Name = "Genre";
                _contentManager.Create(genre, VersionOptions.Published);


                CreateTerm(genre, "Action");
                CreateTerm(genre, "Adventure");
                CreateTerm(genre, "Animation");
                CreateTerm(genre, "Comedy");
                CreateTerm(genre, "Crime");
                CreateTerm(genre, "Documentary");
                CreateTerm(genre, "Drama");
            }
        }

        private void CreateTerm(TaxonomyPart genre, string genreName)
        {
            var term = _taxonomyService.NewTerm(genre);
            term.Name = genreName;
            _contentManager.Create(term, VersionOptions.Published);

        }
        public void Enabling(Feature feature)
        {
            throw new NotImplementedException();
        }

        public void Installed(Feature feature)
        {
            throw new NotImplementedException();
        }

        public void Installing(Feature feature)
        {
            throw new NotImplementedException();
        }

        public void Uninstalled(Feature feature)
        {
            throw new NotImplementedException();
        }

        public void Uninstalling(Feature feature)
        {
            throw new NotImplementedException();
        }
    }
}