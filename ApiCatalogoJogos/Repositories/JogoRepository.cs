using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {

        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("67D66B0A-EB5F-4285-ACA8-67365AAF4193"), new Jogo{Id = Guid.Parse("67D66B0A-EB5F-4285-ACA8-67365AAF4193"), Nome = "Fifa 21", Produtora = "EA", Preco = 200}},
            {Guid.Parse("FC237F51-67C3-47F0-A682-ED456C9E923C"), new Jogo{Id = Guid.Parse("FC237F51-67C3-47F0-A682-ED456C9E923C"), Nome = "Fifa 21", Produtora = "EA", Preco = 190}},
            {Guid.Parse("2D875BAE-9F58-4929-8C44-9FBE6BF0960B"), new Jogo{Id = Guid.Parse("2D875BAE-9F58-4929-8C44-9FBE6BF0960B"), Nome = "Fifa 21", Produtora = "EA", Preco = 180}},
            {Guid.Parse("C4D09404-1602-4F50-B3EB-10B66B17FEA4"), new Jogo{Id = Guid.Parse("C4D09404-1602-4F50-B3EB-10B66B17FEA4"), Nome = "Fifa 21", Produtora = "EA", Preco = 170}},
            {Guid.Parse("0EA98902-E9B4-478A-A36A-2F723DF627D8"), new Jogo{Id = Guid.Parse("0EA98902-E9B4-478A-A36A-2F723DF627D8"), Nome = "Street Fighter V", Produtora = "Capcom", Preco = 80}},
            {Guid.Parse("3C76E8DF-8AB8-493F-9C05-205F3E2EAE95"), new Jogo{Id = Guid.Parse("3C76E8DF-8AB8-493F-9C05-205F3E2EAE95"), Nome = "Grand Theft Auto V", Produtora = "Rockstar", Preco = 190}}
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLambda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();

            foreach(var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            // fechar conexão com o banco
        }
    }
}
