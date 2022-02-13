using BlogProject.Application.Interfaces.Repository;
using BlogProject.Application.Parameters;
using BlogProject.Domain.Entities;
using BlogProject.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Persistence.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public PagingResultModel<Post> GetAllPosts(PageRequestParameter parameter)
        {

            PagingResultModel<Post> posts = new PagingResultModel<Post>(parameter);
            posts.GetData(_dbSet.AsNoTracking().AsQueryable());
            return posts;
        }
    }
}
