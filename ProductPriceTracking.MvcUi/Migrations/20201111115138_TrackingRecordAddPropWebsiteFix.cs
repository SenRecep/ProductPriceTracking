using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductPriceTracking.MvcUi.Migrations
{
    public partial class TrackingRecordAddPropWebsiteFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackingRecords_Websites_WebsiteId",
                table: "TrackingRecords");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackingRecords_Websites_WebsiteId",
                table: "TrackingRecords",
                column: "WebsiteId",
                principalTable: "Websites",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackingRecords_Websites_WebsiteId",
                table: "TrackingRecords");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackingRecords_Websites_WebsiteId",
                table: "TrackingRecords",
                column: "WebsiteId",
                principalTable: "Websites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
