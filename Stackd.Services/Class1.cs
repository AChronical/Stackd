using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stackd.Services
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "User's name is required.")]
        [StringLength(100, ErrorMessage = "User's name cannot exceed 100 characters.")]
        [RegularExpression(@"^[^0-9]*$", ErrorMessage = "User's name must not include any digits.")]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "User's email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }


    }
}
