using System.Text.Json.Serialization;

namespace Tamagochi
{
    public class Pokedex
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public string? Nome { get; set; }

        [JsonPropertyName("abilities")]
        public List<Abilities> Habilidades { get; set; }

        [JsonPropertyName("height")]
        public int Altura { get; set; }

        [JsonPropertyName("weight")]
        public int Peso { get; set; }
    }

    public class Abilities
    {
        [JsonPropertyName("ability")]
        public Ability Habilidade { get; set; }        
    }

    public class Ability
    {
        [JsonPropertyName("name")]
        public string Nome { get; set; }
    }

    public class PokemonResult
    {
        [JsonPropertyName("name")]
        public string Nome { get; set; }
    }

    public class PokemonResponse
    {
        [JsonPropertyName("results")]
        public List<PokemonResult> Results { get; set; }

        public int StatusCode { get; set; }
        public string MessageError { get; set; }
    }
}
