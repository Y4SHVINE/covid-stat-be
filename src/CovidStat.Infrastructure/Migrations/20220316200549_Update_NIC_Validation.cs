using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CovidStat.Infrastructure.Migrations
{
    public partial class Update_NIC_Validation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NIC",
                table: "UserProfiles",
                type: "character varying(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_Email",
                table: "UserProfiles",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_NIC",
                table: "UserProfiles",
                column: "NIC",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_Email",
                table: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_UserProfiles_NIC",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "NIC",
                table: "UserProfiles",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(11)",
                oldMaxLength: 11);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "NIC", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("6648c89f-e894-42bb-94f0-8fd1059c86b4"), "user@boilerplate.com", "199551200015", "$2a$11$9OX/pEqxy56p5jvuZCuoGek3NfFzH7LBu0NjTLhzSM8zHExrg6gKu", "User" },
                    { new Guid("687d9fd5-2752-4a96-93d5-0f33a49913c6"), "admin@boilerplate.com", "199551200012", "$2a$11$ULAsyaSwBSghzwaeTII9OOIrxFaZl74nFVVsVBaV4u6t3G6t4JHhG", "Admin" }
                });
        }
    }
}
