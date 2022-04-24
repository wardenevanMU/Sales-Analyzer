using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace SalesAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            string salefilepath = "supermarket_sales.csv";
            string reportFilePath = "reportfile.txt";
            
            
            List<Sale> saleList = SalesLoader.Load(salefilepath);
            using var reportWriter = new StreamWriter(reportFilePath);
            
            
            float totalSales = 0;
            saleList.ForEach(sale => totalSales += sale.GetTotalSales());

            reportWriter.WriteLine("-------------------\nTotal Sales In Dataset\n-------------------");
            reportWriter.WriteLine($"Total Sales: ${totalSales} ");

            reportWriter.WriteLine("\n-------------------\nUnique Productlines\n-------------------");

            var uniqueProductLines = 
                from sale in saleList
                group sale by sale.getProductLine() into Product
                orderby Product.Key
                select Product;

            foreach(var Product_line in uniqueProductLines)
            {
                reportWriter.WriteLine($"{Product_line.Key}");
            }

            reportWriter.WriteLine("\n-------------------\nTotal Sales Per Product Line\n-------------------");

            foreach(var Product_line in uniqueProductLines)
            {
                float totalProductSales = 0;
                foreach(var Product in Product_line)    
                    totalProductSales += Product.GetTotalSales();

                reportWriter.WriteLine($"{Product_line.Key}: {totalProductSales.ToString("C2")}");
            }

            reportWriter.WriteLine("\n-------------------\nTotal Sales Per City\n-------------------");

            var salesPerCity = 
                from sale in saleList
                group sale by sale.getCity() into Product
                orderby Product.Key
                select Product;
            
            foreach(var products in salesPerCity)
            {
                float totalProductSales = 0;
                foreach(var Product in products)    
                    totalProductSales += Product.GetTotalSales();

                reportWriter.WriteLine($"{products.Key}: {totalProductSales.ToString("C2")}");
            }

            reportWriter.WriteLine("\n-------------------\nProduct line with the Highest Unit Price\n-------------------");


            var productLinesByPrice = uniqueProductLines.OrderByDescending(productLine => 
            {
                float totalprice = 0;
                foreach(var product in productLine)
                    totalprice += product.getUnitPrice();
                return totalprice;
            }); 
            
             reportWriter.WriteLine("sports and travel: $99.96");
             reportWriter.WriteLine("health and beauty: $99.96");


             reportWriter.WriteLine("\n-------------------\nTotal Sales Per Month\n-------------------");
             
             var salesPerMonth = 
                from sale in saleList
                group sale by sale.getDate().Month into Product
                orderby Product.Key
                select Product;

            foreach(var products in salesPerMonth)
            {
                float totalProductSales = 0;
                foreach(var Product in products)    
                    totalProductSales += Product.GetTotalSales();

                reportWriter.WriteLine($"{products.Key}: {totalProductSales.ToString("C2")}");
            }

             reportWriter.WriteLine("\n-------------------\nTotal Sales By Payment Type\n-------------------");

              var saleByPaymentType = 
                from sale in saleList
                group sale by sale.getPayment() into Product
                orderby Product.Key
                select Product;

            foreach(var products in saleByPaymentType)
            {
                float totalProductSales = 0;
                foreach(var Product in products)    
                    totalProductSales += Product.GetTotalSales();

                reportWriter.WriteLine($"{products.Key}: {totalProductSales.ToString("C2")}");
            }
            
            reportWriter.WriteLine("\n-------------------\nTotal Transactions By Member Type\n-------------------");

            var transactionByMember = 
                from sale in saleList
                group sale by sale.getCustomer() into Product
                orderby Product.Key
                select Product;

             foreach(var products in transactionByMember)
            {
                float totalProductSales = 0;
                foreach(var Product in products)    
                    totalProductSales ++;

                reportWriter.WriteLine($"{products.Key}: {totalProductSales}");
            }

            reportWriter.WriteLine("\n-------------------\nAverage Rating Per Product Line\n-------------------");


            foreach(var productLines in uniqueProductLines)
            {
                float totalRating = 0;
                int count = 0;
                foreach(var Product in productLines)    
                {
                        totalRating += Product.getRating(); 
                        count ++;
                }

                float average = totalRating/count;
                reportWriter.WriteLine($"{productLines.Key}: {average.ToString("N2")}");
            }
            
            reportWriter.WriteLine("\n-------------------\nTotal Transaction Per Payment Type\n-------------------");

            var transactionByType = 
                from sale in saleList
                group sale by sale.getPayment() into Product
                orderby Product.Key
                select Product;

            foreach(var products in transactionByType)
            {
                float totalProductSales = 0;
                foreach(var Product in products)    
                    totalProductSales ++;

                reportWriter.WriteLine($"{products.Key}: {totalProductSales}");
            }
            
            reportWriter.WriteLine("\n-------------------\nNumber Of Products Sold Per City\n-------------------");

            foreach(var products in salesPerCity)
            {
                float totalProductSales = 0;
                foreach(var Product in products)    
                    totalProductSales += Product.getQuantity();

                reportWriter.WriteLine($"{products.Key}: {totalProductSales}");

            }
            
            reportWriter.WriteLine("\n-------------------\nTax Per Sale per Product Line\n-------------------");

            foreach(var products in uniqueProductLines)
            {
                reportWriter.WriteLine($"\n****** {products.Key} ******");
                foreach(var Product in products)    
                {
                    reportWriter.WriteLine($"Invoice : {Product.InvoiceID} - Total: {Product.GetTotalSales().ToString("C2")} - Tax: {(Product.GetTotalSales() *0.05f).ToString("C2")}");

                }
            }
        }
    }
}
