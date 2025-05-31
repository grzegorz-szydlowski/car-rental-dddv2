using DDD.CarRental.Core.DomainModelLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.CarRental.Core.InfrastructureLayer.EF.EntityConfigurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> driverConfiguration)
        {
            driverConfiguration.HasKey(c => c.Id);

            driverConfiguration.Property(v => v.Id).ValueGeneratedNever();

            driverConfiguration.Ignore(c => c.DomainEvents);

            // ToDo: konfiguracja pozostalych elementów
            driverConfiguration.Property(c => c.FirstName)
        .IsRequired()
        .HasMaxLength(100);

            driverConfiguration.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(100);

            driverConfiguration.Property(c => c.LicenceNumber)
                .IsRequired()
                .HasMaxLength(20);

            driverConfiguration.Property(c => c.FreeMinutes)
                .IsRequired();
        }
    }

    
}
