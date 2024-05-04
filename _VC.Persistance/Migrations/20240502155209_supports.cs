using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _VC.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class supports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "supports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VirtualCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_supports_virtualCompanies_VirtualCompanyId",
                        column: x => x.VirtualCompanyId,
                        principalTable: "virtualCompanies",
                        principalColumn: "VirtualCompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_supports_VirtualCompanyId",
                table: "supports",
                column: "VirtualCompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "supports");
        }
    }
}
