namespace DataAccessLayer.Mappings
{
    public class UserMap : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.NameSurname).HasMaxLength(100).IsRequired();//Nvarchar(50)
            builder.Property(x => x.Password).HasMaxLength(30).IsRequired();//Nvarchar(30) - Zorunlu
            builder.Property(x => x.Phone).HasMaxLength(15).IsRequired();
            builder.Property(x => x.Summary).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Explanation).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.AvatarImages).HasMaxLength(100).IsRequired();

            // İlişkilendirme 
            // Kullanıcı Silinince, O Kullanıcıya Ait Bloglar Otomatik Silinecektir.
            builder.HasMany(x => x.Blogs).WithOne(x => x.Users).HasForeignKey(x => x.UsersId).OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Users");// Tablo Adı

        }
    }
}
