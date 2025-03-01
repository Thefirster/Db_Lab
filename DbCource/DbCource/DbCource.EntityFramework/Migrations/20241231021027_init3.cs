using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbCource.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Outbound",
                columns: table => new
                {
                    OutboundID = table.Column<Guid>(type: "TEXT", nullable: false),
                    OutboundTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ManagerName = table.Column<string>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    ProductNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    Transportation = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TranCost = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outbound", x => x.OutboundID);
                });

            migrationBuilder.CreateTable(
                name: "ProductForWarehource",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    ProductType = table.Column<string>(type: "TEXT", nullable: false),
                    Number = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductForWarehource", x => x.ProductID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Outbound_OutboundID",
                table: "Outbound",
                column: "OutboundID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductForWarehource_ProductID",
                table: "ProductForWarehource",
                column: "ProductID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Outbound");

            migrationBuilder.DropTable(
                name: "ProductForWarehource");
        }
    }
}
