using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tender.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changeTenderTblProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimaryInsuranceValue",
                table: "Tenders");

            migrationBuilder.DropColumn(
                name: "TermsOfReferenceValue",
                table: "Tenders");

            migrationBuilder.AlterColumn<string>(
                name: "ExecutionPlace",
                table: "Tenders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ExecutionPlace",
                table: "Tenders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrimaryInsuranceValue",
                table: "Tenders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TermsOfReferenceValue",
                table: "Tenders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
