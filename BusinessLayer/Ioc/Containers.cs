using BusinessLayer.Concrete;
using BusinessLayer.ValidationFluent;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer.Ioc
{
    // Inversion OF Control
    public static class Containers
    {
        // Sınıflarımızı türetmemizi sağlayan  Dependency Injection Kütüphanesindeki Metot, ve Bu Metot geriye Interface Döndürüyor. Bu interface Sınıflarımızın Nasıl türetileceğinden Sorumlu Bir Yapıdır.
        public static IServiceCollection MyService(this IServiceCollection services)
        {
            services.AddDbContext<BlogContext>();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<IInteractionsService, InteractionsManager>();
            services.AddScoped<IUserService, UserManager>();

            //Data Doğrulamalar Herkes için aynı olduğundan dolayı Bir defa Türetilmesi yeterlidir.
            services.AddSingleton<IValidator<Blogs>, ValidationBlogs>();
            services.AddSingleton<IValidator<Comments>, ValidaitonComment>();
            services.AddSingleton<IValidator<Users>, ValidationUsers>();
            return services;
        }
    }
}
