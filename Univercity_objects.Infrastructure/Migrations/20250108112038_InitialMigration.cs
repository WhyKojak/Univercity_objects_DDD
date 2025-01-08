using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Univercity_objects.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CafedraEntities",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CafedraEntities", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "Auditories",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inv_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cafedraguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditories", x => x.guid);
                    table.ForeignKey(
                        name: "FK_Auditories_CafedraEntities_cafedraguid",
                        column: x => x.cafedraguid,
                        principalTable: "CafedraEntities",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComputerEntities",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inv_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Auditoryguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    specification = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerEntities", x => x.guid);
                    table.ForeignKey(
                        name: "FK_ComputerEntities_Auditories_Auditoryguid",
                        column: x => x.Auditoryguid,
                        principalTable: "Auditories",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FurnitureEntities",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inv_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Auditoryguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureEntities", x => x.guid);
                    table.ForeignKey(
                        name: "FK_FurnitureEntities_Auditories_Auditoryguid",
                        column: x => x.Auditoryguid,
                        principalTable: "Auditories",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultimediaEqumentEntities",
                columns: table => new
                {
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inv_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Auditoryguid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultimediaEqumentEntities", x => x.guid);
                    table.ForeignKey(
                        name: "FK_MultimediaEqumentEntities_Auditories_Auditoryguid",
                        column: x => x.Auditoryguid,
                        principalTable: "Auditories",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auditories_cafedraguid",
                table: "Auditories",
                column: "cafedraguid");

            migrationBuilder.CreateIndex(
                name: "IX_ComputerEntities_Auditoryguid",
                table: "ComputerEntities",
                column: "Auditoryguid");

            migrationBuilder.CreateIndex(
                name: "IX_FurnitureEntities_Auditoryguid",
                table: "FurnitureEntities",
                column: "Auditoryguid");

            migrationBuilder.CreateIndex(
                name: "IX_MultimediaEqumentEntities_Auditoryguid",
                table: "MultimediaEqumentEntities",
                column: "Auditoryguid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerEntities");

            migrationBuilder.DropTable(
                name: "FurnitureEntities");

            migrationBuilder.DropTable(
                name: "MultimediaEqumentEntities");

            migrationBuilder.DropTable(
                name: "Auditories");

            migrationBuilder.DropTable(
                name: "CafedraEntities");
        }
    }
}
