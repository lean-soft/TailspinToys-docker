using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model {
    [Serializable]
    public class InStock : InventoryState {

        public InStock(Product item) {
            _item = item;
        }


    }
}
