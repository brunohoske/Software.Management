using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tablefy.Api.Migrations
{
    /// <inheritdoc />
    public partial class initial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComboSelectionGroups");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComboSelectionGroups",
                columns: table => new
                {
                    SelectionGroupId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComboSelectionGroups", x => new { x.SelectionGroupId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ComboSelectionGroups_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComboSelectionGroups_SelectionGroups_SelectionGroupId",
                        column: x => x.SelectionGroupId,
                        principalTable: "SelectionGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ComboSelectionGroups_ProductId",
                table: "ComboSelectionGroups",
                column: "ProductId");
        }
    }
}
