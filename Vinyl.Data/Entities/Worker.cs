using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text;
using Vinyl.Data.Entities.Enums;

namespace Vinyl.Data.Entities
{
    [Table("Worker")]
    public class Worker
    {
        public Int64 Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }  

        public string Position { get; set; }

        public string Role { get; set; }
    }
}
