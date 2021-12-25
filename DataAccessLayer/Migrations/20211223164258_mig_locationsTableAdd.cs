using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_locationsTableAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAdmins");

            migrationBuilder.DropColumn(
                name: "ContactAdress",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactMapLocation",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "Contacts");

            migrationBuilder.CreateTable(
                name: "ContactLocations",
                columns: table => new
                {
                    ContactLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactMapLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactLocations", x => x.ContactLocationId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactLocations");

            migrationBuilder.AddColumn<string>(
                name: "ContactAdress",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactMapLocation",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserAdmins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminStatus = table.Column<bool>(type: "bit", nullable: false),
                    AdminTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAdmins", x => x.AdminId);
                });
        }
    }
}
