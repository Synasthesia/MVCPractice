using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace MVCPractice.Models
{
    public class AuthorModel
    {
        //Authors should have a unique ID, a Name, Bio, and E-mail
        //Create a DbSet to store the authors in. Seed the data
        //Add migration and update the database
        //Create AuthorController, implementing CRUD functions and create corresponding views

        [Key]
        public int? Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Bio { get; set; }
        public string Email { get; set; } = null!;



    }
}
