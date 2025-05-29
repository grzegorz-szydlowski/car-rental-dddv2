using DDD.CarRental.Core.DomainModelLayer.Events;
using DDD.SharedKernel.DomainModelLayer;
using System;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.SharedKernel.ApplicationLayer;

namespace DDD.CarRental.Core.InfrastructureLayer.DomainEventHandlers
{
    public class CarReturnedEventHandler : IEventHandler<CarReturnedDomainEvent>
    {
        private ICarRepository _carRepository;

        public CarReturnedEventHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public void Handle(CarReturnedDomainEvent domainEvent)
        {
            var car = _carRepository.Get(domainEvent.Car.Id);
            car.SetAsAvailable();
        }
    }
}