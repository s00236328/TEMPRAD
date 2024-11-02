using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace lab5p1.Models
{
    public class MUser
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "First Name must be at least 5 characters long")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MinLength(4, ErrorMessage = "Last Name must be at least 4 characters long")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Title Title { get; set; }

        [Required]
        [MinLength(100, ErrorMessage = "Biography must be at least 100 characters long")]
        public string Biography { get; set; } = string.Empty;

        [Range(0, 200, ErrorMessage = "Age must be between 0 and 200")]
        [Column("age_of_user")]
        public int Age { get; set; }
    }

    public enum Title
    {
        Mr,
        Ms,
        Mrs,
        Dr,
        Prof
    }
}
