using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Web.Migrations
{
    public partial class AddProformaDataView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
     
            migrationBuilder.CreateTable(
                name: "ProformaDataView",
                columns: table => new
                {
                    ProformaId = table.Column<int>(type: "integer", nullable: false),
                    Data = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProformaDataView", x => x.ProformaId);
                });

        
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
     

            migrationBuilder.DropTable(
                name: "ProformaDataView");

          
        }
    }
}
