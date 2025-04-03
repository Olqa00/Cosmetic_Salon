using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CosmeticSalon.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.RecordId);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentUsers",
                columns: table => new
                {
                    RecordId = table.Column<int>(type: "int", nullable: false),
                    TreatmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentUsers", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_TreatmentUsers_Treatments_RecordId",
                        column: x => x.RecordId,
                        principalTable: "Treatments",
                        principalColumn: "RecordId",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreatmentUsers");

            migrationBuilder.DropTable(
                name: "Treatments");
        }
    }
}
