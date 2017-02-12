using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tailspin.Infrastructure;
using System.Runtime.Serialization;

namespace Tailspin.Model {

    [DataContract]
    public class ProductCategory : EntityBase, IAggregateRoot {

        public ProductCategory(string code, string name)
            : base(code) {

            Code = code;
            Name = name;
            Products = new List<Product>();
           
            OnCreated();

        }  
        public string Code{ get; set; }
        public string Name { get; set; }
       
        
        public IList<Product> RelatedProducts { get; set; }
        public IList<Product> CrossSells { get; set; }
        public IList<ProductDescriptor> Descriptors { get; set; }
        public IList<Product> Products { get; set; }

        protected override void Validate() {

            //need a SKU
            Validator.CheckNullOrEmptyString(x => x.Code, this);

            //need a Name
            Validator.CheckNullOrEmptyString(x => x.Name, this);
        }


        #region Object overrides
        public override bool Equals(object obj) {
            if (obj is ProductCategory) {
                ProductCategory compareTo = (ProductCategory)obj;
                return compareTo.Code == this.Code;
            } else {
                return base.Equals(obj);
            }
        }

        public override string ToString() {
            return this.Name;
        }
        public override int GetHashCode() {
            return this.Code.GetHashCode();
        }
        #endregion

        #region Events

        public event ProductCategoryCreatedEventHandler Created;
        internal virtual void OnCreated() {
            if (Created != null)
                Created(this, new EventArgs());
        }
        #endregion
    }
    public delegate void ProductCategoryCreatedEventHandler(object sender, EventArgs e);
}
