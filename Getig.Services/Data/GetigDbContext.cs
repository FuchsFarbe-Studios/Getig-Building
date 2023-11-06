using System.Reflection;
using EntityFrameworkCore.Jet.Data;
using Getig.Models.Lang;
using Getig.Models.Lookups;
using Microsoft.EntityFrameworkCore;

namespace Getig.Services.Data
{
    public class GetigDbContext : DbContext
    {
        public string DbPath { get; set; }

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
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string solutionFolder = Directory.GetParent(Directory.GetParent(Directory.GetParent(assemblyFolder).FullName).FullName).FullName;
            string dbRelativePath = @"Data\GetigDb.accdb";
            string dbPath = Path.Combine(solutionFolder, dbRelativePath);
            DbPath = dbPath;
        }


        public GetigDbContext(string path)
        {
            DbPath = path;
        }

        /// <summary>
        ///     Database set for <see cref="ConLang" />.
        /// </summary>
        /// <summary>
        ///     Table of all Languages.
        /// </summary>
        public virtual DbSet<ConLang> Languages { get; set; }

        /// <summary>
        ///     Table of GrammarRule's Elements.
        /// </summary>
        public virtual DbSet<Element> Elements { get; set; }

        /// <summary>
        ///     Table of Language's Phonemes.
        /// </summary>
        public virtual DbSet<Phoneme> Phonemes { get; set; }

        /// <summary>
        ///     Table of Language's Syllables.
        /// </summary>
        public virtual DbSet<Syllable> Syllables { get; set; }

        /// <summary>
        ///     Table of constructed Words.
        /// </summary>
        public virtual DbSet<Word> Words { get; set; }

        /// <summary>
        ///     Table of Orthography Rules.
        /// </summary>
        public virtual DbSet<OrthographyRule> OrthographyRules { get; set; }

        /// <summary>
        ///     Table of Grammar Rules.
        /// </summary>
        public virtual DbSet<GrammarRule> GrammarRules { get; set; }

        /// <summary>
        /// Gets or sets a collection of LkPhoneme entities.
        /// </summary>
        public DbSet<LkPhoneme> LkPhonemes { get; set; }

        /// <summary>
        /// Gets or sets a collection of LkDictionaryWord entities.
        /// </summary>
        public DbSet<LkDictionaryWord> LkDictionaryWords { get; set; }

        /// <summary>
        /// Gets or sets a collection of LkPartOfSpeech entities.
        /// </summary>
        public DbSet<LkPartOfSpeech> LkPartsOfSpeech { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseJet(DbPath, DataAccessProviderType.Odbc);
            optionsBuilder.EnableDetailedErrors();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ConLang>(entity =>
                                         {
                                             entity.HasKey(e => e.ConLangId);
                                             entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

                                             // Define complex type relationships here
                                             entity.HasMany(e => e.Phonemes)
                                                   .WithOne(e => e.ConLang)
                                                   .HasForeignKey(e => e.ConLangId);

                                             entity.HasMany(e => e.Syllables)
                                                   .WithOne(e => e.ConLang)
                                                   .HasForeignKey(e => e.ConLangId);

                                             entity.HasMany(e => e.Words)
                                                   .WithOne(e => e.ConLang)
                                                   .HasForeignKey(e => e.ConLangId);

                                             entity.HasMany(e => e.OrthographyRules)
                                                   .WithOne(e => e.ConLang)
                                                   .HasForeignKey(e => e.ConLangId);
                                         });

            modelBuilder.Entity<Phoneme>(entity =>
                                         {
                                             entity.HasKey(e => new {e.ConLangId, e.PhonemeId });
                                             entity.Property(e => e.Sound)
                                                   .IsRequired()
                                                   .HasMaxLength(50);
                                             entity.HasOne(p => p.ConLang)
                                                   .WithMany()
                                                   .HasForeignKey(p => p.ConLangId);
                                             entity.HasOne(p => p.LkPhoneme)
                                                   .WithOne()
                                                   .HasForeignKey<Phoneme>(p => p.PhonemeId);

                                         });

            modelBuilder.Entity<Syllable>(entity =>
                                          {
                                              entity.HasKey(e => e.SyllableId);
                                              entity.Property(e => e.Pattern).IsRequired().HasMaxLength(100);

                                              entity.HasMany(e => e.Words)
                                                    .WithOne(e => e.Syllable)
                                                    .HasForeignKey(e => e.SyllableId);
                                          });

            modelBuilder.Entity<Word>(entity =>
                                      {
                                          entity.HasKey(e => e.WordId);
                                          entity.Property(e => e.Value).IsRequired().HasMaxLength(100);
                                      });

            modelBuilder.Entity<OrthographyRule>(entity =>
                                                 {
                                                     entity.HasKey(e => e.OrthographyRuleId);
                                                     entity.Property(e => e.Pronunciation).IsRequired().HasMaxLength(100);
                                                     entity.Property(e => e.Replacement).HasMaxLength(100);
                                                 });

            modelBuilder.Entity<GrammarRule>(entity =>
                                             {
                                                 entity.HasKey(e => e.GrammarID);
                                                 entity.Property(e => e.Description).IsRequired().HasMaxLength(500);

                                                 entity.HasOne(e => e.ConLang)
                                                       .WithMany(l => l.GrammarRules)
                                                       .HasForeignKey(e => e.LanguageId);
                                             });

            modelBuilder.Entity<GrammarRuleElement>(entity =>
                                                    {
                                                        entity.HasKey(e => new { e.GrammarRuleId, e.ElementId });

                                                        entity.HasOne(e => e.GrammarRule)
                                                              .WithMany(g => g.GrammarRuleElements)
                                                              .HasForeignKey(e => e.GrammarRuleId);

                                                        entity.HasOne(e => e.Element)
                                                              .WithMany(el => el.GrammarRuleElements)
                                                              .HasForeignKey(e => e.ElementId);

                                                        entity.Property(e => e.Order).IsRequired();
                                                    });

            modelBuilder.Entity<LkPhoneme>(entity =>
                                           {
                                               entity.ToTable("LkPhonemes");
                                           });

            modelBuilder.Entity<LkVowel>()
                        .ToTable("LkVowels");

            modelBuilder.Entity<LkConsonant>()
                        .ToTable("LkConsonants");
        }
    }
}