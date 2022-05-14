using LGA.Queries.Core.Abstractions.Models.Fields;

namespace LGA.Queries.Core.Abstractions.Models.Conditions
{
    public class ConditionEntity
    {

        private readonly FieldComparerCommand _commands;

        public TableFieldEntity TableField { get; }
        public FieldComparerType Comparer { get; }
        public object Value { get; }

        public ConditionEntity(string table, string field, FieldComparerType comprarer, object value) : this(new TableFieldEntity(table, field), comprarer, value)
        {
        }

        public ConditionEntity(TableFieldEntity tableField, FieldComparerType comprarer, object value)
        {
            TableField = tableField;
            Comparer = comprarer;
            Value = value;
            _commands = new FieldComparerCommand();
        }

        public string? ComparerCommand { get => _commands.Get(Comparer); }

        public string ConditionQuery { get => $"{TableField.Table}.{TableField.Field} {ComparerCommand} @{TableField.Table}.{TableField.Field}"; }

    }
}
