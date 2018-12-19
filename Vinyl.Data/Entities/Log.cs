using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;

namespace Vinyl.Data.Entities
{
    [Table("Log")]
    public class Log
    {
        public Guid Id { get; set; }

        public Int64 WorkerId { get; set; }

        public DateTime Date { get; set; }

        public decimal Hours { get; set; }

        public decimal SpecialHours { get; set; }
    }
}
