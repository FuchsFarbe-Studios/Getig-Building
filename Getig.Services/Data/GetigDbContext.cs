using Getig.Models.Language;
using Microsoft.EntityFrameworkCore;

namespace Getig.Services.Data
{
    public class GetigDbContext : DbContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GetigDbContext" /> class.
        /// </summary>
        /// <param name="options">Db context options.</param>
        public GetigDbContext(DbContextOptions<GetigDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GetigDbContext" /> class.
        /// </summary>
        public GetigDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string dbPath = "C:\\Users\\fuchs\\RiderProjects\\Getig-Building\\Getig.Services\\Data\\GetigDb.accdb";
            optionsBuilder.UseJet(dbPath);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Language.Language>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

                // Define complex type relationships here
                entity.HasMany(e => e.Phonemes)
                    .WithOne(e => e.Language)
                    .HasForeignKey(e => e.LanguageId);

                entity.HasMany(e => e.Syllables)
                    .WithOne(e => e.Language)
                    .HasForeignKey(e => e.LanguageId);

                entity.HasMany(e => e.Words)
                    .WithOne(e => e.Language)
                    .HasForeignKey(e => e.LanguageId);

                entity.HasMany(e => e.OrthographyRules)
                    .WithOne(e => e.Language)
                    .HasForeignKey(e => e.LanguageId);
            });

            modelBuilder.Entity<Phoneme>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Sound).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Syllable>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Pattern).IsRequired().HasMaxLength(100);

                entity.HasMany(e => e.Words)
                    .WithOne(e => e.Syllable)
                    .HasForeignKey(e => e.SyllableId);
            });

            modelBuilder.Entity<Word>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Value).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<OrthographyRule>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.MatchPattern).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Replacement).HasMaxLength(100);
            });
        }
    }
}