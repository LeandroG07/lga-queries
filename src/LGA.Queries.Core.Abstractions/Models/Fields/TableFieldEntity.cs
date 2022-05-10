
namespace LGA.Queries.Core.Abstractions.Models.Fields
{
    public class TableFieldEntity
    {

        public string Table { get; }
        public string Field { get; }

        public TableFieldEntity(string table, string field)
        {
            Table = table;
            Field = field;
        }

    }
}
