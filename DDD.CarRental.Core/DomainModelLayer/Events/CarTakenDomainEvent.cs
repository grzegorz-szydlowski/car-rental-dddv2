using System;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.SharedKernel.DomainModelLayer.Implementations;

namespace DDD.CarRental.Core.DomainModelLayer.Events;

public class CarTakenDomainEvent : DomainEvent
{
    public Rental Rental { get; private set; }

    public CarTakenDomainEvent(Rental rental)
    {
        this.Rental = rental;
    }
}