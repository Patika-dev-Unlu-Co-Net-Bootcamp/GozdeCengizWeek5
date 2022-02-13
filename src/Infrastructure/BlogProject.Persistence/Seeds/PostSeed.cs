using BlogProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Persistence.Seeds
{
    public class PostSeed : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasData(
               new Post() { Id = Guid.NewGuid(), Title = "post1", Context = "context1", AuthorId = 1 },
               new Post() { Id = Guid.NewGuid(), Title = "post2", Context = "context2", AuthorId = 2 },
               new Post() { Id = Guid.NewGuid(), Title = "post3", Context = "context3", AuthorId = 1 }
               );
        }
    }
}
