using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ViolinShop.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserEmail { get; set; }
    }
}
