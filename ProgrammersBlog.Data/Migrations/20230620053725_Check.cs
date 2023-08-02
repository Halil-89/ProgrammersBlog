using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgrammersBlog.Data.Migrations
{
    public partial class Check : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Logger = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Callsite = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Exception = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7105), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7101), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7106) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7115), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7113), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7115) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7122), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7120), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7123) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7130), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7127), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7132) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7136), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7135), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7137) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7142), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7141), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7143) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7148), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7147), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7149) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7153), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7152), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7154) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7162), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7161), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7163) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7169), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7167), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(7169) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9670), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9672) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9678), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9679) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9683), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9684) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9691), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9692) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9695), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9696) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9700), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9701) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9704), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9705) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9709), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9710) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9713), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9714) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9718), new DateTime(2023, 6, 20, 8, 37, 23, 791, DateTimeKind.Local).AddTicks(9718) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2871), new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2872) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2876), new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2877) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2881), new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2882) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2885), new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2886) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2889), new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2890) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2893), new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2894) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2898), new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2899) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2902), new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2903) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2906), new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2907) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2910), new DateTime(2023, 6, 20, 8, 37, 23, 792, DateTimeKind.Local).AddTicks(2911) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "37fa269b-8e4d-4e16-a961-3a0798abdc32");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e116de6e-ff5e-40b9-9f21-83acb9678640");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "876a3ab6-c42a-4163-a6b6-caeeab931139");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "4fe857d1-c891-4b19-ba7c-df77b356f80a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "72327114-ce2d-4bf7-a308-6689e3ea51a5");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "157339b8-ff5f-47a0-b607-463268a9b483");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "5c9d30e5-e767-48ae-83fc-b39cc781dd00");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "91faa9fa-c43d-4a1e-b0fa-64e8176018c3");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "068512b4-573f-4dbb-bcc4-9edcd4c08842");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "d154bcdf-e2ff-4433-ab34-c559388d9e91");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11,
                column: "ConcurrencyStamp",
                value: "bfbaee0f-1ebd-405b-bf4d-f83425114939");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12,
                column: "ConcurrencyStamp",
                value: "84ae5706-5fae-4878-ba57-0a5eca12a480");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13,
                column: "ConcurrencyStamp",
                value: "3f151c4e-5839-4ef0-a1e1-3b42fa9edc16");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14,
                column: "ConcurrencyStamp",
                value: "5a5c7170-7cb5-43dc-90aa-d649c0efff73");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15,
                column: "ConcurrencyStamp",
                value: "9665b18b-bb2f-4e6d-98d0-da34c92d3913");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16,
                column: "ConcurrencyStamp",
                value: "20477ba6-cc1e-4ccb-b529-2be8e1c2302a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17,
                column: "ConcurrencyStamp",
                value: "91d541e4-91e8-4da7-8d30-22c95c4e296e");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18,
                column: "ConcurrencyStamp",
                value: "ddcdd98e-7e9d-400f-b008-121f6567263b");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19,
                column: "ConcurrencyStamp",
                value: "d690f026-d5ca-43f0-a728-ee0a6d8f5b95");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20,
                column: "ConcurrencyStamp",
                value: "5271d551-105c-4822-9bc1-29fede699a2a");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21,
                column: "ConcurrencyStamp",
                value: "4b302daf-d717-4c37-8cd1-f22933ef09d8");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22,
                column: "ConcurrencyStamp",
                value: "085dda8e-1ccf-427a-a2c5-196e3201f403");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3356bb3-9348-4b08-b238-b70ef3d56c20", "AQAAAAEAACcQAAAAEK9VoJEKAYldo4UF02/slbDZu3CpsgSuLHdiMWc5YQrCaIwxuC117//gAJZ5RI7kLg==", "013fb515-381b-4439-8cc5-e8aa3d1b107b" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60611640-f5a4-4345-a0eb-d98a36343e91", "AQAAAAEAACcQAAAAEFcOdr1OwZfmIu8OXrBAlSEmsuTS5v/9gwXBsj7Ru7RMIZ3IwkuhgtOutxbq+vMsdA==", "67c67a1e-db3d-45b5-8eb1-933ae240765c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8459), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8455), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8460) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8468), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8466), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8469) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8475), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8473), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8476) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8481), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8479), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8482) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8487), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8486), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8488) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8494), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8492), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8495) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8500), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8498), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8501) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8507), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8505), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8508) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8514), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8512), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8515) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "Date", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8520), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8519), new DateTime(2022, 10, 12, 10, 29, 1, 305, DateTimeKind.Local).AddTicks(8521) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2231), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2233) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2240), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2241) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2246), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2248) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2253), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2255) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2260), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2262) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2267), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2269) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2275), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2276) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2281), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2283) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2288), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2289) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2294), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(2295) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7073), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7075) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7081), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7083) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7089), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7090) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7095), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7097) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7102), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7103) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7109), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7116), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7117) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7123), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7124) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7130), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7131) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7138), new DateTime(2022, 10, 12, 10, 29, 1, 306, DateTimeKind.Local).AddTicks(7139) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "e3374572-da1c-486f-ba86-b6f683db8f09");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "ecb742eb-83de-4de0-857e-cf4c8fa3b232");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "5deaab1a-fd58-4238-84f9-1d497edd1a91");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "6b6db3f3-42b5-4470-86b0-0f989e3ce2f3");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "2dceb5c1-ef1f-47c4-96ff-ba247fe82739");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "01902b2b-7061-4095-a28c-f1e492382288");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "b3612ad0-4d33-4b3e-b658-800aa1bb320c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "89feb04e-e096-4187-9cdf-a07f4838a505");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "2cbcb6da-5dc4-4b47-a3e0-7df9696732b2");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "d17be7fb-f6ec-4cf1-b3a2-847649eb9a71");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 11,
                column: "ConcurrencyStamp",
                value: "53e7befd-e6b3-4d98-9a12-079586d293c7");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 12,
                column: "ConcurrencyStamp",
                value: "37267b36-f6f0-4be2-b8e1-02b345248186");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 13,
                column: "ConcurrencyStamp",
                value: "50657b57-29e3-414a-8fb7-31b640da31ee");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 14,
                column: "ConcurrencyStamp",
                value: "8296362b-abcf-472e-9ab7-37aebcb11e96");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 15,
                column: "ConcurrencyStamp",
                value: "c426643c-19f4-444c-b748-749290ef0104");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 16,
                column: "ConcurrencyStamp",
                value: "c8a8b690-81c6-4d5a-808c-34909ac11bbb");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 17,
                column: "ConcurrencyStamp",
                value: "e96834bd-ae51-482f-a226-28733f24ca5e");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 18,
                column: "ConcurrencyStamp",
                value: "c77f8466-de75-46c8-9d17-9b48eeffa487");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 19,
                column: "ConcurrencyStamp",
                value: "72c19c0e-8ee1-40ee-917c-c4281cb10a94");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20,
                column: "ConcurrencyStamp",
                value: "c848619f-a104-40f0-886b-5822c90c89a6");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 21,
                column: "ConcurrencyStamp",
                value: "ad4bd58f-ce1d-4056-b22a-72f74175bc34");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 22,
                column: "ConcurrencyStamp",
                value: "a7b6e6e9-647c-475d-b52e-4769d5a375c7");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "759f3a84-7c45-4f19-b660-09a0c9a634e8", "AQAAAAEAACcQAAAAEA66SkRg0BYdFpr5HDchK55HiRCJrDq/NnLXeFmuBt2kqyKXhiIetFGEfuPyvgPDrw==", "36137791-82b2-4e50-8d58-e1fa1e5d869f" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "74f1bbc3-90e3-4a39-802c-2ee1ec0acbbf", "AQAAAAEAACcQAAAAEFZoSkWdXPATAzBuZ+vaBGQLsRI3v3o24txqVjCktzbkCRHMe/HMxjVeQ3mjmFpS4w==", "85665b66-7797-42c4-97eb-7484e8b820dc" });
        }
    }
}
