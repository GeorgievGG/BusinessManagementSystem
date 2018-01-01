namespace BMS.DataBaseData.EntityConfiguration
{
    using BMS.DataBaseModels;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(n => n.Username).IsUnicode();

            builder.HasMany(i => i.Inquiries).WithOne(u => u.Creator).HasForeignKey(u => u.CreatorId);
            builder.HasMany(o => o.Offers).WithOne(c => c.Creator).HasForeignKey(c => c.CreatorId);
            builder.HasMany(p => p.Projects).WithOne(c => c.Creator).HasForeignKey(c => c.CreatorId);
            builder.HasMany(e => e.Events).WithOne(c => c.Creator).HasForeignKey(c => c.CreatorId);
        }
    }
}
