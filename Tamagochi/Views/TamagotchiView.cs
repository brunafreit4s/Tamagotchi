using Tamagochi.Controllers;

namespace Tamagochi.Views
{
    public class TamagotchiView
    {
        public void Start()
        {
            TamagotchiController tamagochiController = new TamagotchiController();

            Console.WriteLine(tamagochiController.Titulo + "\nQual seu nome?");

            tamagochiController.NomeUsuario = Console.ReadLine();

            tamagochiController.GetMenuPrincipal();
            tamagochiController.GetStart();
        }
    }
}
