using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Session
    {
        public Guid Id { get; set; } 
        public int UserId { get; set; }
        public string DeviceId { get; set; }
        public DateTime ExpirationTime { get; set; }
    }
}