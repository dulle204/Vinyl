using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Vinyl.Data.Entities;

namespace Vinyl.Data
{
    public interface IVinylContext
    {
        DbSet<Worker> Workers { get; set; }
        DbSet<Log> Logs { get; set; }
        int SaveChanges();
        void Dispose();
        object Find(Type entityType, params object[] keyValues);
        Task<object> FindAsync(Type entityType, params object[] keyValues);
        Task<object> FindAsync(Type entityType, object[] keyValues, CancellationToken cancellationToken);
    }
}