using LGA.Queries.Core.Abstractions.Builders;
using LGA.Queries.Core.Abstractions.Comparer;
using LGA.Queries.Core.Comparer;
using System.Text;

namespace LGA.Queries.Core.Builders
{
    public class SelectQueryBuilder : QueryBuilder, ISelectQueryBuilder
    {
        private StringBuilder _query;
        private StringBuilder _conditionalQuery;
        private QueryComparerCommand _command;
        private Dictionary<string, object> _parameters;

        public string[] Fields { get; }
        public Dictionary<string, object> Parameters { get => _parameters; }

        public SelectQueryBuilder(string[] fields, string table) : base(table)
        {
            _query = new StringBuilder();
            _conditionalQuery = new StringBuilder();
            _command = new QueryComparerCommand();
            _parameters = new Dictionary<string, object>();
            Fields = fields;
        }

        public void Where(string field, QueryComparer comparer, object value)
        {
            if (_conditionalQuery.Length == 0)
                _conditionalQuery.Append("WHERE");
            else
                _conditionalQuery.Append("AND");

            _conditionalQuery.Append($" {field} {_command.Get(comparer)} @{field}");
            _parameters.Add(field, value);
        }

        public override IQueryBuilder Build()
        {
            _query.Append($"SELECT {string.Join($", ", Fields)} FROM {Table} ");
            return this;
        }
    }
}
