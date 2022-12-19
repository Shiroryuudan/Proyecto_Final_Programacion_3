
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MJL_Ecommerce.Models
{
    public class Factura_Producto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        

        [ForeignKey("ProductoId")]
        public int ProductoId { get; set; }
        
        
        [ForeignKey("FacturaId")]
        public int FacturaId { get; set; }

        //public Producto Productos { get; set; }
        //public Factura Facturas { get; set; }

        public virtual Factura IdFacturaNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
    }
}
