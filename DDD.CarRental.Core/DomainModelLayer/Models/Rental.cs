using DDD.SharedKernel.DomainModelLayer;
using DDD.SharedKernel.DomainModelLayer.Implementations;
using System;
using DDD.CarRental.Core.DomainModelLayer.Events;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using Money = DDD.SharedKernel.DomainModelLayer.Implementations.Money;

namespace DDD.CarRental.Core.DomainModelLayer.Models
{
    public class Rental : Entity, IAggregateRoot
    {
        public long CarId { get; protected set; }
        public long DriverId { get; protected set; }

        public DateTime Started { get; protected set; }
        public DateTime? Finished { get; protected set; }

        public Money Total { get; protected set; }
        private IRentalPolicy _rentalPolicy;

        protected Rental() { }

        public Rental(long id, long carId, long driverId, DateTime started)
            : base(id)
        {
            CarId = carId;
            DriverId = driverId;
            Started = started;
            Total = Money.Zero;
            this.AddDomainEvent(new CarTakenDomainEvent(this));
        }
        
        public void RegisterPolicy(IRentalPolicy policy)
        {
            this._rentalPolicy = policy ?? throw new ArgumentNullException("Empty discount policy");
        }

        public void EndRental(DateTime endTime, decimal pricePerMinute, int freeMinutes)
        {
            if (Finished.HasValue)
                throw new InvalidOperationException("Rental is already ended.");

            if (endTime < Started)
                throw new ArgumentException("End time cannot be before start time.");

            Finished = endTime;

            var totalMinutes = (int)Math.Ceiling((Finished.Value - Started).TotalMinutes);
            var chargeableMinutes = Math.Max(0, totalMinutes - freeMinutes);
            Total = new Money(chargeableMinutes * pricePerMinute, "PLN");
            if (this._rentalPolicy != null)
            {
                Money discount = this._rentalPolicy.CalculateDiscount(this.Total, chargeableMinutes);
                Total = (discount > Total) ? Money.Zero : Total - discount;
            }
        }
    }
}
