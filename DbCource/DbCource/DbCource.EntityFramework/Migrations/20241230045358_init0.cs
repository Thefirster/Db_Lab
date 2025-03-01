using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbCource.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class init0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "inbounds",
                columns: table => new
                {
                    InboundID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Manager = table.Column<string>(type: "TEXT", nullable: false),
                    InboundTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Statues = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inbounds", x => x.InboundID);
                });

            migrationBuilder.CreateTable(
                name: "suppliers",
                columns: table => new
                {
                    SupplierID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FirmSize = table.Column<string>(type: "TEXT", nullable: false),
                    QuaType = table.Column<string>(type: "TEXT", nullable: false),
                    QuaEndTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    QuaAuthority = table.Column<string>(type: "TEXT", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Account = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_suppliers", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Permissions = table.Column<string>(type: "TEXT", nullable: false),
                    Account = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductID = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    ProductType = table.Column<string>(type: "TEXT", nullable: false),
                    ProductPrice = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductStabilityRate = table.Column<string>(type: "TEXT", nullable: false),
                    PriceFluctationRange = table.Column<int>(type: "INTEGER", nullable: false),
                    SupplierID = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_products_suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "suppliers",
                        principalColumn: "SupplierID");
                });

            migrationBuilder.CreateTable(
                name: "contracts",
                columns: table => new
                {
                    ContractID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Manager = table.Column<string>(type: "TEXT", nullable: false),
                    EstDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OrderQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    SupplierID = table.Column<Guid>(type: "TEXT", nullable: true),
                    ProductID = table.Column<Guid>(type: "TEXT", nullable: true),
                    InboundID = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contracts", x => x.ContractID);
                    table.ForeignKey(
                        name: "FK_contracts_inbounds_InboundID",
                        column: x => x.InboundID,
                        principalTable: "inbounds",
                        principalColumn: "InboundID");
                    table.ForeignKey(
                        name: "FK_contracts_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "ProductID");
                    table.ForeignKey(
                        name: "FK_contracts_suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "suppliers",
                        principalColumn: "SupplierID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_contracts_ContractID",
                table: "contracts",
                column: "ContractID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contracts_InboundID",
                table: "contracts",
                column: "InboundID");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_ProductID",
                table: "contracts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_SupplierID",
                table: "contracts",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_inbounds_InboundID",
                table: "inbounds",
                column: "InboundID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductID",
                table: "products",
                column: "ProductID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_products_SupplierID",
                table: "products",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_suppliers_SupplierID",
                table: "suppliers",
                column: "SupplierID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserID",
                table: "User",
                column: "UserID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contracts");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "inbounds");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "suppliers");
        }
    }
}
