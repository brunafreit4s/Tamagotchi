using Tamagochi.Models;
using Tamagochi.Models.DTO;

namespace Tamagochi.Controllers
{
    public class PokedexController : PokemonController
    {
        public Pokedex pokedex = new Pokedex();
        public List<TamagotchiDto> pokedex2 = new List<TamagotchiDto>();
        private Pokemon _pokemon = new Pokemon();

        public void PutPokedex(int codPokemon)
        {
            var response = GetPokemonApi(codPokemon).Result;

            if (response != null)
            {
                var tamagotchi = new TamagotchiDto();
                tamagotchi.AtualizarPropriedades(response);
                pokedex2.Add(tamagotchi);
            }
        }       
        
        public void GetPokedex()
        {
            string retorno = "\n---------------------------------------- Pokedex ----------------------------------------\n";

            if (pokedex2.Count != 0)
            {
                string textPokemon = (pokedex2.Count > 1) ? "Pokemons" : "Pokemon";

                retorno += $"\nVocê tem {pokedex2.Count} {textPokemon}";

                for (int i = 0; i < pokedex2.Count; i++)
                {
                    retorno += $"\n{i + 1} - {pokedex2[i].Nome}\n";
                }
            }
            else
            {
                retorno += "\nVocê não adotou nenhum Pokemon até o momento!\n\n";
                retorno += $"     ▄████████████████▄      \n";
                retorno += $"     █                █      \n";
                retorno += $"     █     █    █     █      \n";
                retorno += $"     █    ▀      ▀    █      \n";
                retorno += $"     █   ▀        ▀   █      \n";
                retorno += $"     █                █      \n";
                retorno += $"     █    ▄▀▀▀▀▀▀▄    █      \n";
                retorno += $"     █   ▀        ▀   █      \n";
                retorno += $"     █                █      \n";
                retorno += $"     ▀████████████████▀      \n";
            }

            Console.Write(retorno.ToUpper());
        }
        
        public Pokemon GetPokemon(int posicaoPokemon)
        {
            posicaoPokemon = (posicaoPokemon - 1);
            _pokemon.Id = pokedex2[posicaoPokemon].Id;
            _pokemon.Nome = pokedex2[posicaoPokemon].Nome;
            _pokemon.Status.Alimentacao = pokedex2[posicaoPokemon].Status.Alimentacao;
            _pokemon.Status.Humor = pokedex2[posicaoPokemon].Status.Humor;
            _pokemon.Status.Energia = pokedex2[posicaoPokemon].Status.Energia;
            _pokemon.Status.Saude = pokedex2[posicaoPokemon].Status.Saude;
            return _pokemon;
        }
    }
}
