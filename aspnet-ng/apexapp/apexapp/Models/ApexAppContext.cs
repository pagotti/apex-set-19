using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apexapp.Models
{
    public class ApexAppContext : DbContext
    {

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<ItemPedido> ItensPedidos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public ApexAppContext(DbContextOptions<ApexAppContext> options)
            :base(options)
                {

                }
        
    }
}
