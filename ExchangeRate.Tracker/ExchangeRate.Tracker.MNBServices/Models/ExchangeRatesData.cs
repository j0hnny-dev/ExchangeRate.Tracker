using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExchangeRate.Tracker.MNBServices.Models
{
    [XmlRoot("MNBExchangeRates")]
    public class ExchangeRatesData
    {
        [XmlElement("Day")]
        public List<ExchangeDateData> DaysData { get; set; }
    }
}
