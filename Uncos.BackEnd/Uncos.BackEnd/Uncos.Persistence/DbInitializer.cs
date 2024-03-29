using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uncos.Domain;

namespace Uncos.Persistence
{
    public class DbInitializer
    {
        public static  void Initialize(UncosDbContext context)
        { 
        
            if(!context.Database.EnsureCreated())
            {
                if (!context.Categories.Any())
                {
                    context.Categories.Add(new Category { Name = "IT" });
                    context.Categories.Add(new Category { Name = "Games" });
                    context.Categories.Add(new Category { Name = "Films" });
                    context.Categories.Add(new Category { Name = "Sport" });

                }
                if (!context.Tags.Any())
                {
                    context.Tags.Add(new Tag { Name = "Funny" });
                    context.Tags.Add(new Tag { Name = "Informative" });
                    context.Tags.Add(new Tag { Name = "Education" });
                    context.Tags.Add(new Tag { Name = "Relax" });
                }
                context.SaveChanges();
            }

        }
    }
}
