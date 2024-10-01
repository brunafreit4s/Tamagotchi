using Tamagochi.Models;

namespace Tamagochi.Controllers
{
    public class MenuController : PokedexController
    {
        public string GetMenuPrincipal(string nomeUsuario)
        {
            string retorno = "\n---------------------------------------- Menu ----------------------------------------\n";
            retorno += $"{nomeUsuario} você deseja:\n";
            retorno += "1 - Adotar um mascote virtual.\n2 - Ver seus mascotes.\n3 - Sair.\n";
            return retorno.ToUpper();
        }        

        public string GetMenuSecundario(string nomeUsuario, int codPokemon)
        {
            var response = GetPokemonApi(codPokemon);
            string retorno = "\n-------------------- -------------------- -------------------- --------------------\n";
            retorno += $"{nomeUsuario} você deseja:\n";
            retorno += $"1 - Saber mais sobre {response.Result.Nome}.\n2 - Adotar {response.Result.Nome}.\n3 - Voltar.\n";

            return retorno.ToUpper();
        }

        public string GetMenuAdocao(string nomeUsuario)
        {
            UtilController utilController = new UtilController();
            Task<PokemonResponse> response = GetListPokemon();
            string opcoesFormatada = "\n---------------------------------------- Adotar um Mascote ----------------------------------------\n";
            opcoesFormatada += $"{nomeUsuario} escolha uma espécie:\n";
            opcoesFormatada += utilController.FormataOpcoes(response);

            return opcoesFormatada.ToUpper();
        }

        public string GetMenuInteracao(string nomeUsuario, int codPokemon)
        {
            var response = GetPokemonApi(codPokemon).Result;
            string retorno = "\n-------------------- -------------------- -------------------- --------------------\n";
            retorno += $"{nomeUsuario} você deseja:\n";
            retorno += $"1 - Saber mais sobre {response.Nome}.\n2 - Adotar {response.Nome}.\n3 - Voltar.\n";

            return retorno.ToUpper();
        }

        public string GetMenuSobrePokemon(string nomeUsuario, int posicaoPokemon)
        {
            var response = GetPokemon(posicaoPokemon);
            string retorno = "\n---------------------------------------- Menu ----------------------------------------\n";
            retorno += $"{nomeUsuario} você deseja:\n";
            retorno += $"1 - Saber como {response.Nome} está.\n2 - Alimentar {response.Nome}.\n3 - Brincar com {response.Nome}.\n4 - Colocar {response.Nome} para dormir.\n5 - Voltar.";
            return retorno.ToUpper();
        }

        public string GetMenuStatusPokemon(int posicaoPokemon)
        {
            var response = GetPokemon(posicaoPokemon);
            string retorno = "\n---------------------------------------- Seu Pokemon está ----------------------------------------\n";
            retorno += "\nFome: " + response.Status.Fome;
            retorno += "\nHumor: " + response.Status.Humor;
            retorno += "\nSono: " + response.Status.Sono;
            return retorno.ToUpper();
        }
    }
}
