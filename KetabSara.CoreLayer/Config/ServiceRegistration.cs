using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KetabSara.CoreLayer.Services.Authors;
using KetabSara.CoreLayer.Services.Books;
using KetabSara.DataLayer.Repositories.Author;
using KetabSara.DataLayer.Repositories.Book;
using Microsoft.Extensions.DependencyInjection;

namespace KetabSara.CoreLayer.Config
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {

            // Repositories

            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();


            // Services

            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IBookService, BookService>();



            return services;
        }

    }
}
