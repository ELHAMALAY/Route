using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace National_Bank_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class SeedBranchAndManager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Code", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { "ALX-01", "Alexandria, Egypt", "Alexandria Branch", "0334567890" },
                    { "CAI-01", "Cairo, Egypt", "Cairo Main Branch", "0223456789" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "BranchCode", "Email", "FullName", "HireDate", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "CAI-01", "ahmed@nationalbank.com", "Ahmed Mohamed", new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "01012345678" },
                    { 2, "ALX-01", "mohamed@nationalbank.com", "Mohamed Ali", new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "01112345678" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "ALX-01");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: "CAI-01");
        }
    }
}
