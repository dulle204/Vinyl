using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Vinyl.Data.Entities;

namespace Vinyl.Data
{
    public class VinylContext : DbContext, IVinylContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Log> Logs { get; set; }

        public VinylContext(DbContextOptions options)
            : base(options)
        {
            
        }
    }
}
