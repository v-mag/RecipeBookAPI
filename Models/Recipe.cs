namespace RecipeBookAPI.Models
{
    public class Recipe 
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public int readyInMinutes { get; set; }
        public int servings { get; set; }
        public int aggregateLikes { get; set; }
        public string instructions { get; set; }
        public int healthScore { get; set; }
    }
}