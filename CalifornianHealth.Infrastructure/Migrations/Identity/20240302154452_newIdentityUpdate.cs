using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CalifornianHealth.Infrastructure.Migrations.Identity
{
    /// <inheritdoc />
    public partial class newIdentityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUser_Address1",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUser_Address2",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUser_City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUser_FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUser_LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUser_Postcode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropColumn(
                name: "ApplicationUser_Address1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUser_Address2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUser_City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUser_FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUser_LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ApplicationUser_Postcode",
                table: "AspNetUsers");
        }
    }
}
