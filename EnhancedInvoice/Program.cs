using Financials;
using System;

namespace EnhancedInvoice
{
    class Program
    {
        static void Main(string[] args)
        {
            Invoice myInvoice;
            InvoiceItem myItem;

            myInvoice = new Invoice();
            myInvoice.Date = System.DateTime.Today;
            myInvoice.Number = 1234;
            myInvoice.Currency = "EUR";
            myInvoice.Recipient = "Herr Meier";

            myItem = new InvoiceItem();
            myItem.Stocknumber = 5678;
            myItem.Description = "Kaffetasse, groß";
            myItem.Quantity = 23;
            myItem.UnitPrice = 12.99;
            myInvoice.AddItem(myItem);

            myItem = new InvoiceItem();
            myItem.Stocknumber = 7856;
            myItem.Description = "Kaffetasse, klein";
            myItem.Quantity = 12;
            myItem.UnitPrice = 9.99;
            myInvoice.AddItem(myItem);

            Console.WriteLine(((InvoiceItem)myInvoice.Items[0]).SumPrice);
            Console.ReadLine();
        }
    }

    class ProgramEnhanced
    {
        static void Main(string[] args)
        {
            EnhancedInvoice myInvoice;

            myInvoice = new EnhancedInvoice(DateTime.Today, 1234, "EUR", "Herr Meier");
            myInvoice.AddItem(new EnhancedInvoiceItem(5678, 23, "Kaffetasse, groß", 12.99));
            myInvoice.AddItem(new EnhancedInvoiceItem(7856, 12, "Kaffetasse, klein", 9.99));

            Invoice myBase = myInvoice;

            // Aufruf durch das überschriebene Property
            Console.WriteLine(myInvoice.Items[1].SumPrice);

            // Aufruf durch den Indexer
            Console.WriteLine(myInvoice[1].SumPrice);

            // Ausgabe über ToString
            Console.WriteLine(myInvoice.ToString());
            Console.WriteLine(myBase.ToString());

            
            Console.ReadKey();
        }
    }
}
