using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Application.Parameters
{
    public class PagingResponseModel
    {
        public int TotalCount { get; set; } = 0;
        public int TotalPage { get; set; } = 1;
        public int CurrentPage { get; set; } = 1;
        public int? NextPage { get; set; }
        public int? PreviousPage { get; set; }

    }
}
