using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace ToDoApp.Database.Migrations
{
    public partial class InitialMigrationTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoListEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoListEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoItemEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsDone = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ToDoListEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItemEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ToDoItemEntities_ToDoListEntities_ToDoListEntityId",
                        column: x => x.ToDoListEntityId,
                        principalTable: "ToDoListEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItemEntities_ToDoListEntityId",
                table: "ToDoItemEntities",
                column: "ToDoListEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItemEntities");

            migrationBuilder.DropTable(
                name: "ToDoListEntities");
        }
    }
}
