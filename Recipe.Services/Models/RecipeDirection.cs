using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Services.Models
{
    public class RecipeDirection
    {
        [Key]
        public int RecipeDirectionId { get; set; }
        public int RecipeId { get; set; }
        public int StepNo { get; set; }
        public string Instructions { get; set; }

        [ForeignKey("RecipeId")]
        public FoodRecipe FoodRecipe { get; set; }
    }
}
