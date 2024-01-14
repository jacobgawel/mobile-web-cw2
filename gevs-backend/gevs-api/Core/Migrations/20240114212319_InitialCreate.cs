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
                    { new Guid("1315993d-a94b-4410-a269-80bb91414988"), new Guid("c6d95402-0669-43df-892f-0c0542879e19"), "candidate 2", new Guid("41d851f8-5e79-4edf-9d56-79ef517ab8ca"), 2 },
                    { new Guid("160c5591-5abb-4432-9695-d885907bebf3"), new Guid("914fc076-9d45-4802-bcc5-1697a5b46e82"), "candidate 1", new Guid("60a58d3b-acc0-4022-ad5a-6e33e21d5a6d"), 0 },
                    { new Guid("1df90766-8e94-4678-a9b8-6cd85765710a"), new Guid("664e1e29-dde9-4439-b871-386e23ca1c4f"), "candidate 2", new Guid("41d851f8-5e79-4edf-9d56-79ef517ab8ca"), 0 },
                    { new Guid("20cf66cc-1f03-4068-908d-17a4f3e90076"), new Guid("914fc076-9d45-4802-bcc5-1697a5b46e82"), "candidate 3", new Guid("ef4264d7-aa9d-4476-ab43-225f82495cfa"), 2 },
                    { new Guid("3b476bf9-ce36-45e9-a8c1-971ec7f83d0f"), new Guid("85ce0a34-08be-4032-85e7-ef08224a4207"), "candidate 3", new Guid("d74bc2eb-53ed-4001-a9bf-dd34ea5f4636"), 1 },
                    { new Guid("56e4fe23-cd99-40b0-9463-86083cc7aeba"), new Guid("664e1e29-dde9-4439-b871-386e23ca1c4f"), "candidate 3", new Guid("d74bc2eb-53ed-4001-a9bf-dd34ea5f4636"), 6 },
                    { new Guid("591f7df8-6220-4469-8f33-323708566a1f"), new Guid("ddbe8b38-9967-4642-af8f-48ed6d6d9bca"), "candidate 1", new Guid("ef4264d7-aa9d-4476-ab43-225f82495cfa"), 3 },
                    { new Guid("754c3e8c-0cf5-4574-9cc4-283281336e23"), new Guid("914fc076-9d45-4802-bcc5-1697a5b46e82"), "candidate 2", new Guid("41d851f8-5e79-4edf-9d56-79ef517ab8ca"), 4 },
                    { new Guid("796bf78c-a716-4874-8b20-2bb106f51e74"), new Guid("664e1e29-dde9-4439-b871-386e23ca1c4f"), "candidate 1", new Guid("ef4264d7-aa9d-4476-ab43-225f82495cfa"), 2 },
                    { new Guid("7f7f340b-f012-4930-857d-10fd46c7faa1"), new Guid("85ce0a34-08be-4032-85e7-ef08224a4207"), "candidate 1", new Guid("ef4264d7-aa9d-4476-ab43-225f82495cfa"), 4 },
                    { new Guid("81c6b534-5ba9-446e-a817-338b9ed91eca"), new Guid("ddbe8b38-9967-4642-af8f-48ed6d6d9bca"), "candidate 3", new Guid("d74bc2eb-53ed-4001-a9bf-dd34ea5f4636"), 1 },
                    { new Guid("bf6b722f-c8cb-488f-a765-b7fca7c2e5a6"), new Guid("ddbe8b38-9967-4642-af8f-48ed6d6d9bca"), "candidate 2", new Guid("41d851f8-5e79-4edf-9d56-79ef517ab8ca"), 0 },
                    { new Guid("cfb67c92-20c1-4984-8478-5506aeae3973"), new Guid("c6d95402-0669-43df-892f-0c0542879e19"), "candidate 3", new Guid("d74bc2eb-53ed-4001-a9bf-dd34ea5f4636"), 1 },
                    { new Guid("e0ba1560-e696-41ab-9807-f84b11e31382"), new Guid("85ce0a34-08be-4032-85e7-ef08224a4207"), "candidate 2", new Guid("41d851f8-5e79-4edf-9d56-79ef517ab8ca"), 2 },
                    { new Guid("eff52ea8-1da1-4eaa-a110-723aade28ada"), new Guid("c6d95402-0669-43df-892f-0c0542879e19"), "candidate 1", new Guid("ef4264d7-aa9d-4476-ab43-225f82495cfa"), 4 }
                });

            migrationBuilder.InsertData(
                table: "Constituencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("664e1e29-dde9-4439-b871-386e23ca1c4f"), "New-Felucia" },
                    { new Guid("85ce0a34-08be-4032-85e7-ef08224a4207"), "Northern-Kunlun-Mountain" },
                    { new Guid("914fc076-9d45-4802-bcc5-1697a5b46e82"), "Western-Shangri-la" },
                    { new Guid("c6d95402-0669-43df-892f-0c0542879e19"), "Shangri-la-Town" },
                    { new Guid("ddbe8b38-9967-4642-af8f-48ed6d6d9bca"), "Naboo-Vallery" }
                });

            migrationBuilder.InsertData(
                table: "Elections",
                columns: new[] { "Id", "Ongoing" },
                values: new object[] { new Guid("0c2cd979-8dd6-4993-a0ad-beb3d892592e"), false });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("41d851f8-5e79-4edf-9d56-79ef517ab8ca"), "Blue Party" },
                    { new Guid("60a58d3b-acc0-4022-ad5a-6e33e21d5a6d"), "Independent" },
                    { new Guid("d74bc2eb-53ed-4001-a9bf-dd34ea5f4636"), "Yellow Party" },
                    { new Guid("ef4264d7-aa9d-4476-ab43-225f82495cfa"), "Red Party" }
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
