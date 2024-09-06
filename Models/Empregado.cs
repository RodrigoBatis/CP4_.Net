using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Empresa.Models
{
    [Table("Empregados_PX")]
    public class Empregado
    {
        [Key]
        public int EmpId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Genero Genero { get; set; }
        public int DepId { get; set; }

        public string FotoUrl { get; set; } = string.Empty ;

    }
}
