namespace DataAccessLayer.Mappings
{
    public class BlogMap : IEntityTypeConfiguration<Blogs>
    {
        public void Configure(EntityTypeBuilder<Blogs> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x=> x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Images).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Explanation).IsRequired();
            builder.Property(x => x.PublishDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now);
            builder.Property(x => x.Status).HasDefaultValue(false);

            // İlişkilendirme.
            //Users (Her Bir Bloğun, Bir Sahibi Olabilir.) Bire Çok İlişki (One To Many)
            builder.HasOne(x => x.Users).WithMany(x=> x.Blogs).HasForeignKey(x=> x.UsersId);

            //Comments (Her Bir Bloğun, Birden Fazla Yorumu Olabilir.)Çok'a Tek İlişki (Many To One)
            builder.HasMany(x => x.Comments).WithOne(x=> x.Blogs).HasForeignKey(x=> x.BlogsId);

            //Interactions (Her Bir Bloğun, Birden Fazla Etkileşimi Olabilir.) Çok'a Tek İlişki (Many To One)
            builder.HasMany(x => x.Interactions).WithOne(x => x.Blogs).HasForeignKey(x => x.BlogsId);

            builder.ToTable("Blogs");
        }
    }
}
