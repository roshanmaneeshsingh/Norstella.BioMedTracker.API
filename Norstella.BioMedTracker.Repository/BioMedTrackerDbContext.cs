using Microsoft.EntityFrameworkCore;
using BioMedTracker.Repository.EFModels;

namespace BioMedTracker.Repository
{
    public class BioMedTrackerDbContext : DbContext
    {
        public BioMedTrackerDbContext()
        {
        }

        public BioMedTrackerDbContext(DbContextOptions<BioMedTrackerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<Drug> Drugs { get; set; }
        public virtual DbSet<DrugIndication> DrugIndications { get; set; }

        /// <summary>
        ///     Here the model configuration is enforced. Usually this is the place where after creating the configuration
        ///     for the model, the very configuration will be added by the Entity Framework.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new DrugConfiguration());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder.DefaultTypeMapping<DrugIndication>();
        }
    }
}
