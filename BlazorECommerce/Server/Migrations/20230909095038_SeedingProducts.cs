using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorECommerce.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedingProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "In 1930s Italy, a carefree Jewish waiter-turned-bookseller named Guido starts a fairy tale life by courting and marrying a lovely woman teacher named Dora. Guido and Dora have a son named Joshua and live happily together until the forced deportation of the town's Jewish population in cattle cars. Dora, while not required to be deported, volunteers to leave with her family, and they are all forced to live in a concentration camp. In an attempt to hold his family together and help his son survive the horrors of a concentration camp, Guido imagines that the Holocaust is a game and that the grand prize for winning is a tank.", "https://www.miramax.com/assets/759_LifeIsBeautiful_Catalog_Poster_v2_Approved.png", 24.88m, "Life Is Beautiful" },
                    { 2, "A new series of prose novels, straight from the worldwide Naruto franchise. Naruto’s allies and enemies take center stage in these fast-paced adventures, with each volume focusing on a particular clan mate, ally, team...or villain.", "https://m.media-amazon.com/images/I/51in42Zl3HL._SX331_BO1,204,203,200_.jpg", 228.26m, "Naruto: Itachi's Story, Vol. 1" },
                    { 3, "Bu post-kıyamet bilim-fi hikayesinde insanlık, titan olarak bilinen tuhaf, dev insancılar tarafından devastated edilmiştir. Küçük şey, kimin kamerasından veya ne kadar tüketici adamında bent olduğu hakkında bilinir. Denizci olarak akıllı değildir, dünyayı yıllarca dolaştı, herkesi öldürmek için. Past century, soldaki kişinin devasa bir şehirde gizlenmiş olması için. İnsanlar 50 metre yüksekliğindeki duvarların titan korunduğuna inanır, ancak muazzam bir titanyumun sudden görünümü her şeyi değiştirmek için önemlidir.", "https://m.media-amazon.com/images/I/51r5Zr3BzCL._SX331_BO1,204,203,200_.jpg", 555.95m, "Attack on Titan 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
