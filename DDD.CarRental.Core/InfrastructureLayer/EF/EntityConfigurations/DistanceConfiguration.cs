using DDD.CarRental.Core.DomainModelLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.CarRental.Core.InfrastructureLayer.EF
{
    public class DistanceConfiguration : IEntityTypeConfiguration<Distance>
    {
        public void Configure(EntityTypeBuilder<Distance> builder)
        {
            builder.Property<long>("Id").IsRequired();
            builder.HasKey("Id"); 

            builder.Property(d => d.Value)
                .IsRequired();

            builder.Property(d => d.Unit)
                .IsRequired()
                .HasMaxLength(10);


            builder.Property<long?>("CarId");
        }
    }
}