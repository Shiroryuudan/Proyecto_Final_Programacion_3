using System.ComponentModel.DataAnnotations;

namespace MJL_Ecommerce.Models
{
    public class Factura
    {
        [Key]
        public int Id { get; set; }

        public string Codigo { get; set; }

        public string Productos { get; set; }

        public float total { get; set; }


        public List<Factura_Producto> Factura_Productos { get; set; }

    }
}
