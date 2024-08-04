using System;

namespace ConstructionTransaction.Models
{
    public class loginuseractivity
    {
        public Guid loginid { get; set; }
        public Guid userid { get; set; }
        public DateTime logintimestamp { get; set; }
    }
}