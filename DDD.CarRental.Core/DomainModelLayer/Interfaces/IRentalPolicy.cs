using DDD.SharedKernel.DomainModelLayer.Implementations;

namespace DDD.CarRental.Core.DomainModelLayer.Interfaces;

public interface IRentalPolicy
{
    string Name { get; }
    Money CalculateDiscount(Money total, long numOfMinutes);
}