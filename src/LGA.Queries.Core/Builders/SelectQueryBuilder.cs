using LGA.Queries.Core.Abstractions.Builders;
using LGA.Queries.Core.Abstractions.Models.Fields;
using LGA.Queries.Core.Abstractions.Models.Conditions;
using LGA.Queries.Core.Abstractions.Models.Relations;
using LGA.Queries.Core.Extensions.Strings;
using System.Text;

namespace LGA.Queries.Core.Builders
{
    public class SelectQueryBuilder : QueryBuilder, ISelectQueryBuilder
    {
        private readonly StringBuilder _query;

        private readonly List<TableFieldEntity> _fields;
        private readonly List<RelationEntity> _relations;
        private readonly List<ConditionEntity> _conditions;

        //private List<TableFieldEntity> Fields { get; }
        
        public string Query { get => _query.ToString(); }

        public SelectQueryBuilder(string[] fields, string table) : base(table)
        {
            _query = new StringBuilder();
            _fields = fields.Select(f => new TableFieldEntity(table, f)).ToList();
            _relations = new List<RelationEntity>();
            _conditions = new List<ConditionEntity>();
        }

        private void Select()
        {
            _query.AppendLine($"SELECT {StringExtensions.Join($", ", $"{Table}.", Fields)}");
        }

        private void From()
        {
            _query.AppendLine($"FROM {Table} WITH(NOLOCK)");
        }

        public void InnerJoin(InnerJoinEntity relation)
        {
            _relations.Add(relation);
        }

        public void InnerJoin(string table, string identityField, string relationalTable, string identityRelationalField, string[] relationalFields)
        {
            InnerJoin(new InnerJoinEntity(table, identityField, relationalTable, identityRelationalField, relationalFields));
        }

        public void LeftJoin(LeftJoinEntity relation)
        {
            _relations.Add(relation);
        }

        public void LeftJoin(string table, string identityField, string relationalTable, string identityRelationalField, string[] relationalFields)
        {
            LeftJoin(new LeftJoinEntity(table, identityField, relationalTable, identityRelationalField, relationalFields));
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

        private void BuildRelations()
        {
            if (_relations.Any())
                _relations.ForEach(r => _query.Append(r.RelationalQuery));
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
            Select();
            From();
            BuildRelations();
            BuildConditions();

            return this;
        }


    }
}
