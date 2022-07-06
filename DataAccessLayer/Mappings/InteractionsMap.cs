namespace DataAccessLayer.Mappings
{
    public class InteractionsMap : IEntityTypeConfiguration<Interactions>
    {
        public void Configure(EntityTypeBuilder<Interactions> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.InteractionDate).HasColumnType("datetime");
            builder.Property(x => x.InteractionType).IsRequired();
            builder.Property(x=> x.IPAddress).HasMaxLength(15);

            // İlişkilendirme.
            builder.HasOne(x => x.Blogs).WithMany(x => x.Interactions).HasForeignKey(x=> x.BlogsId);

            builder.ToTable("Interactions");


        }
    }
}




