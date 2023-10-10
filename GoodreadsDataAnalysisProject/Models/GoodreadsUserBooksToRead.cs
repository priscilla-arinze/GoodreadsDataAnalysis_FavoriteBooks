using System;
using System.Collections.Generic;

namespace GoodreadsDataAnalysis.Models
{
    public partial class GoodreadsUserBooksToRead
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
