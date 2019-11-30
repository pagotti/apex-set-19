using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace apexapp.Models
{
    public class Fornecedor
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        [Display(Name = "Ramo de Atividade")]
        [ForeignKey("RamoAtividade")]
        public int RamoAtividadeId { get; set; }

        public RamoAtividade RamoAtividade { get; set; }

    }
}
