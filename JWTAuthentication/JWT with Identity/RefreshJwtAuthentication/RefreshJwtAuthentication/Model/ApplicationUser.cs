using Microsoft.AspNetCore.Identity;
using RefreshJwtAuthentication.Entities;
using System.Collections.Generic;

namespace RefreshJwtAuthentication.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
