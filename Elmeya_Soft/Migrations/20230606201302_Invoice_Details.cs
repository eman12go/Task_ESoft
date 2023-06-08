using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elmeya_Soft.Migrations
{
    public partial class Invoice_Details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceDetails",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceDetails",
                table: "Invoices",
                column: "InvoiceDetails",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_InvoiceDetails_InvoiceDetails",
                table: "Invoices",
                column: "InvoiceDetails",
                principalTable: "InvoiceDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_InvoiceDetails_InvoiceDetails",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_InvoiceDetails",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "InvoiceDetails",
                table: "Invoices");
        }
    }
}
