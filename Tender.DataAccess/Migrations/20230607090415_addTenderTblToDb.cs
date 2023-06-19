using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tender.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addTenderTblToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    GovernmentId = table.Column<int>(type: "int", nullable: true),
                    TechnicalSideId = table.Column<int>(type: "int", nullable: true),
                    OpeningEnvelopeCommitteeId = table.Column<int>(type: "int", nullable: true),
                    OffersExaminationCommitteId = table.Column<int>(type: "int", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false,defaultValue:1),
                    CategoryType = table.Column<int>(type: "int", nullable: false),
                    TarsiaType = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TermsOfReferenceValue = table.Column<int>(type: "int", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryInsuranceValue = table.Column<int>(type: "int", nullable: false),
                    PlaceOfOpeningEnvelops = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManualReceivingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SumbittingOffersPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutionPlace = table.Column<int>(type: "int", nullable: false),
                    ActivityDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InquiriesDeadline = table.Column<DateTime>(type: "Date", nullable: false),
                    RecievingOffersDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpeningEnvelposDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOffersDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpectingResultsDate = table.Column<DateTime>(type: "Date", nullable: false),
                    PublishingDate = table.Column<DateTime>(type: "Date", nullable: true),
                    ApprovedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBY = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenders_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete:ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tenders_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tenders_Governments_GovernmentId",
                        column: x => x.GovernmentId,
                        principalTable: "Governments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tenders_OffersExaminationCommittes_OffersExaminationCommitteId",
                        column: x => x.OffersExaminationCommitteId,
                        principalTable: "OffersExaminationCommittes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tenders_OpeningEnvelopeCommittees_OpeningEnvelopeCommitteeId",
                        column: x => x.OpeningEnvelopeCommitteeId,
                        principalTable: "OpeningEnvelopeCommittees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Tenders_TechnicalSides_TechnicalSideId",
                        column: x => x.TechnicalSideId,
                        principalTable: "TechnicalSides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_ActivityId",
                table: "Tenders",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_CityId",
                table: "Tenders",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_GovernmentId",
                table: "Tenders",
                column: "GovernmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_OffersExaminationCommitteId",
                table: "Tenders",
                column: "OffersExaminationCommitteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_OpeningEnvelopeCommitteeId",
                table: "Tenders",
                column: "OpeningEnvelopeCommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_TechnicalSideId",
                table: "Tenders",
                column: "TechnicalSideId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenders");
        }
    }
}
