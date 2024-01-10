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
                    { new Guid("0087a1df-8fe1-4254-b9c3-83811934e677"), new Guid("54a13cc1-0c60-436c-8b06-4ef8b0789ba7"), "candidate 2", new Guid("5ade3b46-ca2c-4309-858d-e916e65ed03a"), 2 },
                    { new Guid("08c611d7-d6b4-4f29-b64e-6308737e9396"), new Guid("ffcef07a-4f74-451a-8d00-b371faa51b3d"), "candidate 3", new Guid("eedbc3b1-a9c7-495c-a113-68d35a2d112c"), 1 },
                    { new Guid("0bb617a3-5ddd-4298-9368-4235e8e52611"), new Guid("12ab861c-80fb-4ed5-ba91-2fd8c5b21e7b"), "candidate 3", new Guid("eedbc3b1-a9c7-495c-a113-68d35a2d112c"), 6 },
                    { new Guid("148fe514-ffe8-4865-80e3-c05535f72319"), new Guid("12ab861c-80fb-4ed5-ba91-2fd8c5b21e7b"), "candidate 2", new Guid("5ade3b46-ca2c-4309-858d-e916e65ed03a"), 2 },
                    { new Guid("2474fb28-ace2-4f7d-a460-b5f9f804165b"), new Guid("b071e105-fb89-4940-9856-ac725c469118"), "candidate 3", new Guid("eedbc3b1-a9c7-495c-a113-68d35a2d112c"), 1 },
                    { new Guid("2fd811f6-490e-4319-b1f0-d949570d6b92"), new Guid("54a13cc1-0c60-436c-8b06-4ef8b0789ba7"), "candidate 3", new Guid("eedbc3b1-a9c7-495c-a113-68d35a2d112c"), 1 },
                    { new Guid("4db6523f-6d27-4ec9-9699-8b577c547fc8"), new Guid("ffcef07a-4f74-451a-8d00-b371faa51b3d"), "candidate 1", new Guid("8722b842-c9aa-4bf5-99c4-402a8ecac82c"), 5 },
                    { new Guid("77487e75-9a02-4295-a379-9800a3680fd8"), new Guid("12ab861c-80fb-4ed5-ba91-2fd8c5b21e7b"), "candidate 1", new Guid("8722b842-c9aa-4bf5-99c4-402a8ecac82c"), 2 },
                    { new Guid("8f8fd368-c33e-449c-8af4-ffb8626880a0"), new Guid("3ae69fd3-a026-4603-b5a5-0aafdc0e87d0"), "candidate 2", new Guid("5ade3b46-ca2c-4309-858d-e916e65ed03a"), 3 },
                    { new Guid("a1cc8cce-59f3-4a53-bb01-37845da7b05f"), new Guid("3ae69fd3-a026-4603-b5a5-0aafdc0e87d0"), "candidate 3", new Guid("eedbc3b1-a9c7-495c-a113-68d35a2d112c"), 1 },
                    { new Guid("a93008cc-f290-4484-8605-dcb168297bba"), new Guid("3ae69fd3-a026-4603-b5a5-0aafdc0e87d0"), "candidate 1", new Guid("8722b842-c9aa-4bf5-99c4-402a8ecac82c"), 4 },
                    { new Guid("b34bfb32-6e73-4feb-a3d1-049f3bc87063"), new Guid("54a13cc1-0c60-436c-8b06-4ef8b0789ba7"), "candidate 1", new Guid("8722b842-c9aa-4bf5-99c4-402a8ecac82c"), 4 },
                    { new Guid("b44b2013-ca8e-4dab-8ea8-0fb14253bac0"), new Guid("ffcef07a-4f74-451a-8d00-b371faa51b3d"), "candidate 2", new Guid("5ade3b46-ca2c-4309-858d-e916e65ed03a"), 2 },
                    { new Guid("e8708f5c-f719-43eb-95af-1537285ad80d"), new Guid("b071e105-fb89-4940-9856-ac725c469118"), "candidate 1", new Guid("8722b842-c9aa-4bf5-99c4-402a8ecac82c"), 2 },
                    { new Guid("fcb28380-7745-4333-bd36-995aecc2c02a"), new Guid("b071e105-fb89-4940-9856-ac725c469118"), "candidate 2", new Guid("5ade3b46-ca2c-4309-858d-e916e65ed03a"), 5 }
                });

            migrationBuilder.InsertData(
                table: "Constituencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("12ab861c-80fb-4ed5-ba91-2fd8c5b21e7b"), "New-Felucia" },
                    { new Guid("3ae69fd3-a026-4603-b5a5-0aafdc0e87d0"), "Shangri-la-Town" },
                    { new Guid("54a13cc1-0c60-436c-8b06-4ef8b0789ba7"), "Northern-Kunlun-Mountain" },
                    { new Guid("b071e105-fb89-4940-9856-ac725c469118"), "Naboo-Vallery" },
                    { new Guid("ffcef07a-4f74-451a-8d00-b371faa51b3d"), "Western-Shangri-la" }
                });

            migrationBuilder.InsertData(
                table: "Elections",
                columns: new[] { "Id", "Ongoing" },
                values: new object[] { new Guid("6288bcce-4f67-4971-92ed-4defb45d4117"), false });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5ade3b46-ca2c-4309-858d-e916e65ed03a"), "Blue Party" },
                    { new Guid("8722b842-c9aa-4bf5-99c4-402a8ecac82c"), "Red Party" },
                    { new Guid("e8e6b790-754a-43e6-a376-e2af64f3610d"), "Independent" },
                    { new Guid("eedbc3b1-a9c7-495c-a113-68d35a2d112c"), "Yellow Party" }
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
