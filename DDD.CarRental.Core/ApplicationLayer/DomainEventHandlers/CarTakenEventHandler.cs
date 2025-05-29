using DDD.CarRental.Core.DomainModelLayer.Events;
using DDD.SharedKernel.DomainModelLayer;
using System;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.SharedKernel.ApplicationLayer;

namespace DDD.CarRental.Core.InfrastructureLayer.DomainEventHandlers
{
    public class CarTakenEventHandler : IEventHandler<CarTakenDomainEvent>
    {
        private ICarRepository _carRepository;

        public CarTakenEventHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public void Handle(CarTakenDomainEvent domainEvent)
        {
            var car = _carRepository.Get(domainEvent.Rental.CarId);
            car.SetAsRented();
        }
    }
}