using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OwnerId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SharedTaskLists",
                columns: table => new
                {
                    TaskListId = table.Column<Guid>(type: "TEXT", nullable: false),
                    SharedWithUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Id = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedTaskLists", x => new { x.TaskListId, x.SharedWithUserId });
                    table.ForeignKey(
                        name: "FK_SharedTaskLists_TaskLists_TaskListId",
                        column: x => x.TaskListId,
                        principalTable: "TaskLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TaskListId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskItems_TaskLists_TaskListId",
                        column: x => x.TaskListId,
                        principalTable: "TaskLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_TaskListId",
                table: "TaskItems",
                column: "TaskListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SharedTaskLists");

            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "TaskLists");
        }
    }
}
