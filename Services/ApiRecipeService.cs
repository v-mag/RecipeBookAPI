using Newtonsoft.Json.Linq;
using RecipeBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RecipeBookAPI.Services
{
    public class ApiRecipeService
    {
        private HttpClient client = new HttpClient();
        
        public ApiRecipeService()
        {

        }

        public async Task<List<Recipe>> GetRandomRecipes(string tag)
        {
            var recipes = new List<Recipe>();
            var response = await client.GetAsync($"https://api.spoonacular.com/recipes/random?number=5&limitLicense=true&tags={tag}&apiKey=19034eb5fa2340ed804cf62cf769d775");
            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var array = JObject.Parse(content);

                foreach (var item in array["recipes"])
                {
                    var recipe = new Recipe();
                    recipe.fromJToken(item);

                    recipes.Add(recipe);
                }
            }

            return recipes;
        }
    }
}
