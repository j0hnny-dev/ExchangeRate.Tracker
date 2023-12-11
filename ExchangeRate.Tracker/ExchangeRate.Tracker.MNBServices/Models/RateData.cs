using System.Xml.Serialization;

namespace ExchangeRate.Tracker.MNBServices.Models
{
    public class RateData
    {
        [XmlAttribute("unit")]
        public string Unit { get; set; }

        [XmlAttribute("curr")]
        public string Currency { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}
