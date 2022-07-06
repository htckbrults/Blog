using System.Linq.Expressions;

namespace ExtraKonular
{
    //Generic Type
    // Sınıflara yada Metotlara gönderilecek olan Parametre'nin yada NESNE'nin dinamik olduğunu belirtmemizi sağlayan özelliktir.

    //  where TEntity : class => TEntity Tipi'nin Dinamik bir class olacağını belirtip, kısıtlıyoruz.
    public class Repositories<TEntity> where TEntity:class
    {
        public void Insert(TEntity entity) { }
        public void Update() { }
        public void Delete(Expression<Func<TEntity, bool>> where) { }
        public void GetAllList() { }
        public void GetById(Expression<Func<TEntity, bool>> where) { }
    }
}
