using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Application.Dto
{
    public class PostDto
    {
        //veri tabanı ile köprü görevi görecek
        public string Title { get; set; }
        public string Context { get; set; }
        public int AuthorId { get; set; }
    }
}
