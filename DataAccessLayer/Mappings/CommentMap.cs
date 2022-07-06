namespace DataAccessLayer.Mappings
{
    public class CommentMap : IEntityTypeConfiguration<Comments>
    {
        public void Configure(EntityTypeBuilder<Comments> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CommentDate).HasColumnType("datetime").HasDefaultValue(DateTime.Now);
            builder.Property(x=> x.Email).HasMaxLength(100);
            builder.Property(x => x.Commenter).HasMaxLength(100);
            builder.Property(x => x.Status).HasDefaultValue(false);

            // İlişkilendirme. Bir'e Çok İlişki (One To Many)
            builder.HasOne(x => x.Blogs).WithMany(x => x.Comments).HasForeignKey(x=> x.BlogsId);

            builder.ToTable("Comments");
        }
    }
}
