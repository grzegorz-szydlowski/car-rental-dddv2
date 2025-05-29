using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.SharedKernel.DomainModelLayer.Implementations;

namespace DDD.CarRental.Core.DomainModelLayer.Policies;

public class NormalRentalPolicy : IRentalPolicy
{
    public string Name { get; }
    public NormalRentalPolicy()
    {
        this.Name = "Standard discount policy";
    }
    public Money CalculateDiscount(Money total, long numOfMinutes, Money unitPrice)
    {
        decimal percent = 0.01m;
        return total.MultiplyBy(percent);
    }
}