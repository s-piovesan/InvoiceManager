using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace InvoiceManager.WebSite.Migrations
{
    public partial class DeliveryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "InvoiceLine",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Delivery",
                columns: table => new
                {
                    DeliveryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivery", x => x.DeliveryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLine_DeliveryId",
                table: "InvoiceLine",
                column: "DeliveryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Delivery");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceLine_DeliveryId",
                table: "InvoiceLine");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "InvoiceLine");
        }
    }
}
