using Financials;
using System;
using System.Collections.Generic;

namespace EnhancedInvoice
{
    class EnhancedInvoice : Invoice
    {
        private new List<EnhancedInvoiceItem> items = new List<EnhancedInvoiceItem>();
        public new List<EnhancedInvoiceItem> Items
        {
            get
            {
                items.Clear();

                for (int i = 0; i < base.Items.Count; i++)
                {
                    items.Add((EnhancedInvoiceItem)base.Items[i]);
                }

                return items;
            }
            set
            {
                items = value;
            }
        }
        public EnhancedInvoiceItem this[int index]
        {
            get
            {
                return Items[index];
            }
        }
        private double totalSum = 0;
        public double TotalSum
        {
            get
            {
                totalSum = 0;

                foreach (EnhancedInvoiceItem item in Items)
                {
                    totalSum += item.SumPrice;
                }

                return totalSum;
            }
            set
            {
                totalSum = value;
            }
        }

        public EnhancedInvoice(DateTime date, uint number, string currency, string recipient) : base()
        {
            Date = date;
            Number = number;
            Currency = currency;
            Recipient = recipient;
        }

        public override string ToString()
        {
            return $"= {TotalSum}";
        }

        //public IEnumerator<EnhancedInvoiceItem> GetEnumerator()
        //{
        //    foreach (EnhancedInvoiceItem item in Items)
        //    {
        //        return item;
        //    }
        //}

        //public IEnumerable<EnhancedInvoiceItem> GetEnumerable()
        //{
        //    foreach(EnhancedInvoiceItem item in Items)
        //    {
        //        return item;
        //    } 
        //}
    }

    class EnhancedInvoiceItem : InvoiceItem
    {
        private double sumPrice = 0;
        public new double SumPrice
        {
            get
            {
                sumPrice = Quantity * UnitPrice;
                return sumPrice;
            }
            set
            {
                sumPrice = value;
            }
        }

        public EnhancedInvoiceItem(uint stocknumber, uint quantity, string description, double unitprice) : base()
        {
            Stocknumber = stocknumber;
            Quantity = quantity;
            Description = description;
            UnitPrice = unitprice;
        }

        public override string ToString()
        {
            return $"{Quantity} of Item {Description} ({Stocknumber}) for {UnitPrice} each.";
        }
    }
}
