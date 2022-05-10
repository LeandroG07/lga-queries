using LGA.Queries.Core.Abstractions.Models.Fields;
using LGA.Queries.Core.Abstractions.Models.Relations;

namespace LGA.Queries.Core.Abstractions.Builders
{
    public interface ISelectQueryBuilder
    {

        void InnerJoin(InnerJoinEntity relation);

        void InnerJoin(string table, string identityField, string relationalTable, string identityRelationalField, string[] relationalFields);

        void LeftJoin(LeftJoinEntity relation);

        void LeftJoin(string table, string identityField, string relationalTable, string identityRelationalField, string[] relationalFields);

        void Where(string field, FieldComparerType comparer, object value);

        void Where(string table, string field, FieldComparerType comparer, object value);

    }
}
