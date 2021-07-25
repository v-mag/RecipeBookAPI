using Microsoft.EntityFrameworkCore;
using RecipeBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBookAPI.Services
{
    public class RecipeService
    {
        private readonly RecipeContext _context;

        public RecipeService(RecipeContext context)
        {
            _context = context;
        }

        public async Task<Recipe> Get(int id) => await _context.Recipes.FindAsync(id);

        public async Task<IEnumerable<Recipe>> GetAll() => await _context.Recipes.ToListAsync();

        public async Task Add(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);

            if (recipe is null)
                throw new NullReferenceException();
            
            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
        }


        public async Task Update(Recipe recipe)
        {
            var recipeToUpdate = await _context.Recipes.FindAsync(recipe.Id);

            if (recipeToUpdate == null)
                throw new NullReferenceException();

            recipeToUpdate = recipe;
            await _context.SaveChangesAsync();
        }
    }
}