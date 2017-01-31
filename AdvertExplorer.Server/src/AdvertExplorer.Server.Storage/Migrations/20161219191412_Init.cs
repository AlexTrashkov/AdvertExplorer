using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvertExplorer.Server.Storage.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Queries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AgeMax = table.Column<uint>(nullable: true),
                    AgeMin = table.Column<uint>(nullable: true),
                    Experience = table.Column<int>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    Region = table.Column<int>(nullable: false),
                    Rubric = table.Column<int>(nullable: true),
                    Salary = table.Column<uint>(nullable: true),
                    SearchString = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Queries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resumes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Age = table.Column<uint>(nullable: true),
                    City = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EducationType = table.Column<string>(nullable: true),
                    Experience = table.Column<int>(nullable: true),
                    Institution = table.Column<string>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    PhotoUri = table.Column<string>(nullable: true),
                    Rubrics = table.Column<string>(nullable: true),
                    Salary = table.Column<uint>(nullable: true),
                    Specialty = table.Column<string>(nullable: true),
                    WorkingType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Queries");

            migrationBuilder.DropTable(
                name: "Resumes");
        }
    }
}
