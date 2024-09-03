using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empresa.Models
{
    [Table("Departamentos_PX")]
    public class Departamento
    {
        [Key]
        public int DepId { get; set; }
        public string DepNome { get; set; }
    }
}
