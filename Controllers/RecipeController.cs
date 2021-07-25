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
        private readonly RecipeService _service;
        public RecipeController(RecipeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetAll()
        {
            var recipes = await _service.GetAll();
            return Ok(recipes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> Get(int id)
        {
            var recipe = await _service.Get(id);

            if (recipe == null)
                return NotFound();

            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Recipe recipe)
        {
            await _service.Add(recipe);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(Recipe recipe)
        {
            await _service.Update(recipe);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
