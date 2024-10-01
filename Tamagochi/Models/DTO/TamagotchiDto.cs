namespace Tamagochi.Models.DTO
{
    public class TamagotchiDto : Pokemon
    {
        public TamagotchiDto()
        {
            var rand = new Random();
            Status.Alimentacao = rand.Next(11);
            Status.Humor = rand.Next(11);
            Status.Energia = rand.Next(11);
            Status.Saude = rand.Next(11);
        }

        public void AtualizarPropriedades(Pokemon pokemonDetails)
        {
            Nome = pokemonDetails.Nome;
            Altura = pokemonDetails.Altura;
            Peso = pokemonDetails.Peso;
            Habilidades = pokemonDetails.Habilidades.Select(a => new Abilities { Habilidade = a.Habilidade }).ToList();
        }

        public void Alimentar()
        {
            Status.Alimentacao = Math.Min(Status.Alimentacao + 2, 10);
            Status.Energia = Math.Max(Status.Energia - 1, 0);

            Console.WriteLine("Pokémon Alimentado!!! =^-^=\n");
        }

        public void Brincar()
        {
            Status.Humor = Math.Min(Status.Humor + 3, 10);
            Status.Energia = Math.Max(Status.Energia - 2, 0);
            Status.Alimentacao = Math.Max(Status.Alimentacao - 1, 0);

            Console.WriteLine("Pokémon se divertiu bastante *_*\n");

        }

        public void Descansar()
        {
            Status.Energia = Math.Min(Status.Energia + 4, 10);
            Status.Humor = Math.Max(Status.Humor - 1, 0);

            Console.WriteLine("Pokémon dormiu bastante z_z\n");

        }

        public void DarCarinho()
        {
            Status.Humor = Math.Min(Status.Humor + 2, 10);
            Status.Saude = Math.Min(Status.Saude + 1, 10);

            Console.WriteLine("Pokémon está se sentindo amado! <3");

        }

        public void MostrarStatus()
        {
            Console.WriteLine("Status do Pokémon:");
            Console.WriteLine($"Alimentação: {Status.Alimentacao}");
            Console.WriteLine($"Humor: {Status.Humor}");
            Console.WriteLine($"Energia: {Status.Energia}");
            Console.WriteLine($"Saúde: {Status.Saude}");
        }
    }
}
