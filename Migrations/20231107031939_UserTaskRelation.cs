using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dot_webapi.Migrations
{
    /// <inheritdoc />
    public partial class UserTaskRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Task",
                type: "uuid",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb410"),
                columns: new[] { "Created_at"},
                values: new object[] { new DateTime(2023, 11, 7, 3, 19, 39, 38, DateTimeKind.Utc).AddTicks(9040) });

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb411"),
                columns: new[] { "Created_at"},
                values: new object[] { new DateTime(2023, 11, 7, 3, 19, 39, 38, DateTimeKind.Utc).AddTicks(9050) });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb411"),
                column: "Password",
                value: "$2a$11$AHPsx3NLvhsahNETVkY/7.XnOinRLn0/ASoSL4IY5pIrPf5yyKKHi");

            migrationBuilder.CreateIndex(
                name: "IX_Task_UserId",
                table: "Task",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_User_UserId",
                table: "Task",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_User_UserId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_UserId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Task");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb410"),
                column: "Created_at",
                value: new DateTime(2023, 11, 4, 8, 39, 49, 388, DateTimeKind.Utc).AddTicks(9560));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb411"),
                column: "Created_at",
                value: new DateTime(2023, 11, 4, 8, 39, 49, 388, DateTimeKind.Utc).AddTicks(9560));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb411"),
                column: "Password",
                value: "$2a$11$HhWhv1PSeH/zUxL2Y385cu8BYysU81E5IogQnvZvGPa/NFIA1pdwi");
        }
    }
}
