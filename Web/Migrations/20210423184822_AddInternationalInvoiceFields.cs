using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
    public partial class AddInternationalInvoiceFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Buyer",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Consignee",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryOfBeneficiary",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryOfDestination",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryOfOrigin",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FreightForwarder",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HsCode",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PackageDescription",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartialShipment",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Port",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RelevantLocation",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seller",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TermsOfDelivery",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TermsOfPayment",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TotalGross",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TransportBy",
                table: "Proforma",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ValidUntil",
                table: "Proforma",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Buyer",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "Consignee",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "CountryOfBeneficiary",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "CountryOfDestination",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "CountryOfOrigin",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "FreightForwarder",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "HsCode",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "PackageDescription",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "PartialShipment",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "Port",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "RelevantLocation",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "Seller",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "TermsOfDelivery",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "TermsOfPayment",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "TotalGross",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "TransportBy",
                table: "Proforma");

            migrationBuilder.DropColumn(
                name: "ValidUntil",
                table: "Proforma");
        }
    }
}
