using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExchangeRate.Tracker.Infrastructure.Models
{
    internal class ExchangeRateStoreModelConfiguration : IEntityTypeConfiguration<ExchangeRateStoreModel>
    {
        public void Configure(EntityTypeBuilder<ExchangeRateStoreModel> builder)
        {
            builder.ToTable("ExchangeRates");

            builder.HasKey(r => r.Id);
            
            builder.Property(r => r.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(r => r.Currency).HasColumnName("Currency").IsRequired();
            builder.Property(r => r.Value).HasColumnName("Value").HasPrecision(2).IsRequired();
            builder.Property(r => r.Comment).HasColumnName("Comment").HasMaxLength(100);
            builder.Property(r => r.TradingDate).HasColumnName("TradingDate").IsRequired();
            builder.Property(r => r.Store).HasColumnName("Store").IsRequired();
        }
    }
}
