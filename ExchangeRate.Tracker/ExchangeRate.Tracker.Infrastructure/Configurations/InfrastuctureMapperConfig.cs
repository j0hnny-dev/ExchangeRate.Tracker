using AutoMapper;
using ExchangeRate.Tracker.Domain.Currencies;
using ExchangeRate.Tracker.Domain.ExchangeRates;
using ExchangeRate.Tracker.Infrastructure.Models;

namespace ExchangeRate.Tracker.Infrastructure.Configurations
{
    public class InfrastuctureMapperConfig : Profile
    {
        public InfrastuctureMapperConfig()
        {
            CreateMap<ExchangeRateStoreModel, ExchangeRateEntity>()
                .ForMember(dst => dst.Id, opts => opts.MapFrom(src => new ExchangeRateId(src.Id.ToString())))
                .ForMember(dst => dst.TradingDate, opts => opts.MapFrom(src => src.TradingDate))
                .ForMember(dst => dst.Store, opts => opts.MapFrom(src => src.Store))
                .ForMember(dst => dst.Currency, opts => opts.MapFrom(src => new Currency(src.Currency)))
                .ForMember(dst => dst.Value, opts => opts.MapFrom(src => src.Value))
                .ForMember(dst => dst.Comment, opts => opts.MapFrom(src => src.Comment))
                .ReverseMap()
                .ForMember(dst => dst.Currency, opts => opts.MapFrom(src => src.Currency.Name))
                .ForMember(dst => dst.Id, opts => opts.MapFrom(src => int.Parse(src.Id.Value)));
        }
    }
}
