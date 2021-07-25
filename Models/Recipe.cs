using System;

namespace RecipeBookAPI.Models
{
    public class Recipe 
    {
        public int Id { get; set; }
        public string title { get; set; }
        public int servingPersons { get; set; }
        public int time { get; set; }
        public string image { get; set; }
    }
}