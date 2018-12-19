using System;
using System.Collections.Generic;
using System.Numerics;
using Vinyl.Data.Entities;

namespace Vinyl.Data.Repositories
{
    public interface IWorkerRepository
    {
        IEnumerable<Worker> GetAllWorkers();
        Worker GetWorkerById(BigInteger id);
        IEnumerable<Worker> SearchWorkers(Func<Worker, bool> q);
        IEnumerable<Log> WorkerLogsThisMonth(BigInteger workerId);
        void InsertWorker(Worker worker);
    }
}