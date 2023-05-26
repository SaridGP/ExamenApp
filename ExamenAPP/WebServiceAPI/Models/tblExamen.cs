using System.ComponentModel.DataAnnotations;

namespace WebServiceAPI.Models
{
    public class tblExamen
    {
        [Key]
        public int idExamen { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
