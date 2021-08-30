using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RecipeBookAPI.Models;
using RecipeBookAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBookAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeService _recipeService;
        private readonly ApiRecipeService _apiRecipeService;
        public RecipeController(RecipeService service, ApiRecipeService apiService)
        {
            _recipeService = service;
            _apiRecipeService = apiService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetAll()
        {
            var recipes = await _recipeService.GetAll();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> Get(int id)
        {
            var recipe = await _recipeService.Get(id);

            if (recipe == null)
                return NotFound();

            return Ok(recipe);
        }

        [HttpGet("/random/{tag}")]
        public async Task<ActionResult<Recipe>> GetRandomRecipe(string tag)
        {
            var recipe = await _apiRecipeService.GetRandomRecipes(tag);
            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Recipe recipe)
        {
            await _recipeService.Add(recipe);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Recipe recipe)
        {
            await _recipeService.Update(recipe);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _recipeService.Delete(id);
            return Ok();
        }
    }
}
