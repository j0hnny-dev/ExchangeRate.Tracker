using AutoMapper;
using ExchangeRate.Tracker.ApplicationService.Currencies;
using ExchangeRate.Tracker.ApplicationService.ExchangeRates;
using ExchangeRate.Tracker.Domain.Currencies;
using ExchangeRate.Tracker.Domain.ExchangeRates;

namespace ExchangeRate.Tracker.ApplicationService.Configurations;

public class ApplicationServiceMapperConfiguration : Profile
{
    public ApplicationServiceMapperConfiguration()
    {
        CreateMap<CurrencyDto, Currency>().ReverseMap();

        CreateMap<ExchangeRateEntity, ExchangeRateDto>()
            .ForMember(dst => dst.Id, opts => opts.MapFrom(x => x.Id.Value))
            .ForMember(dst => dst.Day, opts => opts.MapFrom(x => x.TradingDate))
            .ForMember(dst => dst.Currency, opts => opts.MapFrom(x => x.Currency.Name))
            .ForMember(dst => dst.Value, opts => opts.MapFrom(x => x.Value))
            .ForMember(dst => dst.Comment, opts => opts.MapFrom(x => x.Comment));
    }
}
