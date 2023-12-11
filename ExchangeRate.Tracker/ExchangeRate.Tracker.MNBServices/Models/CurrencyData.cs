using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExchangeRate.Tracker.MNBServices.Models
{
    [XmlRoot("MNBCurrencies")]
    public class CurrencyData
    {
        [XmlArray("Currencies")]
        [XmlArrayItem("Curr")]
        public List<string> Currencies { get; set; }
    }
}
