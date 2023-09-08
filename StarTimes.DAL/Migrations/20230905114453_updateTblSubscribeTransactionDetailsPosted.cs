using Microsoft.EntityFrameworkCore.Migrations;

namespace StarTimes.DAL.Migrations
{
    public partial class updateTblSubscribeTransactionDetailsPosted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Posted",
                table: "SubscriberTransactionDetails",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Posted",
                table: "SubscriberTransactionDetails");
        }
    }
}
