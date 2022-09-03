using StackOverflow.Infrastructure.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Infrastructure.Seeds
{
    public static class ApplicationUserSeed
    {
        public static ApplicationUser[] Users
        {
            get
            {
                var applicationUser = new ApplicationUser
                {
                    Id = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                    DisplayName = "Nayeem Rahman",
                    Email = "nayeemrahman@gmail.com",
                    NormalizedEmail = "NAYEEMRAHMAN@GMAIL.COM",
                    LockoutEnabled = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true
                };

                return new ApplicationUser[]
                {
                    applicationUser
                };
            }
        }
    }
}
