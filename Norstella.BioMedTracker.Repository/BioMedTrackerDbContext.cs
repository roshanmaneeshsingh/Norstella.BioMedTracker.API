using Microsoft.EntityFrameworkCore;
using BioMedTracker.Repository.EFModels;


namespace BioMedTracker.Repository
{
    public partial class BioMedTrackerDbContext : DbContext
    {
        public BioMedTrackerDbContext()
        {
        }

        public BioMedTrackerDbContext(DbContextOptions<BioMedTrackerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Drug> Drugs { get; set; }

        public virtual DbSet<DrugEvent> DrugEvents { get; set; }

        public virtual DbSet<DrugIndication> DrugIndications { get; set; }

        public virtual DbSet<EventType> EventTypes { get; set; }

        public virtual DbSet<Indication> Indications { get; set; }

        public virtual DbSet<Sampledatum> Sampledata { get; set; }

        public virtual DbSet<SubIndication> SubIndications { get; set; }

        public virtual DbSet<SubSubIndication> SubSubIndications { get; set; }

        public virtual DbSet<Trial> Trials { get; set; }

        public virtual DbSet<TrialDataDesc> TrialDataDescs { get; set; }

        public virtual DbSet<TrialDataEffectGroupType> TrialDataEffectGroupTypes { get; set; }

        public virtual DbSet<TrialDataEffectType> TrialDataEffectTypes { get; set; }

        public virtual DbSet<TrialDataEndPointType> TrialDataEndPointTypes { get; set; }

        public virtual DbSet<TrialDataGroup> TrialDataGroups { get; set; }

        public virtual DbSet<TrialDataGroupType> TrialDataGroupTypes { get; set; }

        public virtual DbSet<TrialDataMeasureType> TrialDataMeasureTypes { get; set; }

        public virtual DbSet<TrialDatum> TrialData { get; set; }

        public virtual DbSet<TrialEvent> TrialEvents { get; set; }

        /// <summary>
        ///     Here the model configuration is enforced. Usually this is the place where after creating the configuration
        ///     for the model, the very configuration will be added by the Entity Framework.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drug>(entity =>
            {
                entity.Property(e => e.DrugId)
                    .ValueGeneratedNever()
                    .HasColumnName("DrugID");
                entity.Property(e => e.BrandName).HasMaxLength(255);
                entity.Property(e => e.GenericName).HasMaxLength(255);
            });

            modelBuilder.Entity<DrugEvent>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.Property(e => e.RecordId).HasColumnName("RecordID");
                entity.Property(e => e.DrugId).HasColumnName("DrugID");
                entity.Property(e => e.EventDate).HasColumnType("datetime");
                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");
                entity.Property(e => e.IndicationId).HasColumnName("IndicationID");
                entity.Property(e => e.TrialId)
                    .HasMaxLength(150)
                    .HasColumnName("TrialID");

                entity.HasOne(d => d.EventType).WithMany(p => p.DrugEvents).HasForeignKey(d => d.EventTypeId);

                entity.HasOne(d => d.Indication).WithMany(p => p.DrugEvents)
                    .HasForeignKey(d => d.IndicationId)
                    .HasConstraintName("FK_DrugEvents_DrugIndications");
            });

            modelBuilder.Entity<DrugIndication>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.HasIndex(e => new { e.DrugId, e.SubSubIndicationId }, "UQ__DrugIndications__0627B95C").IsUnique();

                entity.Property(e => e.RecordId).HasColumnName("RecordID");
                entity.Property(e => e.DrugId).HasColumnName("DrugID");
                entity.Property(e => e.IndicationId).HasColumnName("IndicationID");
                entity.Property(e => e.SubIndicationId).HasColumnName("SubIndicationID");
                entity.Property(e => e.SubSubIndicationId).HasColumnName("SubSubIndicationID");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");
                entity.Property(e => e.EventType1)
                    .HasMaxLength(100)
                    .HasColumnName("EventType");
            });

            modelBuilder.Entity<Indication>(entity =>
            {
                entity.Property(e => e.IndicationId)
                    .ValueGeneratedNever()
                    .HasColumnName("IndicationID");
                entity.Property(e => e.IndicationName).HasMaxLength(100);
            });

            modelBuilder.Entity<Sampledatum>(entity =>
            {
                entity
                    .HasNoKey()
                    .ToTable("SAMPLEDATA");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<SubIndication>(entity =>
            {
                entity.Property(e => e.SubIndicationId)
                    .ValueGeneratedNever()
                    .HasColumnName("SubIndicationID");
                entity.Property(e => e.IndicationId).HasColumnName("IndicationID");
                entity.Property(e => e.SubIndicationName).HasMaxLength(100);
            });

            modelBuilder.Entity<SubSubIndication>(entity =>
            {
                entity.HasKey(e => e.SubSubIndicationId).HasName("PK_SubSubIndications030211");

                entity.Property(e => e.SubSubIndicationId)
                    .ValueGeneratedNever()
                    .HasColumnName("SubSubIndicationID");
                entity.Property(e => e.IndicationId).HasColumnName("IndicationID");
                entity.Property(e => e.SubIndicationId).HasColumnName("SubIndicationID");
                entity.Property(e => e.SubSubIndicationName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Indication).WithMany(p => p.SubSubIndications)
                    .HasForeignKey(d => d.IndicationId)
                    .HasConstraintName("fk_SubIndications_IndicationID");

                entity.HasOne(d => d.SubIndication).WithMany(p => p.SubSubIndications)
                    .HasForeignKey(d => d.SubIndicationId)
                    .HasConstraintName("fk_SubSubIndications_SubIndicationID");
            });

            modelBuilder.Entity<Trial>(entity =>
            {
                entity.Property(e => e.TrialId).HasColumnName("TrialID");
                entity.Property(e => e.IndicationRecId).HasColumnName("IndicationRecID");
                entity.Property(e => e.InitiationDate).HasColumnType("datetime");
                entity.Property(e => e.Pivotal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.PrimaryId).HasColumnName("PrimaryID");
                entity.Property(e => e.TrialName).HasMaxLength(200);
                entity.Property(e => e.TrialTroveId).HasColumnName("TrialTroveID");

                entity.HasOne(d => d.IndicationRec).WithMany(p => p.Trials)
                    .HasForeignKey(d => d.IndicationRecId)
                    .HasConstraintName("FK__Trials__Indicati__3FAA4F7B");
            });

            modelBuilder.Entity<TrialDataDesc>(entity =>
            {
                entity.HasKey(e => e.TrialDescId);

                entity.ToTable("TrialDataDesc");

                entity.Property(e => e.TrialDescId).HasColumnName("TrialDescID");
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.EffectId).HasColumnName("EffectID");
                entity.Property(e => e.EndpointId).HasColumnName("EndpointID");
                entity.Property(e => e.Grp1Measure).HasColumnType("sql_variant");
                entity.Property(e => e.Grp1Pvalue)
                    .HasColumnType("sql_variant")
                    .HasColumnName("Grp1PValue");
                entity.Property(e => e.Grp1Sign)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Grp2Measure).HasColumnType("sql_variant");
                entity.Property(e => e.Grp2Pvalue)
                    .HasColumnType("sql_variant")
                    .HasColumnName("Grp2PValue");
                entity.Property(e => e.Grp2Sign)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Grp3Measure).HasColumnType("sql_variant");
                entity.Property(e => e.Grp3Pvalue)
                    .HasColumnType("sql_variant")
                    .HasColumnName("Grp3PValue");
                entity.Property(e => e.Grp3Sign)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Grp4Measure).HasColumnType("sql_variant");
                entity.Property(e => e.Grp4Pvalue)
                    .HasColumnType("sql_variant")
                    .HasColumnName("Grp4PValue");
                entity.Property(e => e.Grp4Sign)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Grp5Measure).HasColumnType("sql_variant");
                entity.Property(e => e.Grp5Pvalue)
                    .HasColumnType("sql_variant")
                    .HasColumnName("Grp5PValue");
                entity.Property(e => e.Grp5Sign)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.Grp6Measure).HasColumnType("sql_variant");
                entity.Property(e => e.Grp6Pvalue)
                    .HasColumnType("sql_variant")
                    .HasColumnName("Grp6PValue");
                entity.Property(e => e.Grp6Sign)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
                entity.Property(e => e.MeasureTypeId).HasColumnName("MeasureTypeID");
                entity.Property(e => e.TrialDataId).HasColumnName("TrialDataID");

                entity.HasOne(d => d.TrialData).WithMany(p => p.TrialDataDescs)
                    .HasForeignKey(d => d.TrialDataId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrialDataDesc_TrialData");
            });

            modelBuilder.Entity<TrialDataEffectGroupType>(entity =>
            {
                entity.HasKey(e => e.EffectGroupTypeId);

                entity.ToTable("TrialDataEffectGroupType");

                entity.Property(e => e.EffectGroupTypeId).HasColumnName("EffectGroupTypeID");
                entity.Property(e => e.EffectGroupType)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TrialDataEffectType>(entity =>
            {
                entity.HasKey(e => e.EffectId);

                entity.ToTable("TrialDataEffectType");

                entity.Property(e => e.EffectId).HasColumnName("EffectID");
                entity.Property(e => e.EffectGroupTypeId).HasColumnName("EffectGroupTypeID");
                entity.Property(e => e.EffectName).HasMaxLength(100);
            });

            modelBuilder.Entity<TrialDataEndPointType>(entity =>
            {
                entity.HasKey(e => e.EndPointId);

                entity.ToTable("TrialDataEndPointType");

                entity.Property(e => e.EndPointId).HasColumnName("EndPointID");
                entity.Property(e => e.EndPointName).HasMaxLength(100);
            });

            modelBuilder.Entity<TrialDataGroup>(entity =>
            {
                entity.HasKey(e => e.TrialGroupId);

                entity.ToTable("TrialDataGroup");

                entity.Property(e => e.TrialGroupId).HasColumnName("TrialGroupID");
                entity.Property(e => e.GroupId).HasColumnName("GroupID");
                entity.Property(e => e.TreatDesc)
                    .HasMaxLength(3000)
                    .IsUnicode(false);
                entity.Property(e => e.TrialDataId).HasColumnName("TrialDataID");

                entity.HasOne(d => d.TrialData).WithMany(p => p.TrialDataGroups)
                    .HasForeignKey(d => d.TrialDataId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrialDataGroup_TrialData");
            });

            modelBuilder.Entity<TrialDataGroupType>(entity =>
            {
                entity.HasKey(e => e.GroupTypeId);

                entity.ToTable("TrialDataGroupType");

                entity.Property(e => e.GroupTypeId).HasColumnName("GroupTypeID");
                entity.Property(e => e.GroupType).HasMaxLength(100);
            });

            modelBuilder.Entity<TrialDataMeasureType>(entity =>
            {
                entity.HasKey(e => e.MeasureTypeId);

                entity.ToTable("TrialDataMeasureType");

                entity.Property(e => e.MeasureTypeId).HasColumnName("MeasureTypeID");
                entity.Property(e => e.MeasureName).HasMaxLength(100);
            });

            modelBuilder.Entity<TrialDatum>(entity =>
            {
                entity.HasKey(e => e.TrialDataId);

                entity.Property(e => e.TrialDataId).HasColumnName("TrialDataID");
                entity.Property(e => e.EventId).HasColumnName("EventID");
                entity.Property(e => e.Grp1Id).HasColumnName("Grp1ID");
                entity.Property(e => e.Grp2Id).HasColumnName("Grp2ID");
                entity.Property(e => e.Grp3Id).HasColumnName("Grp3ID");
                entity.Property(e => e.Grp4Id).HasColumnName("Grp4ID");
                entity.Property(e => e.Grp5Id).HasColumnName("Grp5ID");
                entity.Property(e => e.Grp6Id).HasColumnName("Grp6ID");

                entity.HasOne(d => d.Event).WithMany(p => p.TrialData)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TrialData_DrugEvents");
            });

            modelBuilder.Entity<TrialEvent>(entity =>
            {
                entity.HasKey(e => e.TrialEventsId);

                entity.Property(e => e.TrialEventsId).HasColumnName("TrialEventsID");
                entity.Property(e => e.EventId).HasColumnName("EventID");
                entity.Property(e => e.TrialId).HasColumnName("TrialID");

                entity.HasOne(d => d.Event).WithMany(p => p.TrialEvents)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.Trial).WithMany(p => p.TrialEvents)
                    .HasForeignKey(d => d.TrialId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
