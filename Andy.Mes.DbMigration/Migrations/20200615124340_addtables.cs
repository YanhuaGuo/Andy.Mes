using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Andy.Mes.DbMigration.Migrations
{
    public partial class addtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ProduceDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    JobName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "StaffDevice",
                columns: table => new
                {
                    Guid = table.Column<string>(nullable: false),
                    StaffGuid = table.Column<string>(nullable: true),
                    DeviceGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffDevice", x => x.Guid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "StaffDevice");
        }
    }
}
