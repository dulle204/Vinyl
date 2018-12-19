using System;
using Vinyl.Data.Repositories;

namespace Vinyl.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IWorkerRepository WorkerRepository { get; }
    }
}