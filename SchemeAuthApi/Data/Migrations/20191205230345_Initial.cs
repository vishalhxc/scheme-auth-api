using Microsoft.EntityFrameworkCore.Migrations;

namespace SchemeAuthApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    username = table.Column<string>(maxLength: 20, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: false),
                    fullname = table.Column<string>(name: "full-name", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
