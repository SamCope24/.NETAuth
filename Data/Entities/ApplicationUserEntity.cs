using Microsoft.AspNetCore.Identity;

namespace Auth.Data.Entities
{
    public class ApplicationUserEntity : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Custom { get; set; }
    }
}