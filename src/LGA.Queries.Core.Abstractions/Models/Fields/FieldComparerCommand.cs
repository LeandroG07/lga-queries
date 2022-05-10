
namespace LGA.Queries.Core.Abstractions.Models.Fields
{
    public class FieldComparerCommand
    {
        private readonly Dictionary<FieldComparerType, string> _commands;

        public FieldComparerCommand()
        {
            _commands = new Dictionary<FieldComparerType, string>()
            {
                { FieldComparerType.Equal, "=" },
                { FieldComparerType.Major, ">" },
                { FieldComparerType.Minor, "<" }
            };
        }

        public string? Get(FieldComparerType comparer)
        {
            _commands.TryGetValue(comparer, out string? value);
            return value;
        }
    }
}
