using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SoftrayNewsAPI.Migrations
{
    public partial class MigrationForInitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(unicode: false, nullable: true),
                    LastName = table.Column<string>(unicode: false, nullable: true),
                    Username = table.Column<string>(unicode: false, nullable: true),
                    Password = table.Column<string>(unicode: false, nullable: true),
                    Token = table.Column<string>(unicode: false, nullable: true),
                    Role = table.Column<string>(unicode: false, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    DateInserted = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(unicode: false, nullable: true),
                    Text = table.Column<string>(unicode: false, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    DateInserted = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_UserId",
                table: "News",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
