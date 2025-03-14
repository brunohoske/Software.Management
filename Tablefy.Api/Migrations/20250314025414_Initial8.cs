using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tablefy.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Orders",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderProducts",
                newName: "Total");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "OrderProducts",
                newName: "ReferenciaCombo");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "OrderProducts",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "OrderProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "FromCombo",
                table: "OrderProducts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsCombo",
                table: "OrderProducts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "OrderProducts",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Subtotal",
                table: "OrderProducts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "TempImage",
                table: "OrderProducts",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "FromCombo",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "IsCombo",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "Subtotal",
                table: "OrderProducts");

            migrationBuilder.DropColumn(
                name: "TempImage",
                table: "OrderProducts");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Orders",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "OrderProducts",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "ReferenciaCombo",
                table: "OrderProducts",
                newName: "CompanyId");
        }
    }
}
