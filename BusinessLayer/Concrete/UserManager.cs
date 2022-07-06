namespace BusinessLayer.Concrete
{
    public class UserManager : Repositories<Users>, IUserService
    {
        public UserManager(BlogContext db) : base(db) { }
    }
}
