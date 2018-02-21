using System;
namespace test.Data
{
    public class BaseEntity
    {
        public int Id { get; set; }  
        public DateTime ModifiedDate { get; set; }  
        public string IPAddress { get; set; } 
    }
}