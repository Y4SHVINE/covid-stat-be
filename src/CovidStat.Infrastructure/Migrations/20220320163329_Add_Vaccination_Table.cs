using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CovidStat.Infrastructure.Migrations
{
    public partial class Add_Vaccination_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NIC",
                table: "UserProfiles",
                type: "character varying(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11);

            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileId",
                table: "Travels",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserProfileId",
                table: "ChronicDiseases",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NIC = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Vaccine = table.Column<string>(type: "text", nullable: false),
                    DateOfVaccination = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BatchNumber = table.Column<string>(type: "text", nullable: true),
                    Remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SideEffects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Detail = table.Column<string>(type: "text", nullable: false),
                    VaccinationId = table.Column<Guid>(type: "uuid", nullable: true),
                    VaccinationId2 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SideEffects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SideEffects_Vaccinations_VaccinationId",
                        column: x => x.VaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SideEffects_Vaccinations_VaccinationId2",
                        column: x => x.VaccinationId2,
                        principalTable: "Vaccinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Travels_UserProfileId",
                table: "Travels",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ChronicDiseases_UserProfileId",
                table: "ChronicDiseases",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_SideEffects_VaccinationId",
                table: "SideEffects",
                column: "VaccinationId");

            migrationBuilder.CreateIndex(
                name: "IX_SideEffects_VaccinationId2",
                table: "SideEffects",
                column: "VaccinationId2");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_NIC",
                table: "Vaccinations",
                column: "NIC",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChronicDiseases_UserProfiles_UserProfileId",
                table: "ChronicDiseases",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_UserProfiles_UserProfileId",
                table: "Travels",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChronicDiseases_UserProfiles_UserProfileId",
                table: "ChronicDiseases");

            migrationBuilder.DropForeignKey(
                name: "FK_Travels_UserProfiles_UserProfileId",
                table: "Travels");

            migrationBuilder.DropTable(
                name: "SideEffects");

            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropIndex(
                name: "IX_Travels_UserProfileId",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_ChronicDiseases_UserProfileId",
                table: "ChronicDiseases");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "ChronicDiseases");

            migrationBuilder.AlterColumn<string>(
                name: "NIC",
                table: "UserProfiles",
                type: "character varying(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(12)",
                oldMaxLength: 12);
        }
    }
}
