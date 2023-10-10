using System;
using System.Collections.Generic;

namespace GoodreadsDataAnalysis.Models
{
    public partial class GoodreadsUserBookRating
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public byte Rating { get; set; }
    }
}
