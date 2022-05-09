
namespace LGA.Queries.Core.Abstractions.Builders
{
    public abstract class QueryBuilder : IQueryBuilder
    {

        public string Table { get; }

        public QueryBuilder(string table)
        {
            Table = table;
        }

        public abstract IQueryBuilder Build();

    }
}
