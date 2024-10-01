using Tamagochi.Controllers;

namespace Tamagochi.Views
{
    public class TamagochiView
    {
        public void Start()
        {
            TamagochiController tamagochiController = new TamagochiController();

            Console.WriteLine(tamagochiController.Titulo + "\nQual seu nome?");

            tamagochiController.NomeUsuario = Console.ReadLine();

            Console.WriteLine(tamagochiController.GetMenuPrincipal(tamagochiController.NomeUsuario));

            tamagochiController.GetStart();
        }
    }
}
