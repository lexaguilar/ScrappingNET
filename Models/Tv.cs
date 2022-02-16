using System;
using System.Collections.Generic;

#nullable disable

namespace scrapper.Models
{
    public partial class Tv
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PriceString { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
