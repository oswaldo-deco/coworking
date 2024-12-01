using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Models
{
    public class Spaces
    {
        public Spaces()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; } 
        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerHour { get; set; }
       
 }

}