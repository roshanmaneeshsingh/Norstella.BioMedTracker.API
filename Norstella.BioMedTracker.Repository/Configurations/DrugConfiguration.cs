using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BioMedTracker.Repository.EFModels;

namespace BioMedTracker.Repository
{
    internal class DrugConfiguration : IEntityTypeConfiguration<Drug>
    {
        public void Configure(EntityTypeBuilder<Drug> builder)
        {
            builder.HasKey(e => e.DrugID);
            builder.Property(b => b.DrugID).HasColumnName("DrugID").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(b => b.DrugName).HasColumnName("DrugName").HasColumnType("nvarchar");
            builder.Property(b => b.BrandName).HasColumnName("BrandName").HasMaxLength(255).HasColumnType("nvarchar");
            builder.Property(b => b.GenericName).HasColumnName("GenericName").HasMaxLength(255).HasColumnType("nvarchar");
            builder.ToTable("Drugs", "dbo");
        }
    }
}
