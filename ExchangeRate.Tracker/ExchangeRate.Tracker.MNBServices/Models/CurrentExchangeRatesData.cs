using System.Xml.Serialization;

namespace ExchangeRate.Tracker.MNBServices.Models
{
    [XmlRoot("MNBCurrentExchangeRates")]
    public class CurrentExchangeRatesData
    {
        [XmlElement("Day")]
        public ExchangeDateData Date { get; set; }
    }
}
