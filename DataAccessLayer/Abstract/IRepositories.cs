using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IRepositories<TEntity> where TEntity : class
    {
        public string Insert(TEntity entity);
        public string Update(TEntity entity);
        // db.Blogs.Where(x=> x.Name == 'wqewqeasdwqeqkw')
        public string Delete(Expression<Func<TEntity, bool>> where);
        public IList<TEntity> GetAllList(params Expression<Func<TEntity, object>>[] include);
        // db.urunler.Where(x=> x.Id == 1)
        public TEntity GetById(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include);
    }
}
