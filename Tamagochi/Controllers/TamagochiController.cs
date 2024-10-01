

namespace Tamagochi.Controllers
{
    public class TamagochiController : MenuController
    {
        public readonly string Titulo = "\n\r\n                                      ███████████████████████████████▀████████████████████\r\n" +
                  "                                      █─▄─▄─██▀▄─██▄─▀█▀─▄██▀▄─██─▄▄▄▄█─▄▄─█─▄▄▄─█─█─█▄─▄█\r\n" +
                  "                                      ███─████─▀─███─█▄█─███─▀─██─██▄─█─██─█─███▀█─▄─██─██\r\n" +
                  "                                      ▀▀▄▄▄▀▀▄▄▀▄▄▀▄▄▄▀▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▄▄▀▄▄▄▄▄▀▄▀▄▀▄▄▄▀\n\n\n";

        public string NomeUsuario = "";
        private UtilController _utilController = new UtilController();

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
                            Console.WriteLine(GetMenuAdocao(NomeUsuario));

                            int codPokemon = 0;
                            if (int.TryParse(Console.ReadLine(), out codPokemon))
                            {
                                try
                                {
                                    // Consulta nome do pokemon selecionado
                                    Console.WriteLine(GetMenuSecundario(NomeUsuario, codPokemon));
                                }
                                catch
                                {
                                    Console.WriteLine("Não foi possível encontrar o Pokemon informado, tente novamente!");
                                    Console.WriteLine(GetMenuPrincipal(NomeUsuario));
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
                                                Console.WriteLine(GetSobrePokemon(codPokemon));
                                                // Consulta nome do pokemon selecionado
                                                Console.WriteLine(GetMenuSecundario(NomeUsuario, codPokemon));
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
                                                Console.WriteLine(GetMenuSecundario(NomeUsuario, codPokemon));
                                                break;
                                            case 3:
                                                continuarMenuSecundario = 0;
                                                Console.WriteLine(GetMenuPrincipal(NomeUsuario));
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
                            Console.WriteLine(GetPokedex());

                            int posicaoPokemon = 0;

                            if (int.TryParse(Console.ReadLine(), out posicaoPokemon))
                            {
                                Console.WriteLine(GetMenuSobrePokemon(NomeUsuario, posicaoPokemon));

                                int continuarMenuPokemons = 1;

                                while (continuarMenuPokemons > 0)
                                {
                                    int opcaoEscolhida2 = 0;
                                    if (int.TryParse(Console.ReadLine(), out opcaoEscolhida2))
                                    {
                                        switch (opcaoEscolhida2)
                                        {
                                            case 1:
                                                Console.WriteLine(GetMenuStatusPokemon(posicaoPokemon));
                                                Console.WriteLine(GetMenuSobrePokemon(NomeUsuario, posicaoPokemon));
                                                break;
                                            case 2:
                                                AlimentarMascote(posicaoPokemon);
                                                Console.WriteLine("Mascote alimentado =^-^=\n");
                                                Console.WriteLine(GetMenuSobrePokemon(NomeUsuario, posicaoPokemon));
                                                break;
                                            case 3:
                                                BrincarMascote(posicaoPokemon);
                                                Console.WriteLine("Mascote se divertiu bastante *_*");
                                                Console.WriteLine(GetMenuSobrePokemon(NomeUsuario, posicaoPokemon));
                                                break;
                                            case 4:
                                                DormirMascote(posicaoPokemon);
                                                Console.WriteLine("Mascote dormiu bastante z_z");
                                                Console.WriteLine(GetMenuSobrePokemon(NomeUsuario, posicaoPokemon));
                                                break;
                                            case 5:
                                                Console.WriteLine(GetMenuPrincipal(NomeUsuario));
                                                continuarMenuPokemons = 0;
                                                break;
                                            default:
                                                Console.WriteLine("Escolha inválida. Tente novamente.");
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
