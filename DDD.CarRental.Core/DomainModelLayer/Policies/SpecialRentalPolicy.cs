using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.SharedKernel.DomainModelLayer.Implementations;

namespace DDD.CarRental.Core.DomainModelLayer.Policies;

public class SpecialRentalPolicy : IRentalPolicy
{
    public string Name { get; protected set; }

    public SpecialRentalPolicy()
    {
        this.Name = "Special discount policy";
    }

    public Money CalculateDiscount(Money total, long numOfMinutes, Money unitPrice)
    {
        decimal percent = 0.01m;
        if (numOfMinutes > 30)
            percent = 0.05m;

        return total.MultiplyBy(percent);
    }
}