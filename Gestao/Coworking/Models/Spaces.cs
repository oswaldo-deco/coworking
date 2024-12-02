using System;
using System.Collections.Generic;
using System.Linq;
using Coworking.Models;

namespace Coworking.Models
{
    public class Spaces
    {
        public Spaces()
        {
            Id = Guid.NewGuid().ToString();
            Name = string.Empty;
        }

        public string Id { get; set; } 
        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerHour { get; set; }
       
    }
}