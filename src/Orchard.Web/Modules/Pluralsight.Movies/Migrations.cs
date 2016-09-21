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

    }
}