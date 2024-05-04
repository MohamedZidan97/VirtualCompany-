using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _VC.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class updateVC2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "prodect",
                table: "virtualCompanies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "prodect",
                table: "virtualCompanies");
        }
    }
}
