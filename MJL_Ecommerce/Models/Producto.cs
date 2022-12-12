using System.ComponentModel.DataAnnotations.Schema;

namespace MJL_Ecommerce.Models
{
    public class Producto
    {
        public int Id { get; set; }

        public string NombreProducto { get; set; }

        public string Description { get; set; }

        public string Imagen { get; set; }
        //public string Ubicacion { get; set; }

        //public string Fabricantes { get; set; }

        public float Precio { get; set; }

        //Relaciones
        //public List<Origen> Origenes { get; set; }


        public List<Factura_Producto> Factura_Productos { get; set; }

        public int OrigenId { get; set; }
        [ForeignKey("OrigenId")]
        public Origen Origenes { get; set; }

        public int UbicacionId { get; set; }
        [ForeignKey("UbicacionId ")]
        public Ubicacion Ubicaciones { get; set; }

        public int FabricantesId { get; set; }
        [ForeignKey("FabricantesId")]
        public Fabricantes Fabricantess { get; set; }




    }
}
