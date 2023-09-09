namespace BlazorECommerce.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Product> products = new()
        {
            new()
            {
                Id = 1,
                Title = "Life Is Beautiful",
                Description = "In 1930s Italy, a carefree Jewish waiter-turned-bookseller named Guido starts a fairy tale life by courting and marrying a lovely woman teacher named Dora. Guido and Dora have a son named Joshua and live happily together until the forced deportation of the town's Jewish population in cattle cars. Dora, while not required to be deported, volunteers to leave with her family, and they are all forced to live in a concentration camp. In an attempt to hold his family together and help his son survive the horrors of a concentration camp, Guido imagines that the Holocaust is a game and that the grand prize for winning is a tank.",
                ImageUrl = "https://www.miramax.com/assets/759_LifeIsBeautiful_Catalog_Poster_v2_Approved.png",
                Price = 24.88m
            },
            new()
            {
                Id = 2,
                Title = "Naruto: Itachi's Story, Vol. 1",
                Description = "A new series of prose novels, straight from the worldwide Naruto franchise. Naruto’s allies and enemies take center stage in these fast-paced adventures, with each volume focusing on a particular clan mate, ally, team...or villain.",
                ImageUrl = "https://m.media-amazon.com/images/I/51in42Zl3HL._SX331_BO1,204,203,200_.jpg",
                Price = 228.26m
            },
            new()
            {
                Id = 3,
                Title = "Attack on Titan 1",
                Description = "Bu post-kıyamet bilim-fi hikayesinde insanlık, titan olarak bilinen tuhaf, dev insancılar tarafından devastated edilmiştir. Küçük şey, kimin kamerasından veya ne kadar tüketici adamında bent olduğu hakkında bilinir. Denizci olarak akıllı değildir, dünyayı yıllarca dolaştı, herkesi öldürmek için. Past century, soldaki kişinin devasa bir şehirde gizlenmiş olması için. İnsanlar 50 metre yüksekliğindeki duvarların titan korunduğuna inanır, ancak muazzam bir titanyumun sudden görünümü her şeyi değiştirmek için önemlidir.",
                ImageUrl = "https://m.media-amazon.com/images/I/51r5Zr3BzCL._SX331_BO1,204,203,200_.jpg",
                Price = 555.95m
            },
        };

            modelBuilder.Entity<Product>().HasData(products);
        }

        public DbSet<Product> Products { get; set; }
    }
}
