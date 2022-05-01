using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CovidStat.Infrastructure.Migrations
{
    public partial class Update_Vaccination_NIC_Field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vaccinations_NIC",
                table: "Vaccinations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_NIC",
                table: "Vaccinations",
                column: "NIC",
                unique: true);
        }
    }
}
