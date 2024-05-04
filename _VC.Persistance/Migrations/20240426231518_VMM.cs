using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _VC.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class VMM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VirtualCompanyId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "virtualCompanies",
                columns: table => new
                {
                    VirtualCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_virtualCompanies", x => x.VirtualCompanyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_VirtualCompanyId",
                table: "AspNetUsers",
                column: "VirtualCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_virtualCompanies_VirtualCompanyId",
                table: "AspNetUsers",
                column: "VirtualCompanyId",
                principalTable: "virtualCompanies",
                principalColumn: "VirtualCompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_virtualCompanies_VirtualCompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "virtualCompanies");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_VirtualCompanyId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VirtualCompanyId",
                table: "AspNetUsers");
        }
    }
}
