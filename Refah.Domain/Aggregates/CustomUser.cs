using Microsoft.AspNetCore.Identity;

namespace Refah.Domain.Aggregates
{
    public class CustomUser : IdentityUser
    {
        public string FName { get; set; }
        public string LName { get; set; }
    }
}
