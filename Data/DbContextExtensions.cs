using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using restore.Data.Entities;

namespace restore.Data
{
    public static class DbContextExtensions
    {
        public static UserManager<AppUser> UserManager { get; set; }

        public static void EnsureSeeded(this ApplicationContext context)
        {
            if (UserManager.FindByEmailAsync("rhinoseros@mail.ru").GetAwaiter().GetResult() == null)
            {
                var user = new AppUser
                {
                    FirstName = "German",
                    LastName = "Prompt",
                    UserName = "rhinoseros@mail.ru",
                    Email = "rhinoseros@mail.ru",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };
                UserManager.CreateAsync(user, "c29_cwNK").GetAwaiter().GetResult();
            }
        }
    }
}
