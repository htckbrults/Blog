
namespace BusinessLayer.Concrete
{
    public class BlogManager:Repositories<Blogs>,IBlogService
    {
        public BlogManager(BlogContext db) : base(db) { }
    }
}
