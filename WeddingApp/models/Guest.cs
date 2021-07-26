using System;
using System.Collections.Generic;

#nullable disable

namespace WeddingApp.models
{
    public partial class Guest
    {
        public int IdGuests { get; set; }
        public string Name { get; set; }
        public string Attending { get; set; }
        public int? StarterChoiceId { get; set; }
        public int? MainChoiceId { get; set; }
        public int? DessertChoiceId { get; set; }
        public string Notes { get; set; }
        public int? AgeGroupId { get; set; }
        public string ContactNumber { get; set; }
    }
}
