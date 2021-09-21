using ApiCatalogoJogos.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoSqlServerRepository : IJogoRepository
    {
        private readonly SqlConnection sqlConnection;

        public JogoSqlServerRepository(IConfiguration configuration)
        {
            sqlConnection = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            throw new NotImplementedException();
        }

        public Task<Jogo> Obter(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Jogo jogo)
        {
            throw new NotImplementedException();
        }



        public Task Inserir(Jogo jogo)
        {
            throw new NotImplementedException();
        }



        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
