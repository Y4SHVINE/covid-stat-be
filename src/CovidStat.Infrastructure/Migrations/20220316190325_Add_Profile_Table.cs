using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CovidStat.Infrastructure.Migrations
{
    public partial class Add_Profile_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Nickname = table.Column<string>(type: "text", nullable: true),
                    Individuality = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    HeroType = table.Column<int>(type: "integer", nullable: false),
                    Team = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NIC = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    DOB = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    MartialStatus = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    NIC = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChronicDiseases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Disease = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChronicDiseases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChronicDiseases_UserProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    DateOfDepature = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateOfArrival = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travels_UserProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "NIC", "Password", "Role" },
                values: new object[,]
                {
                    { new Guid("6648c89f-e894-42bb-94f0-8fd1059c86b4"), "user@boilerplate.com", "199551200015", "$2a$11$9OX/pEqxy56p5jvuZCuoGek3NfFzH7LBu0NjTLhzSM8zHExrg6gKu", "User" },
                    { new Guid("687d9fd5-2752-4a96-93d5-0f33a49913c6"), "admin@boilerplate.com", "199551200012", "$2a$11$ULAsyaSwBSghzwaeTII9OOIrxFaZl74nFVVsVBaV4u6t3G6t4JHhG", "Admin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChronicDiseases_ProfileId",
                table: "ChronicDiseases",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_ProfileId",
                table: "Travels",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChronicDiseases");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
