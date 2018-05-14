using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Services.Models
{
    [Table("RecipeCuisine")]
    public class RecipeCuisine
    {
        public RecipeCuisine()
        {
            Cuisine = new Cuisine();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecipeCuisineId { get; set; }
        public int RecipeId { get; set; }
        public int CuisineId { get; set; }

        [ForeignKey("CuisineId")]
        [Column(Order = 1)]
        public  Cuisine Cuisine { get; set; }

        [ForeignKey("RecipeId")]
        [Column(Order = 0)]
        public  FoodRecipe FoodRecipe { get; set; }
    }
}
