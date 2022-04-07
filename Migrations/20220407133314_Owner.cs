using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstateDemoApp.Migrations
{
    public partial class Owner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Listings");

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Listings",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listings_OwnerId",
                table: "Listings",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_AspNetUsers_OwnerId",
                table: "Listings",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_AspNetUsers_OwnerId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_OwnerId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Listings");

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Listings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
