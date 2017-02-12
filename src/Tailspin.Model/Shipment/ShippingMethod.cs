using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model
{
    [Serializable]
    public class ShippingMethod
    {

        int _id;
        public int ID
        {
            get
            {
                return _id;
            }
        }
        string _carrier;
        public string Carrier
        {
            get
            {
                return _carrier;
            }
        }
        string _serviceName;
        public string ServiceName
        {
            get
            {
                return _serviceName;
            }
        }
        decimal _ratePerPound;
        public decimal RatePerPound
        {
            get
            {
                return _ratePerPound;
            }
        }
        int _daysToDeliver;
        public int DaysToDeliver
        {
            get
            {
                return _daysToDeliver;
            }
        }

        public string Display {
            get {

                string shippingFormat = "{0}:{1} {2}";
                return string.Format(shippingFormat, Carrier, ServiceName, Cost.ToString("C"));

            }
        }
        decimal _baseRate;
        public decimal BaseRate {
            get {
                return _baseRate;
            }
        }
        //this is a placeholder field for the Shipping Service
        //to fill in
        public decimal Cost { get; set; }
        
      

        public ShippingMethod(int id, string carrier,string serviceName, 
            decimal ratePerPound, int daysToDeliver, decimal baseRate)
        {
            _id = id;
            _carrier = carrier;
            _serviceName = serviceName;
            _ratePerPound = ratePerPound;
            _daysToDeliver = daysToDeliver;
            _baseRate = baseRate;
        }


        public override string ToString() {

            return Display;
        }


    }

    

}
