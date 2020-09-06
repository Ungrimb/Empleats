using Empleados.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empleados.Models
{
    public class SeeData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EmpleatContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<EmpleatContext>>()))
            {
                // Look for any movies.
                if (context.Empleats.Any())
                {
                    return;   // DB has been seeded
                }

                context.Empleats.AddRange(
                    new Empleat
                    {
                        Nom = "Ismael",
                        Cognom = "Anaya",
                        Càrrec = "CTO",
                        Sou = "40000"
                    },
                    new Empleat
                    {
                        Nom = "Patricia",
                        Cognom = "Costa",
                        Càrrec = "CEO",
                        Sou = "60000"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
