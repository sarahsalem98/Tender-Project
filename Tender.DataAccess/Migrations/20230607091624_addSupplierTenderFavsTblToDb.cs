using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tender.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addSupplierTenderFavsTblToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SupplierTenderFavourites",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    TenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierTenderFavourites", x => new { x.TenderId, x.SupplierId });
                    table.ForeignKey(
                        name: "FK_SupplierTenderFavourites_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierTenderFavourites_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierTenderFavourites_SupplierId",
                table: "SupplierTenderFavourites",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplierTenderFavourites");
        }
    }
}
