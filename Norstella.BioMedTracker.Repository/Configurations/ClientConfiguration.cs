using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BioMedTracker.Repository.EFModels;

namespace BioMedTracker.Repository
{
    internal class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.ClientId);
            builder.Property(b => b.ClientId).HasColumnName("ClientId").HasColumnType("int").IsRequired().ValueGeneratedNever();
            builder.Property(b => b.ClientName).HasColumnName("ClientName").HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.ToTable("Clients", "dbo");
        }
    }
}
