using System;
using System.Collections.Generic;

namespace GoodreadsDataAnalysis.Models
{
    public partial class GoodreadsBook
    {
        public short BookId { get; set; }
        public int GoodreadsBookId { get; set; }
        public int BestBookId { get; set; }
        public int WorkId { get; set; }
        public short BooksCount { get; set; }
        public string? Isbn { get; set; }
        public string? Isbn13 { get; set; }
        public string Authors { get; set; } = null!;
        public double? OriginalPublicationYear { get; set; }
        public string? OriginalTitle { get; set; }
        public string Title { get; set; } = null!;
        public string? LanguageCode { get; set; }
        public double AverageRating { get; set; }
        public int RatingsCount { get; set; }
        public int WorkRatingsCount { get; set; }
        public int WorkTextReviewsCount { get; set; }
        public int Ratings1 { get; set; }
        public int Ratings2 { get; set; }
        public int Ratings3 { get; set; }
        public int Ratings4 { get; set; }
        public int Ratings5 { get; set; }
        public string ImageUrl { get; set; } = null!;
        public string SmallImageUrl { get; set; } = null!;
    }
}
