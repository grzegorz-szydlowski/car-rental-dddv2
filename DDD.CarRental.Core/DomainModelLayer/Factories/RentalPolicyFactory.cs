using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDD.CarRental.Core.DomainModelLayer.Interfaces;
using DDD.CarRental.Core.DomainModelLayer.Models;
using DDD.CarRental.Core.DomainModelLayer.Policies;

namespace DDD.CarRental.Core.DomainModelLayer.Factories
{
    internal class RentalPolicyFactory
    {
        public IRentalPolicy Create(Driver driver)
        {
            IRentalPolicy rentalPolicy = new NormalRentalPolicy();
            if (driver.LicenceNumber.Contains("1"))
            {
                rentalPolicy = new SpecialRentalPolicy();
            }
            return rentalPolicy;
        }
    }
}
