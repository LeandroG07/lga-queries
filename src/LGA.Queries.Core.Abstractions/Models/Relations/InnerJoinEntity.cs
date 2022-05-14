
namespace LGA.Queries.Core.Abstractions.Models.Relations
{
    public class InnerJoinEntity : RelationEntity
    {
        public InnerJoinEntity(string table, string identityField, string[] fields, string relationalTable, string identityRelationalField) : base(table, identityField, fields, relationalTable, identityRelationalField)
        {
        }

        public override RelationType Type => RelationType.Inner;

        public override string Command => "INNER JOIN";
    }
}
