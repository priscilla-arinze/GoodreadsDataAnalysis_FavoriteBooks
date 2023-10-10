using System;
using System.Collections.Generic;
using GoodreadsDataAnalysis.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GoodreadsDataAnalysis.Data
{
    public partial class BooksDBContext : DbContext
    {
        public BooksDBContext()
        {
        }

        public BooksDBContext(DbContextOptions<BooksDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GoodreadsBook> GoodreadsBooks { get; set; } = null!;
        public virtual DbSet<GoodreadsBookToTag> GoodreadsBookToTags { get; set; } = null!;
        public virtual DbSet<GoodreadsTagsMapping> GoodreadsTagsMappings { get; set; } = null!;
        public virtual DbSet<GoodreadsUserBookRating> GoodreadsUserBookRatings { get; set; } = null!;
        public virtual DbSet<GoodreadsUserBooksToRead> GoodreadsUserBooksToReads { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GoodreadsBook>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.Property(e => e.BookId)
                    .ValueGeneratedNever()
                    .HasColumnName("book_id");

                entity.Property(e => e.Authors)
                    .HasMaxLength(800)
                    .HasColumnName("authors");

                entity.Property(e => e.AverageRating).HasColumnName("average_rating");

                entity.Property(e => e.BestBookId).HasColumnName("best_book_id");

                entity.Property(e => e.BooksCount).HasColumnName("books_count");

                entity.Property(e => e.GoodreadsBookId).HasColumnName("goodreads_book_id");

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(100)
                    .HasColumnName("image_url");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(20)
                    .HasColumnName("isbn");

                entity.Property(e => e.Isbn13)
                    .HasMaxLength(50)
                    .HasColumnName("isbn13");

                entity.Property(e => e.LanguageCode)
                    .HasMaxLength(20)
                    .HasColumnName("language_code");

                entity.Property(e => e.OriginalPublicationYear).HasColumnName("original_publication_year");

                entity.Property(e => e.OriginalTitle)
                    .HasMaxLength(200)
                    .HasColumnName("original_title");

                entity.Property(e => e.Ratings1).HasColumnName("ratings_1");

                entity.Property(e => e.Ratings2).HasColumnName("ratings_2");

                entity.Property(e => e.Ratings3).HasColumnName("ratings_3");

                entity.Property(e => e.Ratings4).HasColumnName("ratings_4");

                entity.Property(e => e.Ratings5).HasColumnName("ratings_5");

                entity.Property(e => e.RatingsCount).HasColumnName("ratings_count");

                entity.Property(e => e.SmallImageUrl)
                    .HasMaxLength(100)
                    .HasColumnName("small_image_url");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .HasColumnName("title");

                entity.Property(e => e.WorkId).HasColumnName("work_id");

                entity.Property(e => e.WorkRatingsCount).HasColumnName("work_ratings_count");

                entity.Property(e => e.WorkTextReviewsCount).HasColumnName("work_text_reviews_count");
            });

            modelBuilder.Entity<GoodreadsBookToTag>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.GoodreadsBookId).HasColumnName("goodreads_book_id");

                entity.Property(e => e.TagId).HasColumnName("tag_id");
            });

            modelBuilder.Entity<GoodreadsTagsMapping>(entity =>
            {
                entity.HasKey(e => e.TagId);

                entity.ToTable("GoodreadsTagsMapping");

                entity.Property(e => e.TagId)
                    .ValueGeneratedNever()
                    .HasColumnName("tag_id");

                entity.Property(e => e.TagName)
                    .HasMaxLength(50)
                    .HasColumnName("tag_name");
            });

            modelBuilder.Entity<GoodreadsUserBookRating>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<GoodreadsUserBooksToRead>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GoodreadsUserBooksToRead");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
