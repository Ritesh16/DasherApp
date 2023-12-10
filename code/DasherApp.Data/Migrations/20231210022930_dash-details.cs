using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DasherApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class dashdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropColumn(
                name: "TotalDelivery",
                table: "DailyDash");

            migrationBuilder.CreateTable(
                name: "DashDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Restaurant = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OrderCreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderPickupTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DailyDashId = table.Column<int>(type: "int", nullable: false),
                    RowCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RowUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashDetail_DailyDash_DailyDashId",
                        column: x => x.DailyDashId,
                        principalTable: "DailyDash",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DashDetail_DailyDashId",
                table: "DashDetail",
                column: "DailyDashId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DashDetail");

            migrationBuilder.AddColumn<int>(
                name: "TotalDelivery",
                table: "DailyDash",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OrderCreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderDeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderPickupTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RowCreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RowUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurant_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_LocationId",
                table: "Restaurant",
                column: "LocationId");
        }
    }
}
