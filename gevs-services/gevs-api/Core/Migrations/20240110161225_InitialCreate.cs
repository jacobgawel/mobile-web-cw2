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
                    Vote = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
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
                    table.ForeignKey(
                        name: "FK_Candidates_Constituencies_ConstituencyId",
                        column: x => x.ConstituencyId,
                        principalTable: "Constituencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidates_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Constituencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2601cd67-9625-4c13-9767-593eb79366fd"), "Northern-Kunlun-Mountain" },
                    { new Guid("277b8634-156b-447c-9042-c7359480b0d2"), "New-Felucia" },
                    { new Guid("577ecc28-a621-417a-aba9-10e82f6a791a"), "Western-Shangri-la" },
                    { new Guid("9c91e290-c10e-4c77-b1b5-eef3de263c5b"), "Naboo-Vallery" },
                    { new Guid("dfe5185f-da46-4133-9032-7aa3b8550dcb"), "Shangri-la-Town" }
                });

            migrationBuilder.InsertData(
                table: "Elections",
                columns: new[] { "Id", "Ongoing" },
                values: new object[] { new Guid("967939fa-3c70-418d-a8ba-a06748bab46e"), false });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("483f1c77-2f20-4d6c-b1e1-1e0d48509aa5"), "Red Party" },
                    { new Guid("4ff82a3a-a7b7-4eeb-8938-74a86209181d"), "Independent" },
                    { new Guid("6d41c47b-407b-4b8d-bb54-7e4190fcd5ee"), "Blue Party" },
                    { new Guid("9e188e46-ed6d-4c12-9074-1decd992a388"), "Yellow Party" }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "ConstituencyId", "Name", "PartyId", "VoteCount" },
                values: new object[,]
                {
                    { new Guid("4b169931-e458-4650-b463-3f7b126ff95c"), new Guid("2601cd67-9625-4c13-9767-593eb79366fd"), "candidate 1", new Guid("9e188e46-ed6d-4c12-9074-1decd992a388"), 4 },
                    { new Guid("588759e7-4bd2-4a77-bbe9-2fb39f9eb478"), new Guid("2601cd67-9625-4c13-9767-593eb79366fd"), "candidate 3", new Guid("9e188e46-ed6d-4c12-9074-1decd992a388"), 1 },
                    { new Guid("87402645-7a3f-4c2f-904b-5475627e12bd"), new Guid("2601cd67-9625-4c13-9767-593eb79366fd"), "candidate 2", new Guid("9e188e46-ed6d-4c12-9074-1decd992a388"), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ConstituencyId",
                table: "Candidates",
                column: "ConstituencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_PartyId",
                table: "Candidates",
                column: "PartyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateResults");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Elections");

            migrationBuilder.DropTable(
                name: "Constituencies");

            migrationBuilder.DropTable(
                name: "Parties");
        }
    }
}
