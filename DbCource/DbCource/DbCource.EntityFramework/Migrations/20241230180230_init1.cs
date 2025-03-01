using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbCource.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_contracts_InboundID",
                table: "contracts");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_InboundID",
                table: "contracts",
                column: "InboundID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_contracts_InboundID",
                table: "contracts");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_InboundID",
                table: "contracts",
                column: "InboundID");
        }
    }
}
