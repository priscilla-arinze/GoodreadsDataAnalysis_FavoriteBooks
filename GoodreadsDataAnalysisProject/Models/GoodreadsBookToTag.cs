using System;
using System.Collections.Generic;

namespace GoodreadsDataAnalysis.Models
{
    public partial class GoodreadsBookToTag
    {
        public int GoodreadsBookId { get; set; }
        public int TagId { get; set; }
        public int? Count { get; set; }
    }
}
