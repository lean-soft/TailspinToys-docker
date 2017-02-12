using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Tailspin.Model {
    [DataContract]
    public class ProductDescriptor {
        string _title;
        string _body;
        string _languageCode="en";

        public string Title {
            get {
                return _title;
            }
        }
        public string Body {
            get {
                return _body;
            }
        }
        bool _isDefault = false;
        public bool IsDefault {
            get {
                return _isDefault;
            }
        }
        public string LanguageCode {
            get {
                return _languageCode;
            }
        }

        public ProductDescriptor() { }
        public ProductDescriptor(string title, string body):this(title,body,false,"en") {}

        public ProductDescriptor(string title, string body, bool isDefault,string languageCode) {
            _title = title;
            _body = body;
            _isDefault = isDefault;
            _languageCode = languageCode;
        }

    }
}
