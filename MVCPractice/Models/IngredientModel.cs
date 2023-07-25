using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCPractice.Models
{
    public class IngredientModel
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [ForeignKey("RecipeId")]
        public int RecipeId { get; set; }
        public virtual RecipeModel? Recipe { get; set; }

    }
}
