
using LGA.Queries.Core.Builders;
using Xunit;

namespace LGA.Queries.Core.Tests
{
    public class SelectQueryBuilderTest
    {

        [Theory]
        [InlineData(new string[] { "IdCliente", "Nome" }, "Cliente", "SELECT Cliente.IdCliente, Cliente.Nome\r\nFROM Cliente WITH(NOLOCK)")]
        public void ShouldBuildSelectQuery(string[] fields, string table, string resultQuery)
        {
            var selectQueryBuilder = new SelectQueryBuilder(fields, table);

            selectQueryBuilder.Build();

            Assert.Equal(resultQuery, selectQueryBuilder.Query);
        }

        [Theory]
        [InlineData(new string[] { "IdCliente", "Nome" }, "Cliente", "Endereco", "IdEndereco", new string[] { "IdEndereco", "Descricao", "Cidade" }, "SELECT Cliente.IdCliente, Cliente.Nome, Endereco.IdEndereco, Endereco.Descricao, Endereco.Cidade\r\nFROM Cliente WITH(NOLOCK)\r\nLEFT JOIN Endereco WITH(NOLOCK) ON Endereco.IdEndereco = Cliente.IdEndereco")]
        public void ShouldBuildSelectLeftJoinQuery(string[] fields, string table, string joinTable, string joinIdentity, string[] joinFields, string resultQuery)
        {
            var selectQueryBuilder = new SelectQueryBuilder(fields, table);

            selectQueryBuilder.LeftJoin(joinTable, joinIdentity, joinFields, table, joinIdentity);
            selectQueryBuilder.Build();

            Assert.Equal(resultQuery, selectQueryBuilder.Query);
        }

        [Theory]
        [InlineData(new string[] { "IdCliente", "Nome" }, "Cliente", "Endereco", "IdEndereco", new string[] { "IdEndereco", "Descricao", "Cidade" }, "SELECT Cliente.IdCliente, Cliente.Nome, Endereco.IdEndereco, Endereco.Descricao, Endereco.Cidade\r\nFROM Cliente WITH(NOLOCK)\r\nINNER JOIN Endereco WITH(NOLOCK) ON Endereco.IdEndereco = Cliente.IdEndereco")]
        public void ShouldBuildSelectInnerJoinQuery(string[] fields, string table, string joinTable, string joinIdentity, string[] joinFields, string resultQuery)
        {
            var selectQueryBuilder = new SelectQueryBuilder(fields, table);

            selectQueryBuilder.InnerJoin(joinTable, joinIdentity, joinFields, table, joinIdentity);
            selectQueryBuilder.Build();

            Assert.Equal(resultQuery, selectQueryBuilder.Query);
        }

        [Theory]
        [InlineData(new string[] { "IdCliente", "Nome" }, "Cliente", "Endereco", "IdEndereco", new string[] { "IdEndereco", "Descricao", "Cidade" }, "Telefone", "IdTelefone",  new string[] { "IdTelefone", "Prefixo", "Numero" }, "SELECT Cliente.IdCliente, Cliente.Nome, Endereco.IdEndereco, Endereco.Descricao, Endereco.Cidade, Telefone.IdTelefone, Telefone.Prefixo, Telefone.Numero\r\nFROM Cliente WITH(NOLOCK)\r\nINNER JOIN Endereco WITH(NOLOCK) ON Endereco.IdEndereco = Cliente.IdEndereco\r\nLEFT JOIN Telefone WITH(NOLOCK) ON Telefone.IdTelefone = Cliente.IdTelefone")]
        public void ShouldBuildSelectInnerJoinWithLeftJoinQuery(string[] fields, string table, string innerJoinTable, string innerJoinIdentity, string[] innerJoinFields, string leftJoinTable, string leftJoinIdentity, string[] leftJoinFields, string resultQuery)
        {
            var selectQueryBuilder = new SelectQueryBuilder(fields, table);

            selectQueryBuilder.InnerJoin(innerJoinTable, innerJoinIdentity, innerJoinFields, table, innerJoinIdentity);
            selectQueryBuilder.LeftJoin(leftJoinTable, leftJoinIdentity, leftJoinFields, table, leftJoinIdentity);
            selectQueryBuilder.Build();

            Assert.Equal(resultQuery, selectQueryBuilder.Query);
        }

    }
}
