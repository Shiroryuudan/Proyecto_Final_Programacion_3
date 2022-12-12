using System.ComponentModel.DataAnnotations;

namespace MJL_Ecommerce.Models
{
    public class Origen
    {
        [Key]

        public int Id { get; set; }

        public string Lugar { get; set; }

        public List<Producto> Productos { get; set; }
    }
}
