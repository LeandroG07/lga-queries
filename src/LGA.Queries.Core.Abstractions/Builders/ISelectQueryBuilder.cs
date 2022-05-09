using LGA.Queries.Core.Abstractions.Comparer;

namespace LGA.Queries.Core.Abstractions.Builders
{
    public interface ISelectQueryBuilder
    {

        void Where(string field, QueryComparer comparer, object value);

    }
}
