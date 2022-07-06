using DataAccessLayer.Mappings;

namespace DataAccessLayer.Concrete
{
    public class BlogContext:DbContext
    {
        // DbSet => Ekle, Sil, Güncelleme ve Listeleme işlemlerimizi yapmamızı sağlayan Abstract Bir Class'tır.
        public DbSet<Users> Users { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Interactions> Interactions { get; set; }
        public DbSet<Blogs> Blogs { get; set; }

        //Veritabanı Bağlantımızı Yöneten Bir Metot'tur. Bu Metot Polymorphism Yöntemi Kullanılarak Base Sınıf Metot Alt Sınıfta Değiştirilerek Kullanılıyor.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-1H9U897\SQLEXPRESS;Database=HaftasonuBlogs;Trusted_Connection=True;");
        }
        // Hangi Sınıfların Tablo Yapılarındaki Property'leri yöneteceğini Belirttiğimiz Metot. Bu Metot Polymorphism Yöntemi Kullanılarak Base Sınıf Metot Alt Sınıfta Değiştirilerek Kullanılıyor.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new BlogMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new InteractionsMap());

        }
    }
}
