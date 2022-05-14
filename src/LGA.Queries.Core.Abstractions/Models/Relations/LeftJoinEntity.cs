
namespace LGA.Queries.Core.Abstractions.Models.Relations
{
    public class LeftJoinEntity : RelationEntity
    {
        public LeftJoinEntity(string table, string identityField, string[] fields, string relationalTable, string identityRelationalField) : base(table, identityField, fields, relationalTable, identityRelationalField)
        {
        }

        public override RelationType Type => RelationType.Left;

        public override string Command => "LEFT JOIN";
    }
}
