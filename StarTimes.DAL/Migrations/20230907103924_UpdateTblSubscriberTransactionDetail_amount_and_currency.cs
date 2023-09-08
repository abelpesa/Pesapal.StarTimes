using Microsoft.EntityFrameworkCore.Migrations;

namespace StarTimes.DAL.Migrations
{
    public partial class UpdateTblSubscriberTransactionDetail_amount_and_currency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "SubscriberTransactionDetails",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "SubscriberTransactionDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "SubscriberTransactionDetails");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "SubscriberTransactionDetails");
        }
    }
}
