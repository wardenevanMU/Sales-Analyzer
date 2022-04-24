using System;
using System.Collections.Generic;
using System.IO;

namespace SalesAnalyzer
{
    public static class SalesLoader 
    {
        private static int numitemsofrows = 11;
        public static List<Sale> Load(string filepath) {
            List<Sale> saleList = new List<Sale>();

            try
            {
                using (var playlistreader = new StreamReader(filepath))
                {
                    int lineNumber = 0;
                    while (!playlistreader.EndOfStream)
                    {
                        var lineOfData = playlistreader.ReadLine();
                        if(string.IsNullOrEmpty(lineOfData))
                            continue;
                        lineNumber ++;
                        if (lineNumber == 1) {
                            continue;
                        } 
                        // Split Data at the comma
                        var values = lineOfData.Split(",");

                        if(values.Length != numitemsofrows)
                        {
                            throw new Exception($"Row {lineNumber} contains {values.Length} values. It should contain {numitemsofrows}.");
                        }
                        try
                        {
                            string InvoiceID = values[0];
                            string Branch = values[1];
                            string City =  values[2];
                            string Customer_type = values[3];
                            string Gender = values[4];
                            string Product_line = values[5];
                            float Unit_price = Convert.ToSingle(values[6]);
                            int Quantity = Int32.Parse(values[7]);
                            DateTime date = DateTime.Parse(values[8]);
                            string Payment  = values[9];
                            float rating = Convert.ToSingle(values[10]);


                            Sale sale = new Sale(InvoiceID, Branch, City, Customer_type, Gender, Product_line, Unit_price, Quantity, date, Payment, rating);
                            saleList.Add(sale);

                            if (values.Length != 11)
                            {
                                Console.WriteLine("There should be eleven values in the record!");

                            }
                        }
                        catch (FormatException e)
                        {
                            throw new Exception($"Row {lineNumber} contains invalid data. {e.Message}");
                        }
                    }
                }
            }
            catch (Exception e) {
                throw new Exception($"\nUnable to open {filepath}{e.Message} \nPlaylist file needs to be in the current Folder!");
            }

            return saleList;
        }
    }
}


                    
    
