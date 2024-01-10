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
                    { new Guid("0d351d87-973b-49f3-a457-3a766d610527"), "Northern-Kunlun-Mountain" },
                    { new Guid("2139d8e8-6c6f-4236-90ef-371ccafd0d5f"), "New-Felucia" },
                    { new Guid("3a9b3651-5e8b-4e5d-acaf-4458ce1c9817"), "Naboo-Vallery" },
                    { new Guid("5867da0d-560e-4f3e-b7b7-29a953e13855"), "Shangri-la-Town" },
                    { new Guid("95cd3ae7-024a-4414-b2ca-6b577bbc44fc"), "Western-Shangri-la" }
                });

            migrationBuilder.InsertData(
                table: "Elections",
                columns: new[] { "Id", "Ongoing" },
                values: new object[] { new Guid("8dd4041f-8a4c-4479-8a67-b591d412098b"), false });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1d13e53f-c615-415a-a0d2-4a85f6cbbf31"), "Red Party" },
                    { new Guid("8d86cc06-d8e8-4d45-805e-bc31d3737903"), "Blue Party" },
                    { new Guid("9384b241-49f8-4cb9-a7da-6b527bf592dc"), "Yellow Party" },
                    { new Guid("f7329878-3664-4255-be4b-b2f6950590d6"), "Independent" }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "ConstituencyId", "Name", "PartyId", "VoteCount" },
                values: new object[,]
                {
                    { new Guid("21c132f6-e949-4e25-9ef4-199020bded58"), new Guid("0d351d87-973b-49f3-a457-3a766d610527"), "candidate 2", new Guid("8d86cc06-d8e8-4d45-805e-bc31d3737903"), 2 },
                    { new Guid("78e8a852-7d7a-4e9b-9b8a-f8472a7bf75a"), new Guid("0d351d87-973b-49f3-a457-3a766d610527"), "candidate 3", new Guid("9384b241-49f8-4cb9-a7da-6b527bf592dc"), 1 },
                    { new Guid("ac4ce7eb-669b-4aa0-aa2a-67c74d444770"), new Guid("0d351d87-973b-49f3-a457-3a766d610527"), "candidate 1", new Guid("1d13e53f-c615-415a-a0d2-4a85f6cbbf31"), 4 }
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
