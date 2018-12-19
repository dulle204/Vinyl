using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using CommonServiceLocator;
using Microsoft.AspNetCore.Http;
using Vinyl.Data;
using Vinyl.Data.Entities;
using Vinyl.Domain.Contracts;

namespace Vinyl.Domain
{
    public interface IWorkersManager
    {
        IEnumerable<WorkerContract> GetWorkersWithSalaries();
        void InsertWorker(WorkerContract worker);
    }

    public class WorkersManager : IWorkersManager
    {
        private IUnitOfWork _unitOfWork;
        private ISalaryCalculator _salaryCalculator;

        public WorkersManager(IUnitOfWork unitOfWork,
                             ISalaryCalculator salaryCalculator)
        {
            _unitOfWork = unitOfWork;
            _salaryCalculator = salaryCalculator;
        }

        public IEnumerable<WorkerContract> GetWorkersWithSalaries()
        {
            List<WorkerContract> result = new List<WorkerContract>();
            using (_unitOfWork)
            {
                _salaryCalculator = new SalaryCalculator(_unitOfWork);

                var workers = _unitOfWork.WorkerRepository.GetAllWorkers();
                WorkerContract workerContract = null;
                foreach (var worker in workers)
                {
                    workerContract = new WorkerContract()
                    {
                        Id = worker.Id,
                        FirstName = worker.FirstName,
                        LastName = worker.LastName,
                        MonthSalary = _salaryCalculator.ActualMonthSalary(worker.Id),
                        Role = Enum.Parse<Role>(worker.Role.ToUpperInvariant()),
                        Position = Enum.Parse<Position>(worker.Position.ToUpperInvariant())
                    };

                    result.Add(workerContract);
                }
            }

            return result;
        }

        public void InsertWorker(WorkerContract worker)
        {
            Worker workerEntity = new Worker()
            {
                FirstName = worker.FirstName,
                LastName = worker.LastName,
                Position = worker.Position.ToString(),
                Salary = worker.MonthSalary,
                Role = worker.Role.ToString()
            };

            _unitOfWork.WorkerRepository.InsertWorker(workerEntity);
        }
    }
}