using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoApp.Database.Migrations
{
    public partial class UniqueConstraintOnUserEmailMigrationTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserEntities",
                type: "varchar(767)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_UserEntities_Email",
                table: "UserEntities",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserEntities_Email",
                table: "UserEntities");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserEntities",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(767)");
        }
    }
}
