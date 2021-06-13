using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class AddedBankdAccountsAndProformaNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankAccounts",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProformaNumber",
                table: "Proforma",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccounts",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "ProformaNumber",
                table: "Proforma");
        }
    }
}
