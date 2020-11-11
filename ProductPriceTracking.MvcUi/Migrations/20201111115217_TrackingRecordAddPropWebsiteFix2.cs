using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductPriceTracking.MvcUi.Migrations
{
    public partial class TrackingRecordAddPropWebsiteFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackingRecords_Products_ProductId",
                table: "TrackingRecords");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackingRecords_Products_ProductId",
                table: "TrackingRecords",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackingRecords_Products_ProductId",
                table: "TrackingRecords");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackingRecords_Products_ProductId",
                table: "TrackingRecords",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
