using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Vinyl.Domain.Contracts
{
    public class WorkerContract
    {
        public BigInteger Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal MonthSalary { get; set; }

        public Position Position { get; set; }

        public Role Role { get; set; }
    }
}
