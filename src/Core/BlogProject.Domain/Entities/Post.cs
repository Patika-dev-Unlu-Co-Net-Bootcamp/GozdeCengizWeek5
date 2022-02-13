using BlogProject.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Domain.Entities
{
    public class Post:BaseEntity
    {
        public string Title { get; set; }
        public string Context { get; set; }
        public int AuthorId { get; set; }
    }
}
