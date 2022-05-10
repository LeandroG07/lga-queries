
namespace LGA.Queries.Core.Abstractions.Models.Relations
{
    public class LeftJoinEntity : RelationEntity
    {
        public LeftJoinEntity(string table, string identityField, string relationalTable, string identityRelationalField, string[] relationalFields) : base(table, identityField, relationalTable, identityRelationalField, relationalFields)
        {
        }

        public override RelationType Type => RelationType.Left;

        public override string Command => "LEFT JOIN";
    }
}
