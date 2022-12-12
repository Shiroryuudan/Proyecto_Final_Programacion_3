using System.ComponentModel.DataAnnotations;

namespace MJL_Ecommerce.Models
{
    public class Fabricantes
    {
        [Key]
        public int Id { get; set; }

        public string Fabricante { get; set; }

        public string Description { get; set; }

        public List<Producto> Productos { get; set; }

    }
}
