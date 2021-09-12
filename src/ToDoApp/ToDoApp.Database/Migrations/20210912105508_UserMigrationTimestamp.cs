using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace ToDoApp.Database.Migrations
{
    public partial class UserMigrationTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItemEntities_ToDoListEntities_ToDoListEntityId",
                table: "ToDoItemEntities");

            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "ToDoListEntities",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ToDoListEntityId",
                table: "ToDoItemEntities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "UserEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntities", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoListEntities_UserEntityId",
                table: "ToDoListEntities",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItemEntities_ToDoListEntities_ToDoListEntityId",
                table: "ToDoItemEntities",
                column: "ToDoListEntityId",
                principalTable: "ToDoListEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoListEntities_UserEntities_UserEntityId",
                table: "ToDoListEntities",
                column: "UserEntityId",
                principalTable: "UserEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDoItemEntities_ToDoListEntities_ToDoListEntityId",
                table: "ToDoItemEntities");

            migrationBuilder.DropForeignKey(
                name: "FK_ToDoListEntities_UserEntities_UserEntityId",
                table: "ToDoListEntities");

            migrationBuilder.DropTable(
                name: "UserEntities");

            migrationBuilder.DropIndex(
                name: "IX_ToDoListEntities_UserEntityId",
                table: "ToDoListEntities");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "ToDoListEntities");

            migrationBuilder.AlterColumn<int>(
                name: "ToDoListEntityId",
                table: "ToDoItemEntities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDoItemEntities_ToDoListEntities_ToDoListEntityId",
                table: "ToDoItemEntities",
                column: "ToDoListEntityId",
                principalTable: "ToDoListEntities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
