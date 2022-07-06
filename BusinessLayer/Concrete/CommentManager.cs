namespace BusinessLayer.Concrete
{
    public class CommentManager:Repositories<Comments>,ICommentService
    {
        public CommentManager(BlogContext db) : base(db) { }
    }
}
