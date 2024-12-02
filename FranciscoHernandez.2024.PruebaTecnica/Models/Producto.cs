using System.ComponentModel.DataAnnotations;

namespace FranciscoHernandez._2024.PruebaTecnica.Models
{
    public class Producto { 
        [Key] 
        public int Id { get; set; } 
        [Required][StringLength(100)]
        public string Nombre { get; set; } 
        [Required][Range(0, 9999.99)] 
        public decimal Precio { get; set; }
    }
    public class Categoria { 
        [Key] 
        public int Id { get; set; }
        [Required][StringLength(100)]
        public string Nombre { get; set; }
    }
}
