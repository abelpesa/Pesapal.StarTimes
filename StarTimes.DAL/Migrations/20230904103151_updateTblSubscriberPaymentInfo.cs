using Microsoft.EntityFrameworkCore.Migrations;

namespace StarTimes.DAL.Migrations
{
    public partial class updateTblSubscriberPaymentInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "SubscriberInfos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "SubscriberInfos",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Firstname",
                table: "SubscriberInfos",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "SubscriberInfos",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "SubscriberInfos",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NewPackageCode",
                table: "SubscriberInfos",
                maxLength: 60,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "SubscriberInfos");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "SubscriberInfos");

            migrationBuilder.DropColumn(
                name: "Firstname",
                table: "SubscriberInfos");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "SubscriberInfos");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "SubscriberInfos");

            migrationBuilder.DropColumn(
                name: "NewPackageCode",
                table: "SubscriberInfos");
        }
    }
}
