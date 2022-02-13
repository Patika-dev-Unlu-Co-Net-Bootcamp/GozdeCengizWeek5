using BlogProject.Application.Parameters;
using BlogProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Application.Services
{
    public interface IPostService:IService<Post>
    {
        PagingResultModel<Post> GetAllPosts(PageRequestParameter requestParameter);
    }
}
