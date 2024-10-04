using Tamagochi.Models;
using Tamagochi.Models.DTO;

namespace Tamagochi.Controllers
{
    public class PokedexController : PokemonController
    {
        public List<TamagotchiDto> tamagotchiDtos = new List<TamagotchiDto>();
        private Pokemon _pokemon = new Pokemon();

        public void PutPokedex(int codPokemon)
        {
            var response = GetPokemonApi(codPokemon).Result;
            TamagotchiDto tamagotchi = new TamagotchiDto();

            if (response != null)
            {
                var exists = tamagotchiDtos.Any(item => item.Id == response.Id);

                if (!exists)
                {
                    tamagotchi.AtualizarPropriedades(response);
                    tamagotchiDtos.Add(tamagotchi);
                }
            }
        }       
        
        public void GetPokedex()
        {
            string retorno = "\n---------------------------------------- Pokedex ----------------------------------------\n";

            if (tamagotchiDtos.Count > 0)
            {
                string textPokemon = (tamagotchiDtos.Count > 1) ? "Pokemons:" : "Pokemon:";

                retorno += $"\nVocê tem {tamagotchiDtos.Count} {textPokemon}\n";

                for (int i = 0; i < tamagotchiDtos.Count; i++)
                {
                    retorno += $"\n{i + 1} - {tamagotchiDtos[i].Nome}";
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

            Console.WriteLine(retorno.ToUpper());
        }

        public bool TryPokedex()
        {
            if (tamagotchiDtos.Count > 0) return true; else return false;
        }

        public Pokemon GetPokemonNaPokedex(int posicaoPokemon)
        {
            posicaoPokemon = (posicaoPokemon - 1);
            _pokemon.Nome = tamagotchiDtos[posicaoPokemon].Nome;
            _pokemon.Status.Alimentacao = tamagotchiDtos[posicaoPokemon].Alimentacao;
            _pokemon.Status.Humor = tamagotchiDtos[posicaoPokemon].Humor;
            _pokemon.Status.Energia = tamagotchiDtos[posicaoPokemon].Energia;
            _pokemon.Status.Saude = tamagotchiDtos[posicaoPokemon].Saude;
            return _pokemon;
        }
    }
}
