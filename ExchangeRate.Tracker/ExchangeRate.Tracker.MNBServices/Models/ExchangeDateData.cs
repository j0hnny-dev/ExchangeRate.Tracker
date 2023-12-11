using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ExchangeRate.Tracker.MNBServices.Models
{
    public class ExchangeDateData
    {
        [XmlAttribute("date")]
        public DateTime Date { get; set; }

        [XmlElement("Rate")]
        public List<RateData> Rates { get; set; }
    }
}
