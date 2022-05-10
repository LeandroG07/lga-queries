
namespace LGA.Queries.Core.Abstractions.Models.Relations
{
    public class InnerJoinEntity : RelationEntity
    {
        public InnerJoinEntity(string table, string identityField, string relationalTable, string identityRelationalField, string[] relationalFields) : base(table, identityField, relationalTable, identityRelationalField, relationalFields)
        {
        }

        public override RelationType Type => RelationType.Inner;

        public override string Command => "INNER JOIN";
    }
}
