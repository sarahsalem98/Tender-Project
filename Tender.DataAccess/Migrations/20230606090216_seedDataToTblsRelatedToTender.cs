using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tender.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedDataToTblsRelatedToTender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AttachmentTypes",
                columns: new[] { "Id", "CreatedAt", "CreatedBY", "Name_Ar", "Name_En", "UpdatedAt", "UpdatedBY" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "كراسة الشروط ", "refrence condition pdf", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "كراسة التاميين الابتدائى", "intial insurance pdf", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "صور تابعه للمناقصة", "tender pics", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "OffersExaminationCommittes",
                columns: new[] { "Id", "CreatedAt", "CreatedBY", "Name_Ar", "Name_En", "UpdatedAt", "UpdatedBY" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "لجنه فحص العرووض الحكومية", "public offer committe", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "لجنه فحص العرووض الخاصة", "private offer committe", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "لجنه فحص العرووض للوزارة الكهربا", "electical offer committe", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "OpeningEnvelopeCommittees",
                columns: new[] { "Id", "CreatedAt", "CreatedBY", "Name_Ar", "Name_En", "UpdatedAt", "UpdatedBY" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "لجنه فتح المظارييف الحكومية", "public committe", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "لجنه فتح المظارييف الخاصة", "private committe", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "لجنه فتح المظارييف للوزارة الكهربا", "electical committe", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "TechnicalSides",
                columns: new[] { "Id", "CreatedAt", "CreatedBY", "Name_Ar", "Name_En", "UpdatedAt", "UpdatedBY" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "الجهه الفنية التابعه لوزارة الاتصالات", "communication technical side", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "الجهه الفنية التابعه لوزارة الكهربا", "electrical technical side", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "الجهه الفنية التابعه لوزارة الطاقه", "power technical side", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AttachmentTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AttachmentTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AttachmentTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OffersExaminationCommittes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OffersExaminationCommittes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OffersExaminationCommittes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OpeningEnvelopeCommittees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OpeningEnvelopeCommittees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OpeningEnvelopeCommittees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TechnicalSides",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TechnicalSides",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TechnicalSides",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
