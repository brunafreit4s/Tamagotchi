// See https://aka.ms/new-console-template for more information
using Tamagochi;

Service servico = new Service();
Console.WriteLine(servico.Titulo);
Console.WriteLine("Qual seu nome?");

servico.NomeUsuario = Console.ReadLine();

Console.WriteLine(servico.GetMenuPrincipal());

int opcao = 0;

while (true)
{
    if (int.TryParse(Console.ReadLine(), out opcao))
    {
        switch (opcao)
        {
            case 1:
                // Apresenta menu de pokemons disponíveis para adoção
                Console.WriteLine(servico.GetMenuAdocao());

                int codPokemon = 0;
                if (int.TryParse(Console.ReadLine(), out codPokemon))
                {
                    // Consulta nome do pokemon selecionado
                    Console.WriteLine(servico.GetMenuSecundario(codPokemon));

                    int opcaoPokemon = 0;
                    if (int.TryParse(Console.ReadLine(), out opcaoPokemon))
                    {
                        switch (opcaoPokemon)
                        {
                            case 1:
                                // Consulta sobre o pokemon selecionado (peso, altura, nome, etc.)
                                Console.WriteLine(servico.GetSobrePokemon(codPokemon));
                                break;
                            case 2:
                                Console.WriteLine($"{servico.NomeUsuario}, Mascote adotado com sucesso, o ovo está chocando...");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Escolha inválida. Tente novamente.");
                    }
                }
                else
                {
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                }
                break;
            case 2:
                Console.WriteLine("Ainda não disponível");
                //Console.WriteLine(servico.GetMeusPokemons);
                break;
            case 3:
                Console.WriteLine("Saindo...");
                break;
            default:
                Console.WriteLine();
                break;
        }
    }
    else
    {
        Console.WriteLine("Escolha inválida. Tente novamente.");
    }
}