using LGA.Queries.Core.Abstractions.Models.Fields;

namespace LGA.Queries.Core.Abstractions.Models.Conditions
{
    public class ConditionEntity
    {

        private readonly FieldComparerCommand _commands;

        public string Table { get; }
        public string Field { get; }
        public FieldComparerType Comparer { get; }
        public object Value { get; }

        public ConditionEntity(string table, string field, FieldComparerType comprarer, object value)
        {
            Table = table;
            Field = field;
            Comparer = comprarer;
            Value = value;
            _commands = new FieldComparerCommand();
        }

        public string? ComparerCommand { get => _commands.Get(Comparer); }

        public string ConditionQuery { get => $"{Table}.{Field} {ComparerCommand} @{Table}.{Field}"; }

    }
}
