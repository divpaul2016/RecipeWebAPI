using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Services.Models
{
    public class RecipeDishType
    {
        public int RecipeDishTypeId { get; set; }
        public int RecipeId { get; set; }
        public int DishTypeId { get; set; }

        [ForeignKey("DishTypeId")]
        [Column(Order = 1)]
        public  DishType DishType { get; set; }

        [ForeignKey("RecipeId")]
        [Column(Order = 0)]
        public  FoodRecipe FoodRecipe { get; set; }
    }

}
