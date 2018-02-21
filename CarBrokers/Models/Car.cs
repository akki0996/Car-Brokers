using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarBrokers.Models {
    public class Car {
        public int ID { get; set; }
        public int Price { get; set; }
        public String Make { get; set; }
        public String Model { get; set; }
        public int Year { get; set; }
        public int Miles { get; set; }
    }
}