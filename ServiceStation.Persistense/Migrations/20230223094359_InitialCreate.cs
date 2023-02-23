using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceStation.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Body = table.Column<int>(type: "int", nullable: false),
                    Wheels = table.Column<int>(type: "int", nullable: false),
                    Engine = table.Column<int>(type: "int", nullable: false),
                    Breaks = table.Column<int>(type: "int", nullable: false),
                    Undercarriage = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<double>(type: "float", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InteriorAndHandrails = table.Column<int>(type: "int", nullable: true),
                    ChangeSeats = table.Column<bool>(type: "bit", nullable: true),
                    WheelBalancing = table.Column<bool>(type: "bit", nullable: true),
                    Hydraulics = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
