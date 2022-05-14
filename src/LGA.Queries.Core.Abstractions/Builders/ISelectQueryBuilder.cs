using LGA.Queries.Core.Abstractions.Models.Fields;
using LGA.Queries.Core.Abstractions.Models.Relations;

namespace LGA.Queries.Core.Abstractions.Builders
{
    public interface ISelectQueryBuilder
    {

        void InnerJoin(InnerJoinEntity relation);

        void InnerJoin(string table, string identityField, string[] fields, string relationalTable, string identityRelationalField);

        void LeftJoin(LeftJoinEntity relation);

        void LeftJoin(string table, string identityField, string[] fields, string relationalTable, string identityRelationalField);

        void Where(string field, FieldComparerType comparer, object value);

        void Where(string table, string field, FieldComparerType comparer, object value);

    }
}
