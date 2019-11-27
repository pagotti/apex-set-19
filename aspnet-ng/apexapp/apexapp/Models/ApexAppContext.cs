using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apexapp.Models
{
    public class ApexAppContext : DbContext
    {

        public DbSet<Produto> Produtos { get; set; }

        public ApexAppContext(DbContextOptions<ApexAppContext> options)
            :base(options)
        {

        }

        public static IConfiguration Configuration { get; internal set; }
    }
}


