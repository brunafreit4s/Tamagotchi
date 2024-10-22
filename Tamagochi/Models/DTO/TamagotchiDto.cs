namespace Tamagochi.Models.DTO
{
    public class TamagotchiDto
    {
        public int Id { get; set; }
        public int Alimentacao { get; private set; }
        public int Humor { get; private set; }
        public int Energia { get; private set; }
        public int Saude { get; private set; }
        public int Altura { get; set; }
        public int Peso { get; set; }
        public string Nome { get; set; }
        public List<Abilities> Habilidades { get; set; }       

        public TamagotchiDto()
        {
            //var rand = new Random();
            Alimentacao = 10;
            Humor = 10;
            Energia = 10;
            Saude = 10;
        }

        public void AtualizarPropriedades(Pokemon pokemonDetails)
        {
            Id = pokemonDetails.Id;
            Nome = pokemonDetails.Nome;
            Altura = pokemonDetails.Altura;
            Peso = pokemonDetails.Peso;
            Habilidades = pokemonDetails.Habilidades.Select(a => new Abilities { Habilidade = a.Habilidade }).ToList();
        }

        public void Alimentar()
        {
            Alimentacao = Math.Min(Alimentacao + 2, 10);
            Energia = Math.Max(Energia - 1, 0);

            Console.WriteLine("Pokémon Alimentado!!! =^-^=\n");
        }

        public void Brincar()
        {
            Humor = Math.Min(Humor + 3, 10);
            Energia = Math.Max(Energia - 2, 0);
            Alimentacao = Math.Max(Alimentacao - 1, 0);

            Console.WriteLine("Pokémon se divertiu bastante *_*\n");

        }

        public void Descansar()
        {
            Energia = Math.Min(Energia + 4, 10);
            Humor = Math.Max(Humor - 1, 0);

            Console.WriteLine("Pokémon dormiu bastante z_z\n");

        }

        public void DarCarinho()
        {
            Humor = Math.Min(Humor + 2, 10);
            Saude = Math.Min(Saude + 1, 10);

            Console.WriteLine("Pokémon está se sentindo amado! <3");

        }

        public void MostrarStatus()
        {   
            Console.WriteLine($"Status do Pokémon: ");
            Console.WriteLine($"Alimentação: {Alimentacao}");
            Console.WriteLine($"Humor: {Humor}");
            Console.WriteLine($"Energia: {Energia}");
            Console.WriteLine($"Saúde: {Saude}");
        }
    }
}
