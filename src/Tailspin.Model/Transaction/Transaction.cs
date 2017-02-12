using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tailspin.Model
{




    [Serializable]
    public class Transaction
    {
        Guid _id;
        public Guid ID {
            get {
                return _id;
            }
        }
        Guid _orderID;
        public Guid OrderID {
            get {
                return _orderID;
            }
        }
        decimal _amount;
        public decimal Amount {
            get {
                return _amount;
            }
        }
        DateTime _dateExecuted;
        public DateTime DateExecuted {
            get {
                return _dateExecuted;
            }
        }
        string _authorizationCode;
        public string AuthorizationCode {
            get {
                return _authorizationCode;
            }
        }
        string _notes;
        public string Notes {
            get {
                return _notes;
            }
        }
        public IList<string> TransactionErrors { get; set; }

        string _processor;
        public string Processor {
            get {
                return _processor;
            }
        }

        public bool IsRefund
        {
            get
            {
                return Amount <= 0;
            }
        }

        public Transaction(Guid orderID, decimal amount, string authCode, string processor) : this(Guid.NewGuid(), orderID, amount, DateTime.Now, authCode, "",processor) { }

        public Transaction(Guid id, Guid orderID, decimal amount, DateTime executed, string authCode, string notes, string processor)
        {
            _id = id;
            _orderID = orderID;
            _amount = amount;
            _dateExecuted = executed;
            _authorizationCode = authCode;
            _notes = notes;
            _processor = processor;
            TransactionErrors = new List<string>();        }
    }
}
