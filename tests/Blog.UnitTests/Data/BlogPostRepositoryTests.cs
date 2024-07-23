using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Data.Sqlite;
using Blog.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.UnitTests.Data.Context;
using Blog.Core.Entities;
using Blog.Data.SqlServer.Repositories;
using Blog.Data.SqlServer.Mappers;


namespace Blog.UnitTests.Data
{
    public class BlogPostRepositoryTests
    {
        protected SqlServerTestContext CreateInMemoryContext()
        {
            var _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<BlogContext>()
                .UseSqlite(_connection)
                .Options;

            return new SqlServerTestContext(options);
        }

        [Fact]
        public async Task GetById_Sould_Filter_And_Return_Post_By_Id()
        {
            //var context = CreateInMemoryContext();
            //await context.Database.EnsureCreatedAsync();

            //var post1 = new BlogPost("The Title", "The Content");
            //var post2 = new BlogPost("The Title 1", "The Content 2");

            //await context.Posts.AddRangeAsync(post1.ToTable(), post2.ToTable());
            //await context.SaveChangesAsync();

            //var repository = new BlogPostRepository(context);

            //var result = await repository.GetById(post1.Id, CancellationToken.None);

            //Assert.Equal(post1.Id, result.Id);
            //Assert.Equal(post1.Title, result.Title);
        }
    }
}
