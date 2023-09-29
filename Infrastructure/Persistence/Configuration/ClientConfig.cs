using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Domain.Entities;


namespace Persistence.Configuration
{
   public class ClientConfig: IEntityTypeConfiguration<Client>
   {
       public void Configure(EntityTypeBuilder<Client> builder){
          builder.ToTable("Clients");

          builder.HasKey(p => p.Id);

          builder.Property(p => p.FirstName)
            .HasMaxLength(80)
            .IsRequired();

          builder.Property(p => p.LastName)
            .HasMaxLength(80)
            .IsRequired();

          builder.Property(p => p.BirthDate)
            .IsRequired();

          builder.Property(p => p.Phone)
            .HasMaxLength(9)
            .IsRequired();

          builder.Property(p => p.Email)
            .HasMaxLength(100);

          builder.Property(p => p.Address)
            .HasMaxLength(120)
            .IsRequired();

          builder.Property(p => p.Age);

          builder.Property(p => p.CreatedBy)
            .HasMaxLength(30);

          builder.Property(p => p.LastModifiedBy)
            .HasMaxLength(30);
       }
   } 
}
