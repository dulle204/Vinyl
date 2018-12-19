using System.Numerics;

namespace Vinyl.Domain
{
    public interface ISalaryCalculator
    {
        decimal ActualMonthSalary(BigInteger workerId);
    }
}