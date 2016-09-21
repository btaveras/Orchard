using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Pluralsight.Movies.Models;


namespace Pluralsight.Movies.Drivers
{
    public class MoviePartDriver : ContentPartDriver<MoviePart>
    {
        protected override string Prefix
        {
            get
            {
                return "Movie";
            }
        }

        protected override DriverResult Display(MoviePart part, string displayType, dynamic shapeHelper)
        {
            //display types: Detail, Summary, Summary_Admin
            //return content shape result delegate invoked only if shape is placed
            //here (second param) we can specify any shape but usually its gonna be the same
            //we give to the content shape method
            return ContentShape("Parts_Movie", () => shapeHelper.Parts_Movie
            (MoviePart: part));
        }

        //GET
        //orchard calls this when it loads the form or when save is there is
        //not a corresponding Editor method for such action
        protected override DriverResult Editor(MoviePart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Movie_Edit", () =>
                shapeHelper.EditorTemplate(TemplateName: "Parts/Movie",
                Model: part, Prefix: Prefix));
        }

        //POST 
        //was added so that orchard calls this instead when saving
        //map values posted to part with updater
        protected override DriverResult Editor(MoviePart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper); //call get method to redisplay form
        }
    }
}