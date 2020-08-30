using System.ComponentModel.DataAnnotations;

namespace RefreshJwtAuthentication.Model
{
    public class TokenRequestModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
