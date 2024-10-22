using Tamagochi.Models;

namespace Tamagochi.Controllers
{
    public class PokedexController : PokemonController
    {
        private List<Pokemon> _pokemons = new List<Pokemon>();
        private Pokemon _pokemon = new Pokemon();

        public void PutPokedex(int codPokemon)
        {
            _pokemon = new Pokemon();
            var response = GetPokemonApi(codPokemon).Result;
        
            if (response != null)
            {
                var exists = _pokemons.Any(item => item.Id == response.Id);

                if (!exists)
                {
                    AtualizarPropriedades(response);
                    _pokemons.Add(_pokemon);
                } 
            }
        }

        public void GetPokedex()
        {
            string retorno = "\n---------------------------------------- Pokedex ----------------------------------------\n";

            if (_pokemons.Count > 0)
            {
                string textPokemon = (_pokemons.Count > 1) ? "Pokemons:" : "Pokemon:";

                retorno += $"\nVocê tem {_pokemons.Count} {textPokemon}\n";

                for (int i = 0; i < _pokemons.Count; i++)
                {
                    retorno += $"\n{i + 1} - {_pokemons[i].Nome}";
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
            if (_pokemons.Count > 0) return true; else return false;
        }

        public Pokemon GetPokemonNaPokedex(int posicaoPokemon)
        {
            posicaoPokemon--;
            _pokemon = _pokemons[posicaoPokemon];
            return _pokemon;
        }

        public void AtualizarPropriedades(Pokemon pokemonDetails)
        {
            _pokemon.Id = pokemonDetails.Id;
            _pokemon.Nome = pokemonDetails.Nome;
            _pokemon.Altura = pokemonDetails.Altura;
            _pokemon.Peso = pokemonDetails.Peso;
            _pokemon.Habilidades = pokemonDetails.Habilidades.Select(a => new Abilities { Habilidade = a.Habilidade }).ToList();
        }

        public void Alimentar(int codPokemon)
        {
            _pokemon.Status.Alimentacao = Math.Min(_pokemon.Status.Alimentacao + 2, 10);
            _pokemon.Status.Energia = Math.Max(_pokemon.Status.Energia - 1, 0);
            
            Console.WriteLine("Pokémon Alimentado!!! =^-^=\n");
        }

        public void Brincar(int codPokemon)
        {
            _pokemon.Status.Humor = Math.Min(_pokemon.Status.Humor + 3, 10);
            _pokemon.Status.Energia = Math.Max(_pokemon.Status.Energia - 2, 0);
            _pokemon.Status.Alimentacao = Math.Max(_pokemon.Status.Alimentacao - 1, 0);

            Console.WriteLine("Pokémon se divertiu bastante *_*\n");
        }

        public void Descansar(int codPokemon)
        {
            _pokemon.Status.Energia = Math.Min(_pokemon.Status.Energia + 4, 10);
            _pokemon.Status.Humor = Math.Max(_pokemon.Status.Humor - 1, 0);

            Console.WriteLine("Pokémon dormiu bastante z_z\n");
        }

        public void DarCarinho(int codPokemon)
        {
            _pokemon.Status.Humor = Math.Min(_pokemon.Status.Humor + 2, 10);
            _pokemon.Status.Saude = Math.Min(_pokemon.Status.Saude + 1, 10);

            Console.WriteLine("Pokémon está se sentindo amado! <3");
        }

        public void MostrarStatus(int codPokemon)
        {
            Console.WriteLine($"Status do Pokémon: ");
            Console.WriteLine($"Alimentação: {_pokemon.Status.Alimentacao}");
            Console.WriteLine($"Humor: {_pokemon.Status.Humor}");
            Console.WriteLine($"Energia: {_pokemon.Status.Energia}");
            Console.WriteLine($"Saúde: {_pokemon.Status.Saude}");
        }
    }
}
