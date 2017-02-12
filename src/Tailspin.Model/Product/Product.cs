using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tailspin.Infrastructure;
using System.Runtime.Serialization;

namespace Tailspin.Model {

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue"), DataContract]
    public enum InventoryStatus {
        InStock = 1,
        BackOrder = 2,
        PreOrder = 3,
        SpecialOrder = 4,
        Discontinued = 5,
        CurrentlyUnavailable = 6
    }

    [DataContract]
    public enum DeliveryMethod {
        None = 0,
        Shipped = 1,
        Download = 2
    }


    [DataContract]
    public class Product : EntityBase, IAggregateRoot {

        public Product(string sku) : this(sku, "", "", true, 0) { }
        public Product(string sku, string name, string blurb, bool isTaxable, decimal weightInPounds) :
            this(sku, name, blurb, isTaxable, weightInPounds, 1, DateTime.Now, true,true) { }

        public Product(string sku, string name, string blurb, bool isTaxable, decimal weightInPounds, int amountOnHand, DateTime dateAvailable, bool allowBackOrder,bool allowPreOrder)
            : base(sku) {

            SKU = sku;
            Name = name;
            Blurb = blurb;
            IsTaxable = isTaxable;
            WeightInPounds = weightInPounds;
            DateAvailable = dateAvailable;
            AllowBackOrder = allowBackOrder;
            AllowPreOrder = allowPreOrder;
            AmountOnHand = amountOnHand;
            CurrentInventory = InventoryState.SetState(this, amountOnHand, allowBackOrder, dateAvailable);
            Images = new List<Image>();
            RelatedProducts = new List<Product>();
            CrossSells = new List<Product>();
            Recommended = new List<Product>();

            OnCreated();

        }  
        public string SKU { get; set; }
        public string Name { get; set; }
        public string Blurb { get; set; }
        public decimal WeightInPounds { get; set; }
        public string Manufacturer { get; set; }
        public string EstimatedDelivery { get; set; }
        public bool IsTaxable { get; set; }
        public DeliveryMethod Delivery { get; set; }
        public InventoryStatus Inventory { get; set; }
        
        bool _allowBackOrder = false;
        public bool AllowBackOrder {
            get {
                return _allowBackOrder;
            }
            set {
                _allowBackOrder = value;
                OnInventoryFlagsChanged();
            }
        }        
        bool _allowPreOrder = false;
        public bool AllowPreOrder {
            get {
                return _allowPreOrder;
            }
            set {
                _allowPreOrder = value;
                OnInventoryFlagsChanged();
            }
        }

        int _amountOnHand = 0;
        public int AmountOnHand {
            get {
                return _amountOnHand;
            }
            set {
                _amountOnHand = value;
                OnInventoryChanged();
            }
        }
        public DateTime DateAvailable { get; set; }
        public decimal Price { get; set; }

        InventoryState _inventoryState = null;
        public InventoryState CurrentInventory {
            get {
                return _inventoryState;
            }
            set {
                _inventoryState = value;
                OnInventoryStatusChanged();
            }
        }
        
        public decimal DiscountPercent { get; set; }
        Image _defaultImage = null;
        public Image DefaultImage {
            get {
                if (_defaultImage == null) {
                    _defaultImage = this.Images.Count > 0 ? this.Images[0] : new Image("noimage.gif", "noimage.gif");
                }
                return _defaultImage;

            }
            set {
                _defaultImage = value;
            }
        }
        public decimal DiscountedPrice {
            get {
                //convert percent to rate
                decimal discountRate = 0;
                if (DiscountPercent > 0)
                    discountRate = DiscountPercent / 100;

                return Price - (discountRate * Price);
            }
        }
        public IList<Image> Images { get; set; }
        public IList<Product> RelatedProducts { get; set; }
        public IList<Product> CrossSells { get; set; }
        public IList<ProductDescriptor> Descriptors { get; set; }
        public IList<Product> Recommended { get; set; }

        protected override void Validate() {

            //need a SKU
            Validator.CheckNullOrEmptyString(x => x.SKU, this);

            //need a Name
            Validator.CheckNullOrEmptyString(x => x.Name, this);

            //Price must be greater than 0
            Validator.CheckGreaterThan(x => x.Price, this, 0);

        }


        #region Object overrides
        public override bool Equals(object obj) {
            if (obj is Product) {
                Product compareTo = (Product)obj;
                return compareTo.SKU == this.SKU;
            } else {
                return base.Equals(obj);
            }
        }

        public override string ToString() {
            return this.Name;
        }
        public override int GetHashCode() {
            return this.SKU.GetHashCode();
        }
        #endregion

        #region Events

        public event ProductCreatedEventHandler Created;
        internal virtual void OnCreated() {
            if (Created != null)
                Created(this, new EventArgs());
        }

        public event InventoryChangedEventHandler InventoryChanged;
        internal virtual void OnInventoryChanged() {
            if (InventoryChanged != null)
                InventoryChanged(this, new EventArgs());
        }
        public event InventoryFlagsEventHandler InventoryFlagsChanged;
        internal virtual void OnInventoryFlagsChanged() {
            if (InventoryFlagsChanged != null)
                InventoryFlagsChanged(this, new EventArgs());
        }
        public event InventoryStatusEventHandler InventoryStatusChanged;
        internal virtual void OnInventoryStatusChanged() {
            if (InventoryStatusChanged != null)
                InventoryStatusChanged(this, new EventArgs());
        }
        #endregion
    }
    public delegate void ProductCreatedEventHandler(object sender, EventArgs e);
    public delegate void InventoryChangedEventHandler(object sender, EventArgs e);
    public delegate void InventoryFlagsEventHandler(object sender, EventArgs e);
    public delegate void InventoryStatusEventHandler(object sender, EventArgs e);

}
