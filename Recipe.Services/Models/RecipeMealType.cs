using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Services.Models
{
    public  class RecipeMealType
    {
        public int RecipeMealTypeId { get; set; }
        public int RecipeId { get; set; }
        public int MealTypeId { get; set; }

       
        [Column(Order = 0)]
        [ForeignKey("RecipeId")]
        public virtual FoodRecipe FoodRecipe { get; set; }

        [Column(Order = 1)]
        [ForeignKey("MealTypeId")]
        public virtual MealType MealType { get; set; }
    }
}
