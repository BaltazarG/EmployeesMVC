using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class UserToCreateDto
    {
        [Required, StringLength(50)]
        public string Username { get; set; } = string.Empty;
        [Required, StringLength(50)]
        public string Email { get; set; } = string.Empty;
        [Required, StringLength(50)]
        public string Password { get; set; } = string.Empty;
    }
}
