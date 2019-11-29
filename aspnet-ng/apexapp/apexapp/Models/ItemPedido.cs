using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apexapp.Models
{
    public class ItemPedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Pedido")]

        public int PedidoId { get; set; }


        public Pedido Pedido { get; set; }

        [Required]
        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }

        [Required]
        public decimal Quantidade { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        


    }
}
