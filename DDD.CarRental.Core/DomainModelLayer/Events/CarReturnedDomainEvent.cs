using System;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.SharedKernel.DomainModelLayer.Implementations;

namespace DDD.CarRental.Core.DomainModelLayer.Events;

public class CarReturnedDomainEvent : DomainEvent
{
    public Car Car { get; private set; }

    public CarReturnedDomainEvent(Car car)
    {
        this.Car = car;
    }
}