using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Services.Models
{
    public class RecipeCookingStyle
    {
        [Key,Column(Order = 0)]
        public int RecipeCookingStyleId { get; set; }

        [Key, Column(Order = 1)]
        public int RecipeId { get; set; }

        [Key, Column(Order = 2)]
        public int CookingStyleId { get; set; }

        [ForeignKey("CookingStyleId")]
        public CookingStyle CookingStyle { get; set; }

        [ForeignKey("RecipeId")]
        public  FoodRecipe FoodRecipe { get; set; }
    }
}
