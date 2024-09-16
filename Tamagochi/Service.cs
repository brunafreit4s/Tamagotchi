using System.Text.Json;

namespace Tamagochi
{
    public class Service
    {
        public async Task<string> GetMenu()
        {
            string url = "https://pokeapi.co/api/v2/pokemon/";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        PokemonResponse pokemon = JsonSerializer.Deserialize<PokemonResponse>(content);

                        string menu = "Escolha um Pokemon da lista a seguir para adoção: \n";
                        int count = 1;
                        foreach(var item in pokemon.Results)
                        {
                            menu += $"{count} - " + item.Nome + "\n";
                            count++;
                        }

                        return menu;
                    }
                    else
                    {
                        return $"Error: {response.StatusCode}";
                    }
                }
                catch (Exception ex)
                {
                   return $"Exception: {ex.Message}";      
                }
            }
        }
    
        public async Task<string> GetMascote(int opcao)
        {
            string url = $"https://pokeapi.co/api/v2/pokemon/{opcao}/";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Pokedex pokedex = JsonSerializer.Deserialize<Pokedex>(content);

                        string escolhido = $"\nNome do Pokemon: {pokedex.Nome.ToUpper()}," +
                                           $"\nAltura: {pokedex.Altura}," +
                                           $"\nPeso: {pokedex.Peso}," +
                                           $"\nHabilidades:\n";

                        foreach (var item in pokedex.Habilidades) {
                            escolhido += " - " + item.Habilidade.Nome.ToUpper() + "\n";
                        }

                        return escolhido;
                    }
                    else
                    {
                        return $"Error: {response.StatusCode}";
                    }
                }
                catch (Exception ex)
                {
                    return $"Exception: {ex.Message}";
                }
            }
        }
    }
}
