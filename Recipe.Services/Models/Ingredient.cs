using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Services.Models
{
    public class Ingredient
    {
        public string IngredientName { get; set; }

        [Key]
        [ForeignKey("")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IngredientId { get; set; }

    }
}
