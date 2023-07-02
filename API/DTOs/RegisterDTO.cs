using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$")]
        public string Email  { get; set; }
        [Required]
        // [RegularExpression("(?=.*\\d)(?=.[a-z])(?=.[A-Z]).{4,8}$", ErrorMessage="Passord Must Complex")]
        public string Password { get; set; }    
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public string  UserName { get; set; }
    }
}