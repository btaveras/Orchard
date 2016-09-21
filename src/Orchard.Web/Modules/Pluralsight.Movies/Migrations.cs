using Orchard.Data.Migration;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;

namespace Pluralsight.Movies
{
    public class Migrations : DataMigrationImpl
    {
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
    }
}