using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CovidStat.Infrastructure.Migrations
{
    public partial class Add_Location_Field_To_UserProfile_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "UserProfiles",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "UserProfiles");
        }
    }
}
