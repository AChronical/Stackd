using System.ComponentModel.DataAnnotations;

namespace Stackd.Entities
{
    //Anica Janjic 991799177
    //this class creates the components needed for a user to create an account so they can access their account.
    public class User
    {

        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Users name is required.")]
        [StringLength(20, ErrorMessage = "Users name cannot exceed 20 characters.")]
        [RegularExpression(@"^[^0-9]*$", ErrorMessage = "Users name must not include any digits.")]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, ErrorMessage = "Password cannot exceed 50 characters.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Phone number must follow the format '123-456-7890'.")]
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
    }
}
