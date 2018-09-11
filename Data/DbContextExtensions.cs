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
                AddProducts(context);
            }
        }

        private static void AddProducts(ApplicationContext context)
        {
            if (context.Products.Any() == false)
            {
                var products = new List<Product>()
                {
                    new Product
                    {
                        Name = "Латте",
                        Slug = "latte",
                        Description = "Кофе латте схож по названию с напитком латте макиато. Основное отличие латте макиато заключается в том, что при его приготовлении кофе добавляется в молоко (а не молоко в кофе, как в латте) и напиток, таким образом, получается слоистым: слой молока, слой эспрессо, слой вспененного молока. Латте даёт более сильный вкус кофе",
                        Thumbnail = "https://via.placeholder.com/100x150",
                        Volume = 385,
                        Price = 95,
                    },
                    new Product
                    {
                        Name = "Эспрессо",
                        Slug = "espresso",
                        Description = "Эсперссо - метод приготовления кофе путём прохождения горячей воды (около 90 °C) под давлением 9 бар через фильтр с молотым кофе.",
                        Thumbnail = "https://via.placeholder.com/100x150",
                        Volume = 35,
                        Price = 60,
                    }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
