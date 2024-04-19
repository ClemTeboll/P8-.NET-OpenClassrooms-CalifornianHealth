using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalifornianHealth.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deleteIdIntInPatientClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Patient");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Patient",
                type: "nvarchar(450)",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Patient");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Patient",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
