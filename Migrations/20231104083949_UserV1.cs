using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dot_webapi.Migrations
{
    /// <inheritdoc />
    public partial class UserV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Password" },
                values: new object[] { new Guid("fe2de405-c38e-4c90-ac52-da0540dfb411"), "moises@morales.com", "$2a$11$HhWhv1PSeH/zUxL2Y385cu8BYysU81E5IogQnvZvGPa/NFIA1pdwi" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb410"),
                column: "Created_at",
                value: new DateTime(2023, 11, 3, 9, 9, 33, 804, DateTimeKind.Utc).AddTicks(7970));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "Id",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb411"),
                column: "Created_at",
                value: new DateTime(2023, 11, 3, 9, 9, 33, 804, DateTimeKind.Utc).AddTicks(7970));
        }
    }
}
