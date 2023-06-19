using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tender.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addTenderAttachmentTblToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TenderAttachments",
                columns: table => new
                {
                    TenderId = table.Column<int>(type: "int", nullable: false),
                    AttachmentTypeId = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderAttachments", x => new { x.TenderId, x.AttachmentTypeId });
                    table.ForeignKey(
                        name: "FK_TenderAttachments_AttachmentTypes_AttachmentTypeId",
                        column: x => x.AttachmentTypeId,
                        principalTable: "AttachmentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenderAttachments_Tenders_TenderId",
                        column: x => x.TenderId,
                        principalTable: "Tenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TenderAttachments_AttachmentTypeId",
                table: "TenderAttachments",
                column: "AttachmentTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TenderAttachments");
        }
    }
}
