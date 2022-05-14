using LGA.Queries.Core.Abstractions.Builders;
using LGA.Queries.Core.Abstractions.Models.Fields;
using LGA.Queries.Core.Abstractions.Models.Conditions;
using LGA.Queries.Core.Abstractions.Models.Relations;
using System.Text;

namespace LGA.Queries.Core.Builders
{
    public class SelectQueryBuilder : QueryBuilder, ISelectQueryBuilder
    {
        private readonly StringBuilder _query;

        private readonly List<TableFieldEntity> _tableFields;
        private readonly List<RelationEntity> _relations;
        private readonly List<ConditionEntity> _conditions;

        public IReadOnlyList<ConditionEntity> Conditions { get => _conditions; }

        public string Query { get => _query.ToString().Trim(); }

        public SelectQueryBuilder(string[] fields, string table) : base(table)
        {
            _query = new StringBuilder();
            _tableFields = fields.Select(f => new TableFieldEntity(table, f)).ToList();
            _relations = new List<RelationEntity>();
            _conditions = new List<ConditionEntity>();
        }

        public void InnerJoin(InnerJoinEntity relation)
        {
            AddRelation(relation);
        }

        public void InnerJoin(string table, string identityField, string[] fields, string relationalTable, string identityRelationalField)
        {
            InnerJoin(new InnerJoinEntity(table, identityField, fields, relationalTable, identityRelationalField));
        }

        public void LeftJoin(LeftJoinEntity relation)
        {
            AddRelation(relation);
        }

        public void LeftJoin(string table, string identityField, string[] fields, string relationalTable, string identityRelationalField)
        {
            LeftJoin(new LeftJoinEntity(table, identityField, fields, relationalTable, identityRelationalField));
        }

        private void AddRelation(RelationEntity relation)
        {
            _relations.Add(relation);
            relation.Fields.ToList().ForEach(f => _tableFields.Add(new TableFieldEntity(relation.Table, f)));
        }

        public void Where(ConditionEntity condition)
        {
            _conditions.Add(condition);
        }

        public void Where(string field, FieldComparerType comparer, object value)
        {
            Where(new ConditionEntity(Table, field, comparer, value));
        }

        public void Where(string table, string field, FieldComparerType comparer, object value)
        {
            Where(new ConditionEntity(table, field, comparer, value));
        }

        private void BuildFields()
        {
            _query.AppendLine($"SELECT {string.Join($", ", _tableFields.Select(f => $"{f.Table}.{f.Field}").ToArray())}");
        }

        private void BuildTable()
        {
            _query.AppendLine($"FROM {Table} WITH(NOLOCK)");
        }

        private void BuildRelations()
        {
            if (_relations.Any())
                _relations.ForEach(r => _query.AppendLine(r.RelationalQuery));
        }

        private void BuildConditions()
        {
            foreach(var condition in _conditions)
            {
                if (_conditions.IndexOf(condition) == 0)
                    _query.Append("WHERE ");
                else
                    _query.Append("AND ");

                _query.Append(condition.ConditionQuery);
            }
        }

        public override IQueryBuilder Build()
        {           
            BuildFields();
            BuildTable();
            BuildRelations();
            BuildConditions();

            return this;
        }


    }
}
