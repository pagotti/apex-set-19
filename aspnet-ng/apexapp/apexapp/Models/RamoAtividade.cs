using System.ComponentModel.DataAnnotations;

namespace apexapp.Models
{
    public class RamoAtividade
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

    }
}