using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace gevs_api.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CandidateResults",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Party = table.Column<string>(type: "text", nullable: false),
                    Vote = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PartyId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConstituencyId = table.Column<Guid>(type: "uuid", nullable: false),
                    VoteCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Constituencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constituencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Elections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Ongoing = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "ConstituencyId", "Name", "PartyId", "VoteCount" },
                values: new object[,]
                {
                    { new Guid("2c31569c-8471-41fe-b084-b11fc137acc6"), new Guid("74c462e3-2226-4e97-857e-b0346c4c990d"), "candidate 2", new Guid("6eb20bce-be7e-4089-8022-25022f6168b2"), 2 },
                    { new Guid("342043c5-9256-435c-876c-56f52d874216"), new Guid("c36d75a7-7056-4efb-ae23-164933dd19bc"), "candidate 1", new Guid("b8156548-34b8-4b3a-bbaa-be1c7bd9c52f"), 4 },
                    { new Guid("3f974bdc-e458-4626-96dc-399f75a80873"), new Guid("c36d75a7-7056-4efb-ae23-164933dd19bc"), "candidate 3", new Guid("72af90b0-e398-40ea-9b48-2d4d4957e0c5"), 1 },
                    { new Guid("406e17ec-2535-4bb2-8c43-d859a906cae1"), new Guid("5c2fccaf-0a2f-48fa-8e04-909a61b9f2ee"), "candidate 1", new Guid("b8156548-34b8-4b3a-bbaa-be1c7bd9c52f"), 2 },
                    { new Guid("49a00f1e-c10f-48eb-9d1c-ded7920eea50"), new Guid("d886a89e-5dd2-4981-921e-ee614c2db184"), "candidate 3", new Guid("72af90b0-e398-40ea-9b48-2d4d4957e0c5"), 6 },
                    { new Guid("5b45bdeb-e6f8-4d18-8704-495115a801c3"), new Guid("dbe30a0a-0e77-4f20-b4f2-cf894d60fedc"), "candidate 2", new Guid("6eb20bce-be7e-4089-8022-25022f6168b2"), 2 },
                    { new Guid("8a6f6e09-bbc7-4c2f-aa76-037e443aa3b9"), new Guid("d886a89e-5dd2-4981-921e-ee614c2db184"), "candidate 1", new Guid("b8156548-34b8-4b3a-bbaa-be1c7bd9c52f"), 2 },
                    { new Guid("a9a26ef0-bc54-4af7-8b9b-0708bf5d98e1"), new Guid("74c462e3-2226-4e97-857e-b0346c4c990d"), "candidate 1", new Guid("e47fd3f6-722d-4f99-b05e-c220b664ce84"), 5 },
                    { new Guid("ac94c03a-9579-4ad9-8bd4-e62026ab8084"), new Guid("d886a89e-5dd2-4981-921e-ee614c2db184"), "candidate 2", new Guid("6eb20bce-be7e-4089-8022-25022f6168b2"), 10 },
                    { new Guid("ba5de2c2-f995-4099-8ab2-7ce4c54e992f"), new Guid("5c2fccaf-0a2f-48fa-8e04-909a61b9f2ee"), "candidate 3", new Guid("72af90b0-e398-40ea-9b48-2d4d4957e0c5"), 1 },
                    { new Guid("d99ef851-0bfe-43bf-83e2-fa8961553ad2"), new Guid("74c462e3-2226-4e97-857e-b0346c4c990d"), "candidate 3", new Guid("72af90b0-e398-40ea-9b48-2d4d4957e0c5"), 1 },
                    { new Guid("e33f560e-950d-4cd8-859d-87417ac89217"), new Guid("c36d75a7-7056-4efb-ae23-164933dd19bc"), "candidate 2", new Guid("6eb20bce-be7e-4089-8022-25022f6168b2"), 3 },
                    { new Guid("e56f7fc2-6d2d-4bce-96fd-9fd7d797d3bb"), new Guid("dbe30a0a-0e77-4f20-b4f2-cf894d60fedc"), "candidate 3", new Guid("72af90b0-e398-40ea-9b48-2d4d4957e0c5"), 1 },
                    { new Guid("ea9c4bcf-27cd-4eca-b273-de8ac7192211"), new Guid("dbe30a0a-0e77-4f20-b4f2-cf894d60fedc"), "candidate 1", new Guid("b8156548-34b8-4b3a-bbaa-be1c7bd9c52f"), 4 },
                    { new Guid("fdc3665a-00b5-4df7-968f-5e036f56bef6"), new Guid("5c2fccaf-0a2f-48fa-8e04-909a61b9f2ee"), "candidate 2", new Guid("6eb20bce-be7e-4089-8022-25022f6168b2"), 10 }
                });

            migrationBuilder.InsertData(
                table: "Constituencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5c2fccaf-0a2f-48fa-8e04-909a61b9f2ee"), "Naboo-Vallery" },
                    { new Guid("74c462e3-2226-4e97-857e-b0346c4c990d"), "Western-Shangri-la" },
                    { new Guid("c36d75a7-7056-4efb-ae23-164933dd19bc"), "Shangri-la-Town" },
                    { new Guid("d886a89e-5dd2-4981-921e-ee614c2db184"), "New-Felucia" },
                    { new Guid("dbe30a0a-0e77-4f20-b4f2-cf894d60fedc"), "Northern-Kunlun-Mountain" }
                });

            migrationBuilder.InsertData(
                table: "Elections",
                columns: new[] { "Id", "Ongoing" },
                values: new object[] { new Guid("2537e525-ef6b-447e-90a5-5332b7c56716"), false });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6eb20bce-be7e-4089-8022-25022f6168b2"), "Blue Party" },
                    { new Guid("72af90b0-e398-40ea-9b48-2d4d4957e0c5"), "Yellow Party" },
                    { new Guid("b8156548-34b8-4b3a-bbaa-be1c7bd9c52f"), "Red Party" },
                    { new Guid("e47fd3f6-722d-4f99-b05e-c220b664ce84"), "Independent" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateResults");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Constituencies");

            migrationBuilder.DropTable(
                name: "Elections");

            migrationBuilder.DropTable(
                name: "Parties");
        }
    }
}
