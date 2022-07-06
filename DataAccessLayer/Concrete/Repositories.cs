using DataAccessLayer.Abstract;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete
{
    public class Repositories<TEntity> : IRepositories<TEntity> where TEntity : class
    {
        private readonly BlogContext db;
        public Repositories(BlogContext _db)
        {
            db = _db;
        }
        public string Delete(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                db.Remove(GetById(where));
                db.SaveChanges();
                return "İşlem Başarılı";
            }
            catch (Exception)
            {
                return "İşlem Başarısız";
            }
        }

        public IList<TEntity> GetAllList(params Expression<Func<TEntity, object>>[] include)
        {
            // IList,List,Collection,IEnumerable Gibi Yapılar Kullanıldığında Bütün Datalar Client'in Ram Belleğine aktarılır ve Sonra Where Şartına bakılıp data ekrana yansıtılır.

            // IQueryable Kullanıldığı zaman Where Şartına SQL Server'da bakılır, Şartlanmış veri kullanıcının Ram Belleğine Aktarılır ve ekrana yansıtılır.

            // IQueryable : SQL'de Filtreleme Yapılır ve Filtrelenmiş Data Ram'e Aktarılır.
            //IList,List,Collection,IEnumerable : Önce Bütün Datalar Ram Belleğe aktarılır ve Ram Bellekte Filtreleme yapılır.


            IQueryable<TEntity> query = db.Set<TEntity>(); // Hangi NESNE gönderildiyse O NESNE'nin veritabanındaki Dataları aktaracak.
            if (include.Any()) // İşlikili Tablo istenmişmi Bakılıyor.
            {
                foreach (var item in include) // İstenilen parametreler Foreach ile alınıyor.
                {
                   query = query.Include(item); // Query Yapımıza Aktarılmasını sağlıyoruz.
                }
            }
            return query.ToList();

        }

        public TEntity GetById(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] include)
        {
            IQueryable<TEntity> query;
            if (where != null)
            {
                query = db.Set<TEntity>().Where(where);
            }
            else
            {
                query = db.Set<TEntity>();
            }
            if (include.Any()) // İşlikili Tablo istenmişmi Bakılıyor.
            {
                foreach (var item in include) // İstenilen parametreler Foreach ile alınıyor.
                {
                    query = query.Include(item); // Query Yapımıza Aktarılmasını sağlıyoruz.
                }
            } 
            return query.FirstOrDefault();
        }

        public string Insert(TEntity entity)
        {
            try
            {
                db.Add(entity);
                db.SaveChanges();
                return "İşlem Başarılı";
            }
            catch (Exception)
            {
                return "İşlem Başarısız";
            }
        }

        public string Update(TEntity entity)
        {
            try
            {
                db.Update(entity);
                db.SaveChanges();
                return "İşlem Başarılı";
            }
            catch (Exception)
            {
                return "İşlem Başarısız";
            }
        }
    }
}
