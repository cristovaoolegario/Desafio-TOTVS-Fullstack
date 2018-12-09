using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioFullStackTotvs.Migrations
{
    public partial class CreateDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Auctions",
                columns: table => new
                {
                    AuctionID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    InitialValue = table.Column<long>(nullable: false),
                    WasUsed = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    UserForeignKey = table.Column<long>(nullable: true),
                    OpeningDate = table.Column<DateTime>(nullable: false),
                    TerminationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auctions", x => x.AuctionID);
                    table.ForeignKey(
                        name: "FK_Auctions_Users_UserForeignKey",
                        column: x => x.UserForeignKey,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuctionBids",
                columns: table => new
                {
                    AuctionBidID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BidPrice = table.Column<long>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    UserForeignKey = table.Column<long>(nullable: true),
                    AuctionId = table.Column<string>(nullable: true),
                    AuctionForeignKey = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionBids", x => x.AuctionBidID);
                    table.ForeignKey(
                        name: "FK_AuctionBids_Auctions_AuctionForeignKey",
                        column: x => x.AuctionForeignKey,
                        principalTable: "Auctions",
                        principalColumn: "AuctionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuctionBids_Users_UserForeignKey",
                        column: x => x.UserForeignKey,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionBids_AuctionForeignKey",
                table: "AuctionBids",
                column: "AuctionForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionBids_UserForeignKey",
                table: "AuctionBids",
                column: "UserForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Auctions_UserForeignKey",
                table: "Auctions",
                column: "UserForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionBids");

            migrationBuilder.DropTable(
                name: "Auctions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
