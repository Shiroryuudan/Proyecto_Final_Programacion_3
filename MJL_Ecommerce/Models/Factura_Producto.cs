
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MJL_Ecommerce.Models
{
    public class Factura_Producto
    {
        [Key]
        //public int Id { get; set; }

        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public Producto Producto { get; set; }

        public int FacturaId { get; set; }
        [ForeignKey("FacturaId")]
        public Factura Factura { get; set; }
    }
}
