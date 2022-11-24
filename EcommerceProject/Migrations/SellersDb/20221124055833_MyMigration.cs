using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceProject.Migrations.SellersDb
{
    public partial class MyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    SellerId = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    SellerName = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    Products = table.Column<int>(type: "int", nullable: false),
                    WalletBalance = table.Column<long>(type: "bigint", nullable: false),
                    Revenue = table.Column<float>(type: "real", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.SellerId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
