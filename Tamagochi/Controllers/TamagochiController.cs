using System.Runtime.CompilerServices;
using System.Text.Json;
using Tamagochi.Models;

namespace Tamagochi.Controllers
{
    public class TamagochiController
    {
        public readonly string Titulo = "\n\r\n                                      ███████████████████████████████▀████████████████████\r\n" +
                  "                                      █─▄─▄─██▀▄─██▄─▀█▀─▄██▀▄─██─▄▄▄▄█─▄▄─█─▄▄▄─█─█─█▄─▄█\r\n" +
                  "                                      ███─████─▀─███─█▄█─███─▀─██─██▄─█─██─█─███▀█─▄─██─██\r\n" +
                  "                                      ▀▀▄▄▄▀▀▄▄▀▄▄▀▄▄▄▀▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▄▄▀▄▄▄▄▄▀▄▀▄▀▄▄▄▀\n\n\n";

        public string NomeUsuario = "";

        private async Task<PokemonResponse> GetListPokemon()
        {
            string url = "https://pokeapi.co/api/v2/pokemon/";

            using (HttpClient client = new HttpClient())
            {
                PokemonResponse pokemon = new PokemonResponse();

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        pokemon = JsonSerializer.Deserialize<PokemonResponse>(content);

                        return pokemon;
                    }
                    else
                    {
                        pokemon.StatusCode = 404;
                        pokemon.MessageError = "Lista do menu não encontrada!";
                        return pokemon;
                    }
                }
                catch (Exception ex)
                {
                    pokemon.StatusCode = 500;
                    pokemon.MessageError = "Ocorreu um erro no servidor! - Erro: 1.01";
                    return pokemon;
                }
            }
        }

        public string FormataOpcoes(Task<PokemonResponse> pokemon)
        {
            int count = 1;
            string menu = "";

            foreach (var item in pokemon.Result.Results)
            {
                menu += $"{count} - " + item.Nome + "\n";
                count++;
            }

            return menu;
        }

        public string GetMenuPrincipal()
        {
            string retorno = "\n--------------------------------- Menu ------------------------------------------\n";
            retorno += $"{NomeUsuario} você deseja:\n";
            retorno += "1 - Adotar um mascote virtual.\n2 - Ver seus mascotes.\n3 - Sair.\n";
            return retorno.ToUpper();
        }

        public string GetMenuAdocao()
        {
            Task<PokemonResponse> response = GetListPokemon();
            string opcoesFormatada = "\n--------------------------------- Adotar um Mascote ------------------------------------------\n";
            opcoesFormatada += $"{NomeUsuario} escolha uma espécie:\n";
            opcoesFormatada += FormataOpcoes(response);

            return opcoesFormatada.ToUpper();
        }

        public string GetMenuSecundario(int codPokemon)
        {
            var response = GetPokemon(codPokemon);
            string retorno = "\n--------------------------------- ------------------- ------------------------------------------\n";
            retorno += $"{NomeUsuario} você deseja:\n";
            retorno += $"1 - Saber mais sobre {response.Result.Nome}.\n2 - Adotar {response.Result.Nome}.\n3 - Voltar.\n";

            return retorno.ToUpper();
        }

        private async Task<Pokemon> GetPokemon(int opcao)
        {
            string url = $"https://pokeapi.co/api/v2/pokemon/{opcao}/";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string content = await response.Content.ReadAsStringAsync();
                Pokemon pokedex = JsonSerializer.Deserialize<Pokemon>(content);

                return pokedex;
            }
        }

        public string GetSobrePokemon(int opcao)
        {
            Task<Pokemon> pokedex = GetPokemon(opcao);

            string escolhido = $"\nNome do Pokemon: {pokedex.Result.Nome.ToUpper()}," +
                                           $"\nAltura: {pokedex.Result.Altura}," +
                                           $"\nPeso: {pokedex.Result.Peso}," +
                                           $"\nHabilidades:\n";

            foreach (var item in pokedex.Result.Habilidades)
            {
                escolhido += " - " + item.Habilidade.Nome.ToUpper() + "\n";
            }

            return escolhido;
        }

        public void GetStart()
        {
            int continuarJogando = 1;

            while (continuarJogando > 0)
            {
                int opcaoEscolhida = 0;
                if (int.TryParse(Console.ReadLine(), out opcaoEscolhida))
                {
                    switch (opcaoEscolhida)
                    {
                        case 1:
                            // Apresenta menu de pokemons disponíveis para adoção
                            Console.WriteLine(GetMenuAdocao());

                            int codPokemon = 0;
                            if (int.TryParse(Console.ReadLine(), out codPokemon))
                            {
                                // Consulta nome do pokemon selecionado
                                Console.WriteLine(GetMenuSecundario(codPokemon));

                                int continuarMenuSecundario = 1;
                                int opcaoEscolhida2 = 0;
                                while (continuarMenuSecundario > 0)
                                {
                                    if (int.TryParse(Console.ReadLine(), out opcaoEscolhida2))
                                    {
                                        switch (opcaoEscolhida2)
                                        {
                                            case 1:
                                                // Consulta sobre o pokemon selecionado (peso, altura, nome, etc.)
                                                Console.WriteLine(GetSobrePokemon(codPokemon));
                                                // Consulta nome do pokemon selecionado
                                                Console.WriteLine(GetMenuSecundario(codPokemon));
                                                break;
                                            case 2:
                                                Console.WriteLine($"\n{NomeUsuario}, Mascote adotado com sucesso, o ovo está chocando...");
                                                Console.WriteLine("──────────────");
                                                Console.WriteLine("────▄████▄────");
                                                Console.WriteLine("──▄████████▄──");
                                                Console.WriteLine("──██████████──");
                                                Console.WriteLine("──▀████████▀──");
                                                Console.WriteLine("─────▀██▀─────");
                                                Console.WriteLine("──────────────");
                                                // Consulta nome do pokemon selecionado
                                                Console.WriteLine(GetMenuSecundario(codPokemon));
                                                break;
                                            case 3:
                                                continuarMenuSecundario = 0;
                                                Console.WriteLine(GetMenuPrincipal());
                                                break;
                                            default:
                                                Console.WriteLine("Escolha inválida. Tente novamente.");
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Escolha inválida. Tente novamente.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Escolha inválida. Tente novamente.");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Ainda não disponível...");
                            //Console.WriteLine(servico.GetPokedex);
                            break;
                        case 3:
                            Console.WriteLine("\nObrigado por jogar! Até a próxima!");
                            Console.WriteLine("\nSaindo...");
                            continuarJogando = 0;
                            break;
                        default:
                            Console.WriteLine("Escolha inválida. Tente novamente.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                }
            }
        }
    }
}
