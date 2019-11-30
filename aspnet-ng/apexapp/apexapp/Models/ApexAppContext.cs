using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apexapp.Models;

namespace apexapp.Models
{
    public class ApexAppContext : DbContext
    {

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<ItemPedido> ItensPedido { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<RamoAtividade> RamoAtividades { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        public ApexAppContext(DbContextOptions<ApexAppContext> options)
            :base(options)
        {
        }

    }
}
