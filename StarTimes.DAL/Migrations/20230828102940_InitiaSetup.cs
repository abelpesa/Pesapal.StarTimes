using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StarTimes.DAL.Migrations
{
    public partial class InitiaSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    UniqueId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriberInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SubsciberId = table.Column<string>(maxLength: 100, nullable: true),
                    ServiceCode = table.Column<string>(maxLength: 100, nullable: true),
                    CustomerName = table.Column<string>(maxLength: 100, nullable: true),
                    Mobile = table.Column<string>(maxLength: 20, nullable: true),
                    ContactAddress = table.Column<string>(maxLength: 256, nullable: true),
                    SubscriberStatus = table.Column<string>(maxLength: 60, nullable: true),
                    ExpirationDate = table.Column<string>(nullable: true),
                    BasicOfferDisplayName = table.Column<string>(nullable: true),
                    BasicOfferBusinessClass = table.Column<string>(nullable: true),
                    OtherInfo = table.Column<string>(maxLength: 256, nullable: true),
                    Reference = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriberInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriberTransactionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    SubscriberPaymentInfonId = table.Column<int>(nullable: false),
                    ConfirmationCode = table.Column<string>(nullable: true),
                    Status = table.Column<string>(maxLength: 256, nullable: true),
                    PaymentMethod = table.Column<string>(maxLength: 256, nullable: true),
                    TrackingId = table.Column<Guid>(maxLength: 256, nullable: false),
                    MerchantReference = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriberTransactionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriberTransactionDetails_SubscriberInfos_SubscriberPaymentInfonId",
                        column: x => x.SubscriberPaymentInfonId,
                        principalTable: "SubscriberInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationDetail_CreatedDate",
                table: "NotificationDetails",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberPaymentInfo_CreatedDate",
                table: "SubscriberInfos",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberPaymentInfo_Reference",
                table: "SubscriberInfos",
                column: "Reference");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberPaymentInfo_ServiceCode",
                table: "SubscriberInfos",
                column: "ServiceCode");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberTransactionDetail_CreatedDate",
                table: "SubscriberTransactionDetails",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriberTransactionDetails_SubscriberPaymentInfonId",
                table: "SubscriberTransactionDetails",
                column: "SubscriberPaymentInfonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationDetails");

            migrationBuilder.DropTable(
                name: "SubscriberTransactionDetails");

            migrationBuilder.DropTable(
                name: "SubscriberInfos");
        }
    }
}
