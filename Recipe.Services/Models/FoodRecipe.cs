using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Services.Models
{
    [Table("FoodRecipe")]
    public class FoodRecipe
    {
        public FoodRecipe()
        {
            RecipeCookingStyles = new List<RecipeCookingStyle>();
            RecipeCuisines = new List<RecipeCuisine>();
            RecipeDishTypes = new List<RecipeDishType>();
            RecipeIngredients = new List<RecipeIngredient>();
            RecipeMealTypes = new List<RecipeMealType>();
        }

        [Key]
        [ForeignKey("")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeId { get; set; }
        public string FoodName { get; set; }
        public int PrepTime { get; set; }
        public int ReadyIn { get; set; }
        public int CookingTime { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public List<RecipeCookingStyle> RecipeCookingStyles { get; set; }
        public List<RecipeMealType> RecipeMealTypes { get; set; }
        public List<RecipeCuisine> RecipeCuisines { get; set; }
        public List<RecipeDishType> RecipeDishTypes { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; }
    }
}