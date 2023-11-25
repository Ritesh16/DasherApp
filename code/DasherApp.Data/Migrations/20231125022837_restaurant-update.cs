using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DasherApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class restaurantupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Restaurant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderCreateTime",
                table: "Restaurant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDeliveryTime",
                table: "Restaurant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderPickupTime",
                table: "Restaurant",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "OrderCreateTime",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "OrderDeliveryTime",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "OrderPickupTime",
                table: "Restaurant");
        }
    }
}
