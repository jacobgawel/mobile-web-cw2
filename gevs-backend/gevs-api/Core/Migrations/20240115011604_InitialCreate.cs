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
                    { new Guid("096941a7-9287-49bc-b856-ef212a2bd6b0"), new Guid("b15ba89f-7119-419a-a9ef-1d0324970eb6"), "candidate 1", new Guid("893bb9b4-a7d0-4f2d-ab51-5c20926540b5"), 2 },
                    { new Guid("0ca537c5-3a31-4a22-ab07-92cd219646cd"), new Guid("b15ba89f-7119-419a-a9ef-1d0324970eb6"), "candidate 2", new Guid("937ecdb8-c1c6-4de6-a3a0-545fc0851427"), 0 },
                    { new Guid("0da8fdad-980a-43a9-a07e-1d12a149f51f"), new Guid("b15ba89f-7119-419a-a9ef-1d0324970eb6"), "candidate 3", new Guid("7255eb5a-7b60-47ff-a5a8-557989fb3dc5"), 6 },
                    { new Guid("4fa406d0-2c8e-4421-abf7-f97060ff191f"), new Guid("f4723331-b57a-4a0d-9f53-8f99308b224a"), "candidate 1", new Guid("893bb9b4-a7d0-4f2d-ab51-5c20926540b5"), 4 },
                    { new Guid("589c21f2-6191-4f16-a9bf-f72899b455b7"), new Guid("90d0c297-68a5-4f3a-9de9-4d459c008a21"), "candidate 3", new Guid("893bb9b4-a7d0-4f2d-ab51-5c20926540b5"), 2 },
                    { new Guid("7433e71a-f895-4e20-b609-582b5acd2a64"), new Guid("1f9c33e1-9793-4bf2-948e-1a31d1344d42"), "candidate 3", new Guid("7255eb5a-7b60-47ff-a5a8-557989fb3dc5"), 1 },
                    { new Guid("8c8e0376-0a84-4a98-8f8a-a667aa607141"), new Guid("1dc37ad0-4e86-4202-8c41-db8abde152a6"), "candidate 2", new Guid("937ecdb8-c1c6-4de6-a3a0-545fc0851427"), 0 },
                    { new Guid("9294aa06-f73c-4005-8cfb-0d976aa5085a"), new Guid("1f9c33e1-9793-4bf2-948e-1a31d1344d42"), "candidate 2", new Guid("937ecdb8-c1c6-4de6-a3a0-545fc0851427"), 2 },
                    { new Guid("953c2d2f-0536-4117-acf4-8a3f81586454"), new Guid("90d0c297-68a5-4f3a-9de9-4d459c008a21"), "candidate 1", new Guid("e9188345-4789-43b0-a185-eaa19dccda36"), 0 },
                    { new Guid("9e3cf705-f0bd-410f-9830-ac7ef38efac1"), new Guid("90d0c297-68a5-4f3a-9de9-4d459c008a21"), "candidate 2", new Guid("937ecdb8-c1c6-4de6-a3a0-545fc0851427"), 4 },
                    { new Guid("a45caa6d-89da-4ec5-980a-e34f3273e889"), new Guid("f4723331-b57a-4a0d-9f53-8f99308b224a"), "candidate 2", new Guid("937ecdb8-c1c6-4de6-a3a0-545fc0851427"), 2 },
                    { new Guid("af8be576-23e6-4b1d-86ce-e3dc72412f71"), new Guid("f4723331-b57a-4a0d-9f53-8f99308b224a"), "candidate 3", new Guid("7255eb5a-7b60-47ff-a5a8-557989fb3dc5"), 1 },
                    { new Guid("d0c1238f-fc75-49d4-b36a-8fd502ac642d"), new Guid("1dc37ad0-4e86-4202-8c41-db8abde152a6"), "candidate 1", new Guid("893bb9b4-a7d0-4f2d-ab51-5c20926540b5"), 3 },
                    { new Guid("db0ba7bd-a0c5-4c1e-bb4b-c4cb047fc3ea"), new Guid("1dc37ad0-4e86-4202-8c41-db8abde152a6"), "candidate 3", new Guid("7255eb5a-7b60-47ff-a5a8-557989fb3dc5"), 1 },
                    { new Guid("ee9ff9a3-2595-4e4e-9956-4acab4e0a5de"), new Guid("1f9c33e1-9793-4bf2-948e-1a31d1344d42"), "candidate 1", new Guid("893bb9b4-a7d0-4f2d-ab51-5c20926540b5"), 4 }
                });

            migrationBuilder.InsertData(
                table: "Constituencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1dc37ad0-4e86-4202-8c41-db8abde152a6"), "Naboo-Vallery" },
                    { new Guid("1f9c33e1-9793-4bf2-948e-1a31d1344d42"), "Shangri-la-Town" },
                    { new Guid("90d0c297-68a5-4f3a-9de9-4d459c008a21"), "Western-Shangri-la" },
                    { new Guid("b15ba89f-7119-419a-a9ef-1d0324970eb6"), "New-Felucia" },
                    { new Guid("f4723331-b57a-4a0d-9f53-8f99308b224a"), "Northern-Kunlun-Mountain" }
                });

            migrationBuilder.InsertData(
                table: "Elections",
                columns: new[] { "Id", "Ongoing" },
                values: new object[] { new Guid("446ad0ad-5eba-4479-92c8-45e2d45340e8"), false });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7255eb5a-7b60-47ff-a5a8-557989fb3dc5"), "Yellow Party" },
                    { new Guid("893bb9b4-a7d0-4f2d-ab51-5c20926540b5"), "Red Party" },
                    { new Guid("937ecdb8-c1c6-4de6-a3a0-545fc0851427"), "Blue Party" },
                    { new Guid("e9188345-4789-43b0-a185-eaa19dccda36"), "Independent" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
