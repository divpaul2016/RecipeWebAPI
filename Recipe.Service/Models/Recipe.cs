using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipe.Service.Models
{
    public class Recipe
    {
        public string FoodName { get; set; }
        public int PrepTime { get; set; }
        public int ReadyIn { get; set; }
        public int CookingTime { get; set; }
        public string MainIngredient { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Direction> Directions { get; set; }
        public List<string> MealType { get; set; }
        public List<string> DishType { get; set; }
        public List<string> CookingStyle { get; set; }
        public List<string> Cuisine { get; set; }
        public string CreatedBy { get; set; }
    }

    public class Ingredient
    {
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
    }

    public class Direction
    {
        public int Step { get; set; }
        public string Instruction { get; set; }
    }
}