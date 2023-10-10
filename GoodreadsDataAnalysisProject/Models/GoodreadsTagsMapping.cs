using System;
using System.Collections.Generic;

namespace GoodreadsDataAnalysis.Models
{
    public partial class GoodreadsTagsMapping
    {
        public int TagId { get; set; }
        public string TagName { get; set; } = null!;
    }
}
