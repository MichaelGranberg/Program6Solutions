using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV_ListeningHabits
{
    class Program
    {
        // Global List
        public static List<Play> musicDataList = new List<Play>();

        static void Main(string[] args)
        {
            // initalize dataset into list
            InitList();
            // keep console open
            Console.ReadLine();
        }
        /// <summary>
        /// A function to initalize the List from the csv file
        /// needed for testing
        /// </summary>
        public static void InitList()
        {
            // load data
            using (StreamReader reader = new StreamReader("scrobbledata.csv"))
            {
                // Get and don't use the first line
                string firstline = reader.ReadLine();
                // Loop through the rest of the lines
                while (!reader.EndOfStream)
                {
                    musicDataList.Add(new Play(reader.ReadLine()));
                }
            }
        }
        /// <summary>
        /// A function that will return the total ammount of plays in the dataset
        /// </summary>
        /// <returns>total number of plays</returns>
        public static int TotalPlays()
        {
            // returns count of plays (rows)
            return musicDataList.Count();
        }
        /// <summary>
        /// A function that returns the number of plays ever by an artist
        /// </summary>
        /// <param name="artistName">artist name</param>
        /// <returns>total number of plays</returns>
        public static int TotalPlaysByArtistName(string artistName)
        {
        
        // counts all the rows that contain the artist   ** ToString not needed below***use === rather than Equals*** 
        return musicDataList.Count(x => x.Artist.ToString().ToLower().Equals(artistName.ToLower()));
        // ****another way to code****
        //   List<Play> artistOnly = musicDataList.Where(x=>x.Artist.ToLower == artistName.ToLower()).ToList(); 
        //   return artistOnly.Count
        }
        /// <summary>
        /// A function that returns the number of plays by a specific artist in a specific year
        /// </summary>
        /// <param name="artistName">artist name</param>
        /// <param name="year">one year</param>
        /// <returns>total plays in year</returns>
        public static int TotalPlaysByArtistNameInYear(string artistName, string year)
        {
            // returns the count of plays in a year by artist                                                                     .ToList().Count()  
            return musicDataList.Where(x => x.Artist.ToLower() == artistName.ToLower()).Where(x => x.Time.Year.ToString() == year).Count();
            //
            //return musicdataList.Count(x=>.Artist.ToLower() == artistName.ToLower() && x.time.Year.ToString() == 
            //year);                      
        }
        /// <summary>
        /// A function that returns the number of unique artists in the entire dataset
        /// </summary>
        /// <returns>number of unique artists</returns>
        public static int CountUniqueArtists()
        {
          
            // counts unique artists
            return musicDataList.Select(x => x.Artist).Distinct().Count();

            
        }
        /// <summary>
        /// A function that returns the number of unique artists in a given year
        /// </summary>
        /// <param name="year">year to check</param>
        /// <returns>unique artists in year</returns>
        public static int CountUniqueArtists(string year)
        {
            // returns unique artists by year
            return musicDataList.Where(x=>x.Time.Year.ToString() == year).Select(y => y.Artist).Distinct().Count();
            // List<string> AllArtistPlays = musicdataList.Select(x=>x>artist).ToList();
            //List<Play>= allArtistsAndplays of The Year = musicDataList.Where(x=>Artist).ToList();              
        }
        /// <summary>
        /// A function that returns a List of unique strings which contains
        /// the Title of each track by a specific artists
        /// </summary>
        /// <param name="artistName">artist</param>
        /// <returns>list of song titles</returns>
        public static List<string> TrackListByArtist(string artistName)
        {
           
            // 
            //builds a list of titles by artist
            return  musicDataList.Where(x => x.Artist == artistName).Select(y=>y.Title).ToList();
            //
            // List<string> allTracksBy the Artist.Select(x=x.Title).Distinct().ToList();

         }
        /// <summary>
        /// A function that returns the first time an artist was ever played
        /// </summary>
        /// <param name="artistName">artist name</param>
        /// <returns>DateTime of first play</returns>
        public static DateTime FirstPlayByArtist(string artistName)
        {
            return musicDataList
                .Where(x => x.Artist.ToLower() == artistName.ToLower())
                .OrderBy(y => y.Time)
                .First()
                .Time;
            // above is the statement seperated out 
          //return musicDataList.Where(x=>x.Artists.ToLower() == artistName.ToLower()).First().Time; 
        }
        /// <summary>
        ///                     ***BONUS***
        /// A function that will determine the most played artist in a specified year
        /// </summary>
        /// <param name="year">year to check</param>
        /// <returns>most popular artist in year</returns>
        public static string MostPopularArtistByYear(string year)
        {
            // 1 filter plays by year
            List<Play> playisInTheyear = musicDataList.Where(x=>x.Time.Year.ToString() == year).ToList();
            // 2 group play by the artist
            List<IGrouping<string, Play>> PlaysGroupedByArtist = playisInTheyear.GroupBy(x=>x.Artist ).ToList();
            //3 order them in descending order based on the number of plays
            List<IGrouping<string, Play>> OrderedPlaysGroupByArtist = PlaysGroupedByArtist.OrderByDescending(x => x.Count()).ToList();
            //4. take the first item out
            IGrouping<string, Play> mostPopular = OrderedPlaysGroupByArtist.First();
            //5. return the artist name
            return mostPopular.Key;


            //return String.Empty;
           
        }

    }

    public class Play
    {
        // Properties
        public DateTime Time { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Album { get; set; }
        public Play(string lineInput)
        {
            // Split using the tab character due to the tab delimited data format
            string[] playData = lineInput.Split('\t');
            
            // Get the time in milliseconds and convert to C# DateTime
            DateTime posixTime = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);
            this.Time = posixTime.AddMilliseconds(long.Parse(playData[0]));
            //***** this. refers to property, not variable*****
            // need to populate the rest of the properties
            this.Artist = (playData[1]);

            this.Title = (playData[2]);

            this.Album = (playData[3]);
                

        }
    }
}
