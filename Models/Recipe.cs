using Newtonsoft.Json.Linq;
using System;

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

        public void fromJToken(JToken item)
        {
            Id = Convert.ToInt32(item["id"]);
            title = item["title"].ToString();
            readyInMinutes = Convert.ToInt32(item["readyInMinutes"]);
            servings = Convert.ToInt32(item["servings"]);
            image = item["image"] == null ? "" : item["image"].ToString();
            aggregateLikes = Convert.ToInt32(item["aggregateLikes"]);
            healthScore = Convert.ToInt32(item["healthScore"]);
            instructions = item["instructions"].ToString();
        }
    }
}