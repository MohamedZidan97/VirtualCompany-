using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _VC.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class VM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "virtualMachines",
                columns: table => new
                {
                    VirtualMachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HDD = table.Column<double>(type: "float", nullable: false),
                    SSD = table.Column<double>(type: "float", nullable: false),
                    RAM = table.Column<double>(type: "float", nullable: false),
                    VirtualCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_virtualMachines", x => x.VirtualMachineId);
                    table.ForeignKey(
                        name: "FK_virtualMachines_virtualCompanies_VirtualCompanyId",
                        column: x => x.VirtualCompanyId,
                        principalTable: "virtualCompanies",
                        principalColumn: "VirtualCompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_virtualMachines_VirtualCompanyId",
                table: "virtualMachines",
                column: "VirtualCompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "virtualMachines");
        }
    }
}
