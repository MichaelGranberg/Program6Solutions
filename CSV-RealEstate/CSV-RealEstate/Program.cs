using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CSV_RealEstate
{
    // WHERE TO START?
    // 1. Complete the RealEstateType enumeration
    // 2. Complete the RealEstateSale object.  Fill in all properties, then create the constructor.
    // 3. Complete the GetRealEstateSaleList() function.  This is the function that actually reads in the .csv document and extracts a single row from the document and passes it into the RealEstateSale constructor to create a list of RealEstateSale Objects.
    // 4. Start by displaying the the information in the Main() function by creating lambda expressions.  After you have acheived your desired output, then translate your logic into the function for testing.
    class Program
    {
        static void Main(string[] args)
        {
            List<RealEstateSale> realEstateSaleList = GetRealEstateSaleList();
            
            //Display the average square footage of a Condo sold in the city of Sacramento.
            Console.WriteLine(realEstateSaleList.Where(x=>x.City.ToLower() == "Sacramento".ToLower()  &&  x.Type == RealEstateType.Condo).Average(x=>x.Sq_ft));
                
            //Use the GetAverageSquareFootageByRealEstateTypeAndCity() function.
            Console.WriteLine(GetAverageSquareFootageByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Condo ,"Sacramento" ));

            //Display the total sales of all residential homes in Elk Grove.  Use the GetTotalSalesByRealEstateTypeAndCity() function for testing.
            Console.WriteLine(GetTotalSalesByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Residential, "Elk Grove"  ));
           
            //Display the total number of residential homes sold in the zip code 95842.  Use the GetNumberOfSalesByRealEstateTypeAndZip() function for testing.
            Console.WriteLine(GetNumberOfSalesByRealEstateTypeAndZip(realEstateSaleList, RealEstateType.Residential, "95842"));
           
            //Display the average sale price of a lot in Sacramento.  Use the GetAverageSalePriceByRealEstateTypeAndCity() function for testing.
            Console.WriteLine(GetAverageSalePriceByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Lot, "Sacramento"));
           
            //Display the average price per square foot for a condo in Sacramento. Round to 2 decimal places. Use the GetAveragePricePerSquareFootByRealEstateTypeAndCity() function for testing.
            Console.WriteLine(GetAverageSalePriceByRealEstateTypeAndCity(realEstateSaleList, RealEstateType.Condo, "Sacramento"));
            
            //Display the number of all sales that were completed on a Wednesday.  Use the GetNumberOfSalesByDayOfWeek() function for testing.
            Console.WriteLine(GetNumberOfSalesByDayOfWeek(realEstateSaleList, DayOfWeek.Wednesday));

            //Display the average number of bedrooms for a residential home in Sacramento when the 
            // price is greater than 300000.  Round to 2 decimal places.  Use the GetAverageBedsByRealEstateTypeAndCityHigherThanPrice() function for testing.
            Console.WriteLine(GetAverageBedsByRealEstateTypeAndCityHigherThanPrice(realEstateSaleList, RealEstateType.Residential, "Sacramento", 300000m));

            Console.ReadKey();

            //Display top 5 cities by the number of homes sold (using the GroupBy extension)
            // Use the GetTop5CitiesByNumberOfHomesSold() function for testing.

        }

        public static List<RealEstateSale> GetRealEstateSaleList()
        {
            List<RealEstateSale> RealEstateSaleList = new List<RealEstateSale>();
            //read in the realestatedata.csv file.  As you process each row, you'll add a new 
            // RealEstateData object to the list for each row of the document, excluding the first.  bool skipFirstLine = true;
            using (StreamReader reader = new StreamReader("realestatedata.csv"))
            {
                //
                string firstline = reader.ReadLine();
                //skipfirstline = false;
                
                while (!reader.EndOfStream)
                {
                   RealEstateSaleList.Add(new RealEstateSale(reader.ReadLine()));
                }
                return RealEstateSaleList;
            }
        }

        public static double GetAverageSquareFootageByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city) 
        {
             return realEstateDataList.Where(x=>x.City.ToLower() == city.ToLower() && x.Type == realEstateType).Average(x=>x.Sq_ft);
             
        }

        public static decimal GetTotalSalesByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
            return realEstateDataList.Where(x=>x.City.ToLower() == city.ToLower () && x.Type == realEstateType).Sum(x=>x.Price);
        }

        public static int GetNumberOfSalesByRealEstateTypeAndZip(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string zipcode)
        {
            return realEstateDataList.Where(x => x.Zip == zipcode && x.Type == realEstateType).Count();
        }

        
        public static decimal GetAverageSalePriceByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {

            //Must round to 2 decimal points
            return Math.Round(realEstateDataList.Where(x=>x.City.ToLower() == city.ToLower() &&  x.Type == realEstateType).Average(x=>x.Price),2);
                       
           // return 0.0m;
        }
        public static decimal GetAveragePricePerSquareFootByRealEstateTypeAndCity(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city)
        {
   
            //Must round to 2 decimal points
            return Math.Round( realEstateDataList.Where(x=>x.City.ToLower() == city.ToLower()  &&  x.Type == realEstateType).Average(x=>x.Price/x.Sq_ft),2);
        }

        public static int GetNumberOfSalesByDayOfWeek(List<RealEstateSale> realEstateDataList, DayOfWeek dayOfWeek)
        {
            return Convert.ToInt32(realEstateDataList.Where(x=>x.Sale_date.DayOfWeek == dayOfWeek).Count());
        }

        public static double GetAverageBedsByRealEstateTypeAndCityHigherThanPrice(List<RealEstateSale> realEstateDataList, RealEstateType realEstateType, string city, decimal price)
        {
            //Must round to 2 decimal points
            return Math.Round(realEstateDataList.Where(x => x.City.ToLower() == city.ToLower() && x.Type == realEstateType && x.Price > price).Average(x => x.Beds),2);
        }

        public static List<string> GetTop5CitiesByNumberOfHomesSold(List<RealEstateSale> realEstateDataList)
        {
            return new List<string>();
        }
    }

    public enum RealEstateType
    {
        //fill in with enum types: Residential, MultiFamily, Condo, Lot
        Residential,
        MultiFamily,
        Condo,
        Lot,        

    }
    public class RealEstateSale
    {
        //Create properties, using the correct data types (not all are strings) for all columns of the CSV
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public int Beds { get; set; }
        public int Baths { get; set; }
        public int Sq_ft { get; set; }
        public RealEstateType Type { get; set; }
        public DateTime Sale_date { get; set;}
        public decimal Price { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public RealEstateSale(string lineInput)
        { 
        //The constructor will take a single string arguement.  This string will be one line of the real estate data.
        // Inside the constructor, you will seperate the values into their corrosponding properties, and do the necessary conversions

            string[] RealEstateData = lineInput.Split(',');

            this.Street = RealEstateData[0];
            this.City = RealEstateData[1];
            this.Zip =  RealEstateData[2];
            this.State = RealEstateData[3];
            this.Beds =  int.Parse(RealEstateData[4]);
            this.Baths = int.Parse(RealEstateData[5]);
            this.Sq_ft = int.Parse(RealEstateData[6]);
            if (RealEstateData[6] == "0")
            {
                this.Type = RealEstateType.Lot;
            }
            else if (RealEstateData[7].ToLower() == "residential")
            {
                this.Type = RealEstateType.Residential;
            }
            else if (RealEstateData[7].ToLower() == "multi-family")
            {
                this.Type = RealEstateType.MultiFamily;
            }
            else
            {
                this.Type = RealEstateType.Condo;
            }
            this.Sale_date =(DateTime.Parse(RealEstateData[8]));
            this.Price = Int32.Parse(RealEstateData[9]); 
            this.Latitude = Convert.ToDouble(RealEstateData[10]);
            this.Longitude = Convert.ToDouble(RealEstateData[11]);

           
        // When computing the RealEstateType, if the square footage is 0, then it is of the Lot type, otherwise, use the string
        // value of the "Type" column to determine its corresponding enumeration type.
        }
    }   
}