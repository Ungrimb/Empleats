using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Empleados.Models
{
    public class EmpleatContext : DbContext
    {

        public EmpleatContext(DbContextOptions<EmpleatContext> options)
            : base(options)
        {
        }

        public DbSet<Empleat> Empleats { get; set; }

    }
}
