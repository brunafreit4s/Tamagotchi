﻿using System.Text.Json;
using Tamagochi.Models;

namespace Tamagochi.Controllers
{
    public class PokemonController
    {
        public async Task<PokemonResponse> GetListPokemon()
        {
            string url = "https://pokeapi.co/api/v2/pokemon/";

            using (HttpClient client = new HttpClient())
            {
                PokemonResponse pokemon = new PokemonResponse();

                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        pokemon = JsonSerializer.Deserialize<PokemonResponse>(content);

                        return pokemon;
                    }
                    else
                    {
                        pokemon.StatusCode = 404;
                        pokemon.MessageError = "Lista do menu não encontrada!";
                        return pokemon;
                    }
                }
                catch (Exception ex)
                {
                    pokemon.StatusCode = 500;
                    pokemon.MessageError = "Ocorreu um erro no servidor! - Erro: 1.01";
                    return pokemon;
                }
            }
        }

        public async Task<Pokemon> GetPokemonApi(int opcao)
        {
            string url = $"https://pokeapi.co/api/v2/pokemon/{opcao}/";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string content = await response.Content.ReadAsStringAsync();
                Pokemon pokedex = JsonSerializer.Deserialize<Pokemon>(content);

                return pokedex;
            }
        }

        public void GetSobrePokemon(int codPokemon)
        {
            Task<Pokemon> pokedex = GetPokemonApi(codPokemon);

            string escolhido = $"\nNome do Pokemon: {pokedex.Result.Nome}," +
                                           $"\nAltura: {pokedex.Result.Altura}," +
                                           $"\nPeso: {pokedex.Result.Peso}," +
                                           $"\nHabilidades:\n";

            if(pokedex.Result.Habilidades != null)
            {
                foreach (var item in pokedex.Result.Habilidades)
                {
                    escolhido += " - " + item.Habilidade.Nome + "\n";
                }
            }
            else
            {
                escolhido += " - Não tem habilidade\n";
            }

            Console.Write(escolhido.ToUpper());
        }
        
    }
}
