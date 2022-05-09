using LGA.Queries.Core.Abstractions.Comparer;
using System.Collections.Generic;

namespace LGA.Queries.Core.Comparer
{
    public class QueryComparerCommand
    {

        private readonly Dictionary<QueryComparer, string> _commands;

        public QueryComparerCommand()
        {
            _commands = new Dictionary<QueryComparer, string>()
            {
                { QueryComparer.Equal, "=" },
                { QueryComparer.Major, ">" },
                { QueryComparer.Minor, "<" }
            };
        }

        public string? Get(QueryComparer comparer)
        {
            _commands.TryGetValue(comparer, out string? value);
            return value;
        }

    }
}
