using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HelloDocker.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ProductDbContext>();
                EnsurePopulated(context);
            }
        }

        public static void EnsurePopulated(ProductDbContext context)
        {
            System.Console.WriteLine("Applying migrations");
            context.Database.Migrate();

            if(!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product() { Name = "Abbey Road", Category = "Classic Rock", Price=25},
                    new Product() { Name = "(What's the story) Morning Glory", Category="Britpop", Price=10}
                    );

                context.SaveChanges();
            } else
            {
                System.Console.WriteLine("Db had data already");
            }
        }
    }
}
