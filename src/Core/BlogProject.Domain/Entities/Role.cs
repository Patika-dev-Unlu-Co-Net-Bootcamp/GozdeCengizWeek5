using BlogProject.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Domain.Entities
{
    public class Role : IdentityRole<int>
    {
        public DateTime OlusturulmaTarihi { get; set; }
    }
}
