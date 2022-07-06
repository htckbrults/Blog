namespace BusinessLayer.Concrete
{
    public class InteractionsManager : Repositories<Interactions>, IInteractionsService
    {
        public InteractionsManager(BlogContext db) : base(db) { }
    }
}
