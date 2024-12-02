using System;
using Coworking.Models;

namespace Coworking.Models
{   

public class User
{
    public User()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
        
    }
    
        public string? Name  {get; set;}
        public string? Id {get; set;}
        public string? Email {get; set;}
        public int? Cellphone {get; set;}
        public string? TaxNumber {get; set;}
        public string? Password {get; set;}
        public  DateTime? CriadoEm {get; set;}
    
    }
}