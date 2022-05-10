
using LGA.Queries.Core.Builders;
using Xunit;

namespace LGA.Queries.Core.Tests
{
    public class SelectQueryBuilderTest
    {

        [Theory]
        [InlineData(new string[] { "IdCliente", "Nome" }, "Cliente", "SELECT Cliente.IdCliente, Cliente.Nome\r\nFROM Cliente WITH(NOLOCK)\r\n")]
        public void ShouldBuildSelectQuery(string[] fields, string table, string query)
        {
            var selectQueryBuilder = new SelectQueryBuilder(fields, table);

            selectQueryBuilder.Build();

            Assert.Equal(query, selectQueryBuilder.Query);
        }

        [Theory]
        [InlineData(new string[] { "IdCliente", "Nome" }, "Cliente", "SELECT Cliente.IdCliente, Cliente.Nome\r\nFROM Cliente WITH(NOLOCK)\r\n")]
        public void ShouldBuildSelectInnerJoinQuery(string[] fields, string table, string query)
        {
            var selectQueryBuilder = new SelectQueryBuilder(fields, table);

            selectQueryBuilder.Build();

            Assert.Equal(query, selectQueryBuilder.Query);
        }

    }
}
