using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPractice.Models
{
    public class RecipeModel
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int CookTime { get; set; }
        public string Description { get; set; } = null!;

        //[ForeignKey("AuthorId")]
        //public int AuthorId { get; set; }
        //public virtual AuthorModel Author { get; set; }
        //public virtual List<RecipeIngredientModel> Recipes { get; set; }
    }
}
