
namespace LGA.Queries.Core.Abstractions.Models.Relations
{
    public abstract class RelationEntity
    {
        public string Table { get; }
        public string IdentityField { get; }
        public string[] Fields { get; }
        public string RelationalTable { get; }
        public string IdentityRelationalField { get; }
        public abstract RelationType Type { get; }
        public abstract string Command { get; }

        public RelationEntity(string table, string identityField, string[] fields, string relationalTable, string identityRelationalField)
        {
            Table = table;
            IdentityField = identityField;
            Fields = fields;
            RelationalTable = relationalTable;
            IdentityRelationalField = identityRelationalField;            
        }

        public string RelationalQuery
        {
            get => $"{Command} {Table} WITH(NOLOCK) ON {Table}.{IdentityField} = {RelationalTable}.{IdentityRelationalField}";
        }

    }
}
