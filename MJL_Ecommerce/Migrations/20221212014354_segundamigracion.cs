using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MJL_Ecommerce.Migrations
{
    public partial class segundamigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Factura_Productos_Id",
                table: "Factura_Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Factura_Productos",
                table: "Factura_Productos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Factura_Productos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factura_Productos",
                table: "Factura_Productos",
                columns: new[] { "FacturaId", "ProductoId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Factura_Productos",
                table: "Factura_Productos");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Factura_Productos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Factura_Productos_Id",
                table: "Factura_Productos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Factura_Productos",
                table: "Factura_Productos",
                columns: new[] { "FacturaId", "ProductoId", "Id" });
        }
    }
}
