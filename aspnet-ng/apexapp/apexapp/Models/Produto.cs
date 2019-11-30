using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apexapp.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(300)]
        public string Descricao { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [ForeignKey("Fornecedor")]
        public int? FornecedorId { get; set; }
        
        public Fornecedor Fornecedor { get; set; }

    }
}
