using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tailspin.Infrastructure;

namespace Tailspin.Infrastructure {
    [Serializable]
    public class User:EntityBase {

        public User() : base() { }
        public User(string userName) : this(userName, "", "", "") { }
        public User(string userName, string email, string first, string last):base(userName) {
            UserName = userName;
            FirstName = first;
            LastName = last;
            Email = email;
            LanguageCode = "en";
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LanguageCode { get; set; }
        public IList<Address> AddressBook { get; set; }
        Address _defaultAddress;
        public Address DefaultAddress {
            get {
                if (_defaultAddress == null) {
                    _defaultAddress = new Address();
                    if (this.AddressBook.Count > 0) {
                        _defaultAddress = this.AddressBook[0];
                    }
                }
                return _defaultAddress;
            }
            set {
                _defaultAddress = value;
            }
        }
        public string FullName {
            get {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }


        //NOTE: This right here is an example of not implementing a full DDD architecture
        //this is properly handled using the "Specification Pattern"
        //http://en.wikipedia.org/wiki/Specification_pattern
        //The formality, however, increases the LOC and can cause confusion for 
        //folks unfamiliar with the pattern. If you want to implement the Spec pattern
        //this class (and base class) would be the place to do just that

        protected override void Validate() {
           //user has to have a username
        //    if (string.IsNullOrEmpty(UserName))
        //        this.AddBrokenRule("User must have a UserName");
           
        //    //and email
        //    if (string.IsNullOrEmpty(Email))
        //        this.AddBrokenRule("User must have an Email address");
        }

    }
}
