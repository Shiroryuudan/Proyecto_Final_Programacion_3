using Microsoft.EntityFrameworkCore;
using MJL_Ecommerce.Models;
using System.Reflection.Emit;

namespace MJL_Ecommerce.Data
{
    public class ECommerceDbContextcs:DbContext
    {
        public ECommerceDbContextcs(DbContextOptions<ECommerceDbContextcs>options) : base(options)
        {


        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Factura_Producto> Factura_Productos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Fabricantes> Fabricantes { get; set; }
        public DbSet<Origen> Origenes { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {




            modelBuilder.Entity<Factura_Producto>(entity =>
            {
                entity.ToTable("ProductosFactura");

                entity.Property(e => e.FacturaId).HasColumnName("idFactura");

                entity.Property(e => e.ProductoId).HasColumnName("idProducto");

                entity.HasOne(d => d.IdFacturaNavigation)
                    .WithMany(p => p.Factura_Productos)
                    .HasForeignKey(d => d.FacturaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductosFactura_Factura");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.Factura_Productos)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductosFactura_Productos");


                //OnModelCreatingPartial(modelBuilder);
                base.OnModelCreating(modelBuilder);
            });

        }
        
        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder) { }


    }
}
