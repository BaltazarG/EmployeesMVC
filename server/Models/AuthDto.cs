using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class AuthDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
