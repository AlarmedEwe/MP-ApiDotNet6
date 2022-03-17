using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.ApiDotNet6.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP.ApiDotNet6.Infra.Data.Maps;
public class PurchaseMap : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("Compra");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasColumnName("IdCompra")
            .UseMySqlIdentityColumn();

        builder.Property(x => x.PersonId)
            .HasColumnName("IdPessoa");

        builder.Property(x => x.ProductId)
            .HasColumnName("IdProduto");

        builder.HasOne(x => x.Person)
            .WithMany(p => p.Purchases);

        builder.HasOne(x => x.Product)
            .WithMany(p => p.Purchases);
    }
}
