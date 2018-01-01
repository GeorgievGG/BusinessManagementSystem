namespace BMS.DataBaseData.EntityConfiguration
{
    using BMS.DataBaseModels;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public  class NoteConfiguration:IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.Property(d => d.Description).IsUnicode();

        }
    }
}
