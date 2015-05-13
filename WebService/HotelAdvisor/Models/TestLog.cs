using System;
using System.ComponentModel.DataAnnotations;

namespace HotelAdvisor.Models
{
    public class TestLog
    {
        [Key]
        public int Id { get; set; }

        public DateTime LogTime { get; set; }

        [StringLength(200)]
        public string TraceKey { get; set; }

        public string LogText { get; set; }
    }
}