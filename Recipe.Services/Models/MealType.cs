using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Services.Models
{
    public class MealType
    {
        //public MealType()
        //{
        //    this.RecipeMealTypes = new HashSet<RecipeMealType>();
        //}
        public string MealTypeName { get; set; }

        [Key]
        [ForeignKey("")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MealTypeId { get; set; }

        //public virtual ICollection<RecipeMealType> RecipeMealTypes { get; set; }
    }
}
