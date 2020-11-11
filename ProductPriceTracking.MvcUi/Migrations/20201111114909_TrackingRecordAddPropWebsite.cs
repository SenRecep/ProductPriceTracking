using Microsoft.EntityFrameworkCore.Migrations;

namespace ProductPriceTracking.MvcUi.Migrations
{
    public partial class TrackingRecordAddPropWebsite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WebsiteId",
                table: "TrackingRecords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TrackingRecords_WebsiteId",
                table: "TrackingRecords",
                column: "WebsiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackingRecords_Websites_WebsiteId",
                table: "TrackingRecords",
                column: "WebsiteId",
                principalTable: "Websites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackingRecords_Websites_WebsiteId",
                table: "TrackingRecords");

            migrationBuilder.DropIndex(
                name: "IX_TrackingRecords_WebsiteId",
                table: "TrackingRecords");

            migrationBuilder.DropColumn(
                name: "WebsiteId",
                table: "TrackingRecords");
        }
    }
}
