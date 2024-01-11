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

            migrationBuilder.CreateTable(
                name: "VoteHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    HasVoted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteHistory", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "ConstituencyId", "Name", "PartyId", "VoteCount" },
                values: new object[,]
                {
                    { new Guid("055fb345-5db1-472d-9e02-ea099b5070f5"), new Guid("02c9bafd-4bec-4235-ab57-b477a0dd21d9"), "candidate 3", new Guid("27c07a71-c70d-4528-b747-7cbbd06f059f"), 1 },
                    { new Guid("0a46b8a3-2d52-410a-876a-f5884a10c432"), new Guid("02c9bafd-4bec-4235-ab57-b477a0dd21d9"), "candidate 1", new Guid("22e5f6ea-ee2f-40d5-99ce-f48a18b87b95"), 2 },
                    { new Guid("1a654501-bf89-42ff-af9c-369487b9b7cb"), new Guid("014b152b-3088-402b-a725-83dbf6d467de"), "candidate 2", new Guid("dbb4d60a-e99d-4ea0-9451-c545266db2ed"), 10 },
                    { new Guid("2368d93e-a8d9-4ecb-b459-104f0b0492bf"), new Guid("014b152b-3088-402b-a725-83dbf6d467de"), "candidate 3", new Guid("27c07a71-c70d-4528-b747-7cbbd06f059f"), 6 },
                    { new Guid("4d80bcc6-f567-4ad9-8a30-8fff6283fac9"), new Guid("0ee8e91a-adb2-4909-952c-356afe9676fa"), "candidate 3", new Guid("27c07a71-c70d-4528-b747-7cbbd06f059f"), 1 },
                    { new Guid("4eb4e16f-a66a-4d42-95d7-ca72e5f0d41e"), new Guid("ae29b11a-f3ba-44e6-a73a-21a50c76681e"), "candidate 1", new Guid("a9c00507-f3d6-4fa8-ade9-ee6a437e6f25"), 5 },
                    { new Guid("4fddcd7e-18eb-40d6-90e5-554bfbb97347"), new Guid("ae29b11a-f3ba-44e6-a73a-21a50c76681e"), "candidate 3", new Guid("27c07a71-c70d-4528-b747-7cbbd06f059f"), 1 },
                    { new Guid("7d7d4a4b-051d-4d07-89e8-a8ab41016b04"), new Guid("db23f0a0-5ea0-450a-8d25-6afe3a8db280"), "candidate 1", new Guid("22e5f6ea-ee2f-40d5-99ce-f48a18b87b95"), 4 },
                    { new Guid("7e8022a1-c0e3-4a97-af16-0c88ccd9855a"), new Guid("014b152b-3088-402b-a725-83dbf6d467de"), "candidate 1", new Guid("22e5f6ea-ee2f-40d5-99ce-f48a18b87b95"), 2 },
                    { new Guid("7f582c16-0268-4db9-aeda-43fdd874e0d1"), new Guid("db23f0a0-5ea0-450a-8d25-6afe3a8db280"), "candidate 2", new Guid("dbb4d60a-e99d-4ea0-9451-c545266db2ed"), 2 },
                    { new Guid("91b61aa7-b3bc-4e73-84a9-9fc3d98c2b10"), new Guid("0ee8e91a-adb2-4909-952c-356afe9676fa"), "candidate 2", new Guid("dbb4d60a-e99d-4ea0-9451-c545266db2ed"), 3 },
                    { new Guid("92569ac9-88c2-4be8-b160-11987226e24f"), new Guid("db23f0a0-5ea0-450a-8d25-6afe3a8db280"), "candidate 3", new Guid("27c07a71-c70d-4528-b747-7cbbd06f059f"), 1 },
                    { new Guid("a6b6e9c6-3e43-4da8-bf70-072ef8b2da75"), new Guid("0ee8e91a-adb2-4909-952c-356afe9676fa"), "candidate 1", new Guid("22e5f6ea-ee2f-40d5-99ce-f48a18b87b95"), 4 },
                    { new Guid("d4750984-c19d-4d73-86f1-6b9df66e523b"), new Guid("ae29b11a-f3ba-44e6-a73a-21a50c76681e"), "candidate 2", new Guid("dbb4d60a-e99d-4ea0-9451-c545266db2ed"), 2 },
                    { new Guid("f778f1bc-c443-4eed-a575-ec4ba54c3ed8"), new Guid("02c9bafd-4bec-4235-ab57-b477a0dd21d9"), "candidate 2", new Guid("dbb4d60a-e99d-4ea0-9451-c545266db2ed"), 10 }
                });

            migrationBuilder.InsertData(
                table: "Constituencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("014b152b-3088-402b-a725-83dbf6d467de"), "New-Felucia" },
                    { new Guid("02c9bafd-4bec-4235-ab57-b477a0dd21d9"), "Naboo-Vallery" },
                    { new Guid("0ee8e91a-adb2-4909-952c-356afe9676fa"), "Shangri-la-Town" },
                    { new Guid("ae29b11a-f3ba-44e6-a73a-21a50c76681e"), "Western-Shangri-la" },
                    { new Guid("db23f0a0-5ea0-450a-8d25-6afe3a8db280"), "Northern-Kunlun-Mountain" }
                });

            migrationBuilder.InsertData(
                table: "Elections",
                columns: new[] { "Id", "Ongoing" },
                values: new object[] { new Guid("b277ea66-7d91-4978-b21b-b492d416e8f0"), false });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("22e5f6ea-ee2f-40d5-99ce-f48a18b87b95"), "Red Party" },
                    { new Guid("27c07a71-c70d-4528-b747-7cbbd06f059f"), "Yellow Party" },
                    { new Guid("a9c00507-f3d6-4fa8-ade9-ee6a437e6f25"), "Independent" },
                    { new Guid("dbb4d60a-e99d-4ea0-9451-c545266db2ed"), "Blue Party" }
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

            migrationBuilder.DropTable(
                name: "VoteHistory");
        }
    }
}
