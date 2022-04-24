using System;

namespace SalesAnalyzer
{
    public class Sale
    {
        public string InvoiceID { get; private set; }
        
        public string Branch { get; private set; }
        
        private string City;
        private string Customer_type;
        private string Gender;
        private string Product_line;
        private float Unit_price;
        int Quantity;
        private DateTime date;
        private string Payment;
        private float rating;
       

        public Sale(string InvoiceID, string Branch, string City, string Customer_type, string Gender, string Product_line, float Unit_price, int Quantity, DateTime date,string Payment, float rating)
        {
            this.InvoiceID = InvoiceID;
            this.Branch = Branch;
            this.City = City;
            this.Customer_type = Customer_type;
            this.Gender = Gender;
            this.Product_line = Product_line;
            this.Unit_price = Unit_price;
            this.Quantity = Quantity;
            this.date = date;
            this.Payment = Payment;
            this.rating = rating; 
        }
        
        
        public string getCity()
        {
            return this.City;
        }
        public string getCustomer()
        {
            return this.Customer_type;
        }
        public string getGender()
        {
            return this.Gender;
        }
        public string getProductLine()
        {
            return this.Product_line;
        }
        public float getUnitPrice()
        {
            return this.Unit_price;
        }
        public int getQuantity()
        {
            return this.Quantity;
        }
        public DateTime getDate()
        {
            return this.date;
        }
        public string getPayment()
        {
            return this.Payment;
        }
        public float getRating()
        {
            return this.rating;
        }
        
        public float GetTotalSales()
        {
            return Quantity * Unit_price;
        }
    }
}

        
        


    
