using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apexapp.Models
{
    public class Produto
    {   [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(300)]
        public string Descrição { get; set; }

        [Required]
        [Display(Name = "Preço")]        
        public decimal Preço { get; set; }
    }
}
