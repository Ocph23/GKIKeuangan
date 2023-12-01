using Microsoft.AspNetCore.Identity;

namespace MainApp
{
    public class ApplicationUser :IdentityUser
    {
        public ApplicationUser()
        {
                
        }

        public ApplicationUser(string userName) : base(userName)
        {
        }

        public string? Name { get; set; }
    }
}

