using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apexapp.Models
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Data")]
        public DateTime Data { get; set; }

        [Display(Name = "Total")]
        public decimal Total { get; set; }

        [Required]
        [Display(Name = "Forma de Pagamento")]
        public FormaPagamento Forma { get; set; }

        public StatusPedido Status { get; set; }

        [ForeignKey("Cliente")]
        public int? ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public List<ItemPedido> Itens { get; set; }

    }
}
