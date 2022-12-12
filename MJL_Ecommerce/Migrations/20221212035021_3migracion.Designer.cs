﻿// <auto-generated />
using MJL_Ecommerce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MJL_Ecommerce.Migrations
{
    [DbContext(typeof(ECommerceDbContextcs))]
    [Migration("20221212035021_3migracion")]
    partial class _3migracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MJL_Ecommerce.Models.Fabricantes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fabricante")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fabricantes");
                });

            modelBuilder.Entity("MJL_Ecommerce.Models.Factura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Productos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("total")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("MJL_Ecommerce.Models.Factura_Producto", b =>
                {
                    b.Property<int>("FacturaId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("FacturaId", "ProductoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("Factura_Productos");
                });

            modelBuilder.Entity("MJL_Ecommerce.Models.Origen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Lugar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Origenes");
                });

            modelBuilder.Entity("MJL_Ecommerce.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FabricantesId")
                        .HasColumnType("int");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrigenId")
                        .HasColumnType("int");

                    b.Property<float>("Precio")
                        .HasColumnType("real");

                    b.Property<int>("UbicacionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FabricantesId");

                    b.HasIndex("OrigenId");

                    b.HasIndex("UbicacionId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("MJL_Ecommerce.Models.Ubicacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Lugar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ubicaciones");
                });

            modelBuilder.Entity("MJL_Ecommerce.Models.Factura_Producto", b =>
                {
                    b.HasOne("MJL_Ecommerce.Models.Factura", "Factura")
                        .WithMany("Factura_Productos")
                        .HasForeignKey("FacturaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MJL_Ecommerce.Models.Producto", "Producto")
                        .WithMany("Factura_Productos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Factura");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("MJL_Ecommerce.Models.Producto", b =>
                {
                    b.HasOne("MJL_Ecommerce.Models.Fabricantes", "Fabricantess")
                        .WithMany("Productos")
                        .HasForeignKey("FabricantesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MJL_Ecommerce.Models.Origen", "Origenes")
                        .WithMany("Productos")
                        .HasForeignKey("OrigenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MJL_Ecommerce.Models.Ubicacion", "Ubicaciones")
                        .WithMany("Productos")
                        .HasForeignKey("UbicacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fabricantess");

                    b.Navigation("Origenes");

                    b.Navigation("Ubicaciones");
                });

            modelBuilder.Entity("MJL_Ecommerce.Models.Fabricantes", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("MJL_Ecommerce.Models.Factura", b =>
                {
                    b.Navigation("Factura_Productos");
                });

            modelBuilder.Entity("MJL_Ecommerce.Models.Origen", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("MJL_Ecommerce.Models.Producto", b =>
                {
                    b.Navigation("Factura_Productos");
                });

            modelBuilder.Entity("MJL_Ecommerce.Models.Ubicacion", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
