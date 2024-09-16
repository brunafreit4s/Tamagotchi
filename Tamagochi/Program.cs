// See https://aka.ms/new-console-template for more information

using Tamagochi;

Console.WriteLine("\n\r\n                                      ███████████████████████████████▀████████████████████\r\n" +
                  "                                      █─▄─▄─██▀▄─██▄─▀█▀─▄██▀▄─██─▄▄▄▄█─▄▄─█─▄▄▄─█─█─█▄─▄█\r\n" +
                  "                                      ███─████─▀─███─█▄█─███─▀─██─██▄─█─██─█─███▀█─▄─██─██\r\n" +
                  "                                      ▀▀▄▄▄▀▀▄▄▀▄▄▀▄▄▄▀▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▄▄▀▄▄▄▄▄▀▄▀▄▀▄▄▄▀\n\n\n");

Service servico = new Service();
var opcoesMenu = servico.GetMenu();

Console.WriteLine(opcoesMenu.Result);

var opcaoEscolhida = Console.ReadLine();

int escolhido;
if (int.TryParse(opcaoEscolhida, out escolhido))
{
    // Sucesso: a conversão foi feita, agora pode usar o valor convertido.
    var mascote = servico.GetMascote(escolhido);
    Console.WriteLine(mascote.Result);
}
else
{
    Console.WriteLine("Você não digitou um número!");
}