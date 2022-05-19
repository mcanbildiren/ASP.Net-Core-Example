using Microsoft.EntityFrameworkCore;

namespace BookStore.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                    new Book
                    {
                        Id = 1,
                        Title = "The Midnight Library",
                        GenreId = 1, // novel
                        PageCount = 283,
                        PublishDate = new DateTime(2022, 08, 13)
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "The Brain",
                        GenreId = 2, // science
                        PageCount = 272,
                        PublishDate = new DateTime(2014, 10, 14)
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "Dune",
                        GenreId = 3, // fiction
                        PageCount = 712,
                        PublishDate = new DateTime(2021, 08, 09)
                    }
                            );
                context.SaveChanges();
            }
        }
    }
}
