using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class addImageRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 1,
                column: "PictureName",
                value: "assets/images/french_horn.png");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 2,
                column: "PictureName",
                value: "assets/images/trumpet.jpg");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 3,
                column: "PictureName",
                value: "assets/images/tuba.jpg");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 4,
                column: "PictureName",
                value: "assets/images/trombone.jpg");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 5,
                column: "PictureName",
                value: "assets/images/flugelhorn.jpg");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 6,
                column: "PictureName",
                value: "assets/images/flute.jpg");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 7,
                column: "PictureName",
                value: "assets/images/alto_saxophone.jpg");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 8,
                column: "PictureName",
                value: "assets/images/clarinet.png");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 9,
                column: "PictureName",
                value: "assets/images/bassoon.jpg");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 10,
                column: "PictureName",
                value: "assets/images/leaf_rake.png");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 11,
                column: "PictureName",
                value: "assets/images/leaf_rake.png");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 12,
                column: "PictureName",
                value: "assets/images/leaf_rake.png");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 13,
                column: "PictureName",
                value: "assets/images/leaf_rake.png");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 14,
                column: "PictureName",
                value: "assets/images/leaf_rake.png");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 15,
                column: "PictureName",
                value: "assets/images/leaf_rake.png");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 16,
                column: "PictureName",
                value: "assets/images/leaf_rake.png");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 1,
                column: "PictureName",
                value: "french_horn.png");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 2,
                column: "PictureName",
                value: "trumpet.jpg");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 3,
                column: "PictureName",
                value: "tuba.jpg");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 4,
                column: "PictureName",
                value: "trombone.jpg");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 5,
                column: "PictureName",
                value: "flugelhorn.jpg");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 6,
                column: "PictureName",
                value: "flute.jpg");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 7,
                column: "PictureName",
                value: "alto_saxophone.jpg");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 8,
                column: "PictureName",
                value: "clarinet.png");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 9,
                column: "PictureName",
                value: "bassoon.jpg");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 10,
                column: "PictureName",
                value: "leaf_rake.png");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 11,
                column: "PictureName",
                value: "leaf_rake.png");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 12,
                column: "PictureName",
                value: "leaf_rake.png");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 13,
                column: "PictureName",
                value: "leaf_rake.png");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 14,
                column: "PictureName",
                value: "leaf_rake.png");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 15,
                column: "PictureName",
                value: "leaf_rake.png");

            migrationBuilder.UpdateData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 16,
                column: "PictureName",
                value: "leaf_rake.png");
        }
    }
}
