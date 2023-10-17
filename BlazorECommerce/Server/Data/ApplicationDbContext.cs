﻿namespace BlazorECommerce.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductVariant>()
                        .HasKey(x => new { x.ProductId, x.ProductTypeId });

            List<ProductType> productTypes = new()
            {
                  new() { Id = 1, Name = "Default" },
                  new(){ Id = 2, Name = "Paperback" },
                  new(){ Id = 3, Name = "E-Book" },
                  new(){ Id = 4, Name = "Audiobook" },
                  new(){ Id = 5, Name = "Stream" },
                  new(){ Id = 6, Name = "Blu-ray" },
                  new(){ Id = 7, Name = "VHS" },
                  new(){ Id = 8, Name = "PC" },
                  new(){ Id = 9, Name = "PlayStation" },
                  new(){ Id = 10, Name = "Xbox" }
            };
            modelBuilder.Entity<ProductType>().HasData(productTypes);

            List<ProductVariant> productVariants = new()
            {
                 new()
               {
                   ProductId = 1,
                   ProductTypeId = 2,
                   Price = 9.99m,
                   OriginalPrice = 19.99m
               },
               new()
               {
                   ProductId = 1,
                   ProductTypeId = 3,
                   Price = 7.99m
               },
               new()
               {
                   ProductId = 1,
                   ProductTypeId = 4,
                   Price = 19.99m,
                   OriginalPrice = 29.99m
               },
               new()
               {
                   ProductId = 2,
                   ProductTypeId = 2,
                   Price = 7.99m,
                   OriginalPrice = 14.99m
               },
               new()
               {
                   ProductId = 3,
                   ProductTypeId = 2,
                   Price = 6.99m
               },
               new()
               {
                   ProductId = 4,
                   ProductTypeId = 5,
                   Price = 3.99m
               },
               new()
               {
                   ProductId = 4,
                   ProductTypeId = 6,
                   Price = 9.99m
               },
               new()
               {
                   ProductId = 4,
                   ProductTypeId = 7,
                   Price = 19.99m
               },
               new()
               {
                   ProductId = 5,
                   ProductTypeId = 5,
                   Price = 3.99m,
               },
               new()
               {
                   ProductId = 6,
                   ProductTypeId = 5,
                   Price = 2.99m
               },
               new()
               {
                   ProductId = 7,
                   ProductTypeId = 8,
                   Price = 19.99m,
                   OriginalPrice = 29.99m
               },
               new()
               {
                   ProductId = 7,
                   ProductTypeId = 9,
                   Price = 69.99m
               },
               new()
               {
                   ProductId = 7,
                   ProductTypeId = 10,
                   Price = 49.99m,
                   OriginalPrice = 59.99m
               },
               new()
               {
                   ProductId = 8,
                   ProductTypeId = 8,
                   Price = 9.99m,
                   OriginalPrice = 24.99m,
               },
               new()
               {
                   ProductId = 9,
                   ProductTypeId = 8,
                   Price = 14.99m
               },
               new()
               {
                   ProductId = 10,
                   ProductTypeId = 1,
                   Price = 159.99m,
                   OriginalPrice = 299m
               },
               new()
               {
                   ProductId = 11,
                   ProductTypeId = 1,
                   Price = 79.99m,
                   OriginalPrice = 399m
               }
            };
            modelBuilder.Entity<ProductVariant>().HasData(productVariants);

            List<Category> initialCategories = new()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Book",
                    Url = "books",
                    Icon = "oi oi-book"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Movie",
                    Url = "movies",
                    Icon = "oi oi-camera-slr"
                },
                 new Category()
                 {
                     Id = 3,
                     Name = "Video Games",
                     Url = "video-games",
                     Icon = "oi oi-puzzle-piece"
                 }
            };

            modelBuilder.Entity<Category>().HasData(initialCategories);

            List<Product> initialProducts = new()
            {
                new()
                    {
                        Id = 1,
                        Title = "The Hitchhiker's Guide to the Galaxy",
                        Description = "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including stage shows, novels, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg",
                        CategoryId = 1,
                        Featured = true,
                    },
                    new()
                    {
                        Id = 2,
                        Title = "Ready Player One",
                        Description = "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg",
                        CategoryId = 1
                    },
                    new()
                    {
                        Id = 3,
                        Title = "Nineteen Eighty-Four",
                        Description = "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated.",
                        ImageUrl = "https://static.wikia.nocookie.net/villains/images/8/80/Big-Brother-1984.jpg/revision/latest?cb=20190323152040",
                        CategoryId = 1
                    },
                    new()
                    {
                        Id = 4,
                        CategoryId = 2,
                        Title = "The Matrix",
                        Description = "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg",
                        Featured= true,
                    },
                    new()
                    {
                        Id = 5,
                        CategoryId = 2,
                        Title = "Back to the Future",
                        Description = "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg",
                    },
                    new()
                    {
                        Id = 6,
                        CategoryId = 2,
                        Title = "Toy Story",
                        Description = "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg",

                    },
                    new()
                    {
                        Id = 7,
                        CategoryId = 3,
                        Title = "Half-Life 2",
                        Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg",

                    },
                    new()
                    {
                        Id = 8,
                        CategoryId = 3,
                        Title = "Diablo II",
                        Description = "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png",
                    },
                    new()
                    {
                        Id = 9,
                        CategoryId = 3,
                        Title = "Day of the Tentacle",
                        Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
                    },
                    new()
                    {
                        Id = 10,
                        CategoryId = 3,
                        Title = "Xbox",
                        Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
                    },
                    new()
                    {
                        Id = 11,
                        CategoryId = 3,
                        Title = "Super Nintendo Entertainment System",
                        Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
                    },
                    new()
                    {
                        Id = 12,
                        Title = "Life Is Beautiful",
                        Description = "In 1930s Italy, a carefree Jewish waiter-turned-bookseller named Guido starts a fairy tale life by courting and marrying a lovely woman teacher named Dora. Guido and Dora have a son named Joshua and live happily together until the forced deportation of the town's Jewish population in cattle cars. Dora, while not required to be deported, volunteers to leave with her family, and they are all forced to live in a concentration camp. In an attempt to hold his family together and help his son survive the horrors of a concentration camp, Guido imagines that the Holocaust is a game and that the grand prize for winning is a tank.",
                        ImageUrl = "https://www.miramax.com/assets/759_LifeIsBeautiful_Catalog_Poster_v2_Approved.png",
                        CategoryId = 2
                    },
                    new()
                    {
                        Id = 13,
                        Title = "Naruto: Itachi's Story, Vol. 1",
                        Description = "A new series of prose novels, straight from the worldwide Naruto franchise. Naruto’s allies and enemies take center stage in these fast-paced adventures, with each volume focusing on a particular clan mate, ally, team...or villain.",
                        ImageUrl = "https://m.media-amazon.com/images/I/51in42Zl3HL._SX331_BO1,204,203,200_.jpg",
                        CategoryId = 1
                    },
                    new()
                    {
                        Id = 14,
                        Title = "Attack on Titan 1",
                        Description = "Bu post-kıyamet bilim-fi hikayesinde insanlık, titan olarak bilinen tuhaf, dev insancılar tarafından devastated edilmiştir. Küçük şey, kimin kamerasından veya ne kadar tüketici adamında bent olduğu hakkında bilinir. Denizci olarak akıllı değildir, dünyayı yıllarca dolaştı, herkesi öldürmek için. Past century, soldaki kişinin devasa bir şehirde gizlenmiş olması için. İnsanlar 50 metre yüksekliğindeki duvarların titan korunduğuna inanır, ancak muazzam bir titanyumun sudden görünümü her şeyi değiştirmek için önemlidir.",
                        ImageUrl = "https://m.media-amazon.com/images/I/51r5Zr3BzCL._SX331_BO1,204,203,200_.jpg",
                        CategoryId = 1,
                        Featured = true,
                    },
        };

            modelBuilder.Entity<Product>().HasData(initialProducts);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
    }
}
