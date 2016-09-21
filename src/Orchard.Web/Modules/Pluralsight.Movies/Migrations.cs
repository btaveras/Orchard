using Orchard.Data.Migration;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data;
using Pluralsight.Movies.Models;

namespace Pluralsight.Movies
{
    public class Migrations : DataMigrationImpl
    {
        private readonly IRepository<ActorRecord> _actorRepository;

        public Migrations(IRepository<ActorRecord> actorRepository){

        }
        public int Create()
        {
            ContentDefinitionManager.AlterTypeDefinition(
                "Movie", builder => builder.WithPart(
                    "CommonPart").WithPart("TitlePart").
                    WithPart("AutoroutePart")
                );
            return 1;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager.AlterTypeDefinition(
                "Movie", builder =>
                builder.WithPart("BodyPart").Creatable().
                Draftable()
                );
            return 2;
        }

        public int UpdateFrom2()
        {
            ContentDefinitionManager.AlterTypeDefinition(
                "Movie", builder =>
                builder.
                WithPart("BodyPart", partBuilder =>
                    partBuilder.WithSetting(
                        "BodyTypePartSettings.Flavor", "Textarea")).
                WithPart("AutoroutePart", partBuilder =>
                    partBuilder
                    .WithSetting("AutorouteSettings.AllowCustomPattern", "true")
                    .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                    .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name:'Movie Title'," +
                        "Pattern: 'movies/{Content.Slug}', Description: 'movies/movie-title'}," +
        "{Name: 'Film Title', Pattern: 'films/{Content.Slug}', Description: 'films/film-title'}]")
                    .WithSetting("AutorouteSettings.DefaultPatternIndex", "0")));
            return 3;
        }

        public int UpdateFrom3()
        {
            SchemaBuilder.CreateTable("MoviePartRecord",
                table => table.ContentPartRecord()
                .Column<string>("IMDB_ID")
                .Column<int>("YearReleased")
                .Column<string>("Rating",
                 col => col.WithLength(4)));

            ContentDefinitionManager.AlterTypeDefinition("Movie",
                builder => builder.WithPart("MoviePart"));
            return 4;
        }

        public int UpdateFrom4(){
            ContentDefinitionManager.AlterPartDefinition("MoviePart", builder =>
            builder.WithField("Genre", fld =>
            fld.OfType("TaxonomyField")
            .WithSetting("DisplayName", "Genre")
            //field is tied to genre taxonomy
            .WithSetting("TaxonomyFieldSettings.Taxonomy", "Genre") 
            //any term can be selected
            .WithSetting("TaxonomyFieldSettings.LeavesOnly", "False")
            //multiple terms can be selected
            .WithSetting("TaxonomyFieldSettings.SingleChoice", "False")

            .WithSetting("TaxonomyFieldSettings.Hint", "Select as many genres"+
            "as possible")));
            return 5;    
        }

        public int UpdateFrom5()
        {
            SchemaBuilder.CreateTable("ActorRecord", table => table
            .Column<int>("Id", col => col.PrimaryKey().Identity())
            .Column<string>("Name"));
           
            SchemaBuilder.CreateTable("MovieActorRecord", table => table
            .Column<int>("Id", col => col.PrimaryKey().Identity())
            .Column<int>("MoviePartRecord_Id")
            .Column<int>("ActorRecord_Id"));
            return 6;
        }
        public int UpdateFrom6()
        {
            _actorRepository.Create(new ActorRecord { Name = "Mark Hillel" });
            _actorRepository.Create(new ActorRecord { Name = "Rose Hill" });
            
            return 7;
        }
}