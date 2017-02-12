using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {

    public class Package {

        public int HeightInInches { get; set; }
        public int WidthInInches { get; set; }
        public int LengthInInches { get; set; }
        public int WeightInPounds { get; set; }
        public string SKU { get; set; }
        public int ItemsInPackage { get; set; }
        public int CubicInches {
            get {
                return HeightInInches * WidthInInches * LengthInInches;
            }
        }

    }
}
