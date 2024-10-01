using Tamagochi.Models;

namespace Tamagochi.Controllers
{
    public class PokedexController : PokemonController
    {
        public Pokedex pokedex = new Pokedex();
        private Pokemon _pokemon = new Pokemon();

        public void PutPokedex(int codPokemon)
        {            
            var response = GetPokemonApi(codPokemon);

            if (response != null)
            {
                if (pokedex.Pokemons.Count > 0)
                {
                    for (int i = 0; i < pokedex.Pokemons.Count; i++)
                    {
                        if (pokedex.Pokemons[i].Id != response.Result.Id)
                        {
                            pokedex.Pokemons.Add(response.Result);                            
                        }
                    }
                }
                else
                {
                    pokedex.Pokemons.Add(response.Result);
                }
            }
        }

        public string GetPokedex()
        {
            string retorno = "\n---------------------------------------- Pokedex ----------------------------------------\n";

            if (pokedex.Pokemons.Count != 0)
            {
                string textPokemon = (pokedex.Pokemons.Count > 1) ? "Pokemons" : "Pokemon";

                retorno += $"\nVocê tem {pokedex.Pokemons.Count} {textPokemon}";

                for (int i = 0; i < pokedex.Pokemons.Count; i++)
                {
                    retorno += $"\n{i + 1} - {pokedex.Pokemons[i].Nome}";
                }
                return retorno.ToUpper();
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

            return retorno.ToUpper();
        }

        public Pokemon GetPokemon(int posicaoPokemon)
        {
            posicaoPokemon = (posicaoPokemon - 1);
            // melhorar com automapper
            _pokemon.Id = pokedex.Pokemons[posicaoPokemon].Id;
            _pokemon.Nome = pokedex.Pokemons[posicaoPokemon].Nome;
            _pokemon.Status.Fome = pokedex.Pokemons[posicaoPokemon].Status.Fome;
            _pokemon.Status.Humor = pokedex.Pokemons[posicaoPokemon].Status.Humor;
            _pokemon.Status.Sono = pokedex.Pokemons[posicaoPokemon].Status.Sono;
            return _pokemon;
        }

        public void BrincarMascote(int posicaoPokemon)
        {
            posicaoPokemon = (posicaoPokemon - 1);

            pokedex.Pokemons[posicaoPokemon].Status.Fome--;
            pokedex.Pokemons[posicaoPokemon].Status.Humor++;
            pokedex.Pokemons[posicaoPokemon].Status.Sono--;
        }

        public void DormirMascote(int posicaoPokemon)
        {
            posicaoPokemon = (posicaoPokemon - 1);

            pokedex.Pokemons[posicaoPokemon].Status.Fome--;
            pokedex.Pokemons[posicaoPokemon].Status.Humor++;
            pokedex.Pokemons[posicaoPokemon].Status.Sono++;
        }

        public void AlimentarMascote(int posicaoPokemon)
        {
            posicaoPokemon = (posicaoPokemon - 1);

            pokedex.Pokemons[posicaoPokemon].Status.Fome++;
            pokedex.Pokemons[posicaoPokemon].Status.Humor++;
            pokedex.Pokemons[posicaoPokemon].Status.Sono--;
        }
    }
}
