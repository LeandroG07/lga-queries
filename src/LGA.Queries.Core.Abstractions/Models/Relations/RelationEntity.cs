
namespace LGA.Queries.Core.Abstractions.Models.Relations
{
    public abstract class RelationEntity
    {
        public string Table { get; }
        public string IdentityField { get; }
        public string RelationalTable { get; }
        public string IdentityRelationalField { get; }
        public string[] RelationalFields { get; }
        public abstract RelationType Type { get; }
        public abstract string Command { get; }

        public RelationEntity(string table, string identityField, string relationalTable, string identityRelationalField, string[] relationalFields)
        {
            Table = table;
            IdentityField = identityField;
            RelationalTable = relationalTable;
            IdentityRelationalField = identityRelationalField;
            RelationalFields = relationalFields;
        }

        public string RelationalQuery
        {
            get => $"{Command} {Table} ON {Table}.{IdentityField} = {RelationalTable}.{IdentityRelationalField}";
        }

    }
}
