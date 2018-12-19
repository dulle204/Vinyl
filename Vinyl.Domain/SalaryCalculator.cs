using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using CommonServiceLocator;
using Vinyl.Data;
using Unity;
using Unity.ServiceLocation;

namespace Vinyl.Domain
{
    public class SalaryCalculator : ISalaryCalculator
    {
        private IUnitOfWork _unitOfWork;

        public SalaryCalculator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public decimal ActualMonthSalary(BigInteger workerId)
        {
            decimal salary = 0;


            var worker = _unitOfWork.WorkerRepository.GetWorkerById(workerId);
            var logs = _unitOfWork.WorkerRepository.WorkerLogsThisMonth(workerId);

            foreach (var item in logs)
            {
                salary += item.Hours * worker.Salary + item.SpecialHours * worker.Salary;
            }


            return salary;
        }
    }
}
