

using Tamagochi.Models.DTO;

namespace Tamagochi.Controllers
{
    public class TamagotchiController : MenuController
    {
        public readonly string Titulo = "\n\r\n                                      ███████████████████████████████▀██████████████████████████\r\n" +
                  "                                      █─▄─▄─██▀▄─██▄─▀█▀─▄██▀▄─██─▄▄▄▄█─▄▄─█─▄─▄─█─▄▄▄─█─█─█▄─▄█\r\n" +
                  "                                      ███─████─▀─███─█▄█─███─▀─██─██▄─█─██─███─███─███▀█─▄─██─██\r\n" +
                  "                                      ▀▀▄▄▄▀▀▄▄▀▄▄▀▄▄▄▀▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▄▄▀▀▄▄▄▀▀▄▄▄▄▄▀▄▀▄▀▄▄▄▀\n\n\n";

        
        private UtilController _utilController = new UtilController();
        TamagotchiDto _tamagochiDto = new TamagotchiDto();

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
                            GetMenuAdocao();

                            int codPokemon = 0;
                            if (int.TryParse(Console.ReadLine(), out codPokemon))
                            {
                                try
                                {
                                    // Consulta nome do pokemon selecionado
                                    GetMenuSecundario(codPokemon);
                                }
                                catch
                                {
                                    Console.WriteLine("Não foi possível encontrar o Pokemon informado, tente novamente!");
                                    GetMenuPrincipal();
                                    break;
                                }

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
                                                GetSobrePokemon(codPokemon);
                                                // Consulta nome do pokemon selecionado
                                                GetMenuSecundario(codPokemon);
                                                break;
                                            case 2:
                                                Console.WriteLine($"\n{NomeUsuario}, Mascote adotado com sucesso, o ovo está chocando...\n");
                                                Console.WriteLine("              ");
                                                Console.WriteLine("    ▄████▄    ");
                                                Console.WriteLine("  ▄████████▄  ");
                                                Console.WriteLine("  ██████████  ");
                                                Console.WriteLine("  ▀████████▀  ");
                                                Console.WriteLine("     ▀██▀     ");
                                                Console.WriteLine("              ");
                                                //Guarda Pokemon adotado na Pokedex
                                                PutPokedex(codPokemon);
                                                GetMenuSecundario(codPokemon);
                                                break;
                                            case 3:
                                                continuarMenuSecundario = 0;
                                                GetMenuPrincipal();
                                                break;
                                            default:
                                                _utilController.RetornaOpcaoInvalida();
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        _utilController.RetornaOpcaoInvalida();
                                    }
                                }
                            }
                            else
                            {
                                _utilController.RetornaOpcaoInvalida();
                            }

                            break;
                        case 2:
                            //Retorna Pokemons adotados
                            GetPokedex();

                            int posicaoPokemon = 0;

                            if (int.TryParse(Console.ReadLine(), out posicaoPokemon))
                            {
                                GetMenuSobrePokemon(posicaoPokemon);

                                int continuarMenuPokemons = 1;

                                while (continuarMenuPokemons > 0)
                                {
                                    int opcaoEscolhida2 = 0;
                                    if (int.TryParse(Console.ReadLine(), out opcaoEscolhida2))
                                    {
                                        switch (opcaoEscolhida2)
                                        {
                                            case 1:
                                                _tamagochiDto.MostrarStatus();
                                                GetMenuSobrePokemon(posicaoPokemon);
                                                break;
                                            case 2:
                                                _tamagochiDto.Alimentar();
                                                GetMenuSobrePokemon(posicaoPokemon);
                                                break;
                                            case 3:
                                                _tamagochiDto.Brincar();
                                                GetMenuSobrePokemon(posicaoPokemon);
                                                break;
                                            case 4:
                                                _tamagochiDto.Descansar();
                                                GetMenuSobrePokemon(posicaoPokemon);
                                                break;
                                            case 5:
                                                _tamagochiDto.DarCarinho();
                                                GetMenuSobrePokemon(posicaoPokemon);
                                                break;
                                            case 6:
                                                GetMenuPrincipal();
                                                continuarMenuPokemons = 0;
                                                break;
                                            default:
                                                Console.WriteLine("Escolha inválida. Tente novamente.\n");
                                                break;
                                        }
                                    }
                                }
                            }
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
                    _utilController.RetornaOpcaoInvalida();
                }
            }
        }
    }
}
