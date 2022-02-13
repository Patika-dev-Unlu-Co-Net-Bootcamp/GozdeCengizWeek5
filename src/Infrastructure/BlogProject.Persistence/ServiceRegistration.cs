using BlogProject.Application.Interfaces.Repository;
using BlogProject.Persistence.Context;
using BlogProject.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(
                opt => opt.UseSqlServer(
                    connectionString:"SqlConnection",
                    x => 
                    { x.MigrationsAssembly(Assembly.GetAssembly(typeof(ApplicationDbContext)).GetName().Name); }
                    ));
            //serviceCollection.AddTransient<IPostRepository, PostRepository>();
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }
    }
}
