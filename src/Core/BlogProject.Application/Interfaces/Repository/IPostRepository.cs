using BlogProject.Application.Parameters;
using BlogProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Application.Interfaces.Repository
{
    public interface IPostRepository : IRepository<Post> 
    {
        PagingResultModel<Post> GetAllPosts(PageRequestParameter parameter);
    }
}
