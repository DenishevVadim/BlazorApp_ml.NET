using Microsoft.AspNetCore.Identity;

namespace BlazorAppML.Data
{
    public class ApplicationUser : IdentityUser
    {
        public Prediction Prediction;
    }
}