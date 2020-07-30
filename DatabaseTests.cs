using EFCoreTests.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace EFCoreTests
{
    public class DatabaseTests
    {
        [Fact(Skip = "One-Timer")]
        public async Task CreateAuthorAsync()
        {
            using (var context = new EFCoreTestsDatabaseContext())
            {
                context.Authors.Add(new Author { FirstName = "John", LastName = "Steinbeck" });
                await context.SaveChangesAsync();
            }
        }

        [Fact]
        public async Task AddBookAsync()
        {
            using var context = new EFCoreTestsDatabaseContext();

            var author = await context.Authors
                .Include(a => a.Books)
                .FirstAsync(a => a.AuthorId == 1);

            var book = new Book { Author = author, Title = "Of Mice and Men" };

            author.Books.Add(book);

            var state = context.Entry(book).State;

            Assert.True(state == EntityState.Detached);

            var result = await context.SaveChangesAsync();

            Assert.Equal(1, result);
        }

        [Fact(Skip = "One-Timer")]
        public async Task CreateWriterAsync()
        {
            using var context = new EFCoreTestsDatabaseContext();
            context.Writers.Add(new Writer { FirstName = "John", LastName = "Steinbeck" });
            await context.SaveChangesAsync();
        }

        [Fact]
        public async Task AddStoryAsync()
        {
            using var context = new EFCoreTestsDatabaseContext();

            var writer = await context.Writers
                .Include(a => a.Stories)
                .FirstAsync(w => w.LastName == "Steinbeck");

            var story = new Story { Writer = writer, Title = "Of Mice and Men" };

            writer.Stories.Add(story);

            var state = context.Entry(story).State;

            Assert.True(state == EntityState.Detached);

            var result = await context.SaveChangesAsync();

            Assert.Equal(1, result);
        }
    }
}
