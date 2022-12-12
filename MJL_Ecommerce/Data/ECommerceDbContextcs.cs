using Microsoft.EntityFrameworkCore;
using MJL_Ecommerce.Models;

namespace MJL_Ecommerce.Data
{
    public class ECommerceDbContextcs:DbContext
    {
        public ECommerceDbContextcs(DbContextOptions<ECommerceDbContextcs>options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factura_Producto>().HasKey(am => new
            {
                am.FacturaId,
                am.ProductoId,
                //am.Id
            }

            );
            //modelBuilder.Entity<Factura_Producto>().HasAlternateKey(m => m.Id);
            modelBuilder.Entity<Factura_Producto>().HasOne(m => m.Producto).WithMany(am => am.Factura_Productos).HasForeignKey(m => m.ProductoId);

            modelBuilder.Entity<Factura_Producto>().HasOne(m => m.Factura).WithMany(am => am.Factura_Productos).HasForeignKey(m => m.FacturaId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Factura_Producto> Factura_Productos { get; set; }

        public DbSet<Factura> Facturas { get; set; }

        public DbSet<Fabricantes> Fabricantes { get; set; }

        public DbSet<Origen> Origenes { get; set; }

        public DbSet<Ubicacion>Ubicaciones { get; set; }




    }
}
