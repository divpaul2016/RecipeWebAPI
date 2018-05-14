using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipe.Services.Models
{
    [Table("DishType")]
    public class DishType
    {
        //public DishType()
        //{
        //    this.RecipeDishTypes = new HashSet<RecipeDishType>();
        //}
        public string DishTypeName { get; set; }
        [Key]
        [ForeignKey("")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DishTypeId { get; set; }

        //public virtual ICollection<RecipeDishType> RecipeDishTypes { get; set; }
    }
}
