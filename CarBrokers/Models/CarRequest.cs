using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarBrokers.Models {
    public class CarRequest {
        public int ID { get; set; }
        public int CarID { get; set; }
        public virtual Car ChooseCar { get; set; }
        public int Price { get; set; }
        public string CustomerID { get; set; }
        public string BrokerID { get; set; }
    }
}