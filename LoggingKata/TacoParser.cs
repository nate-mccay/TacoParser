namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {   
            if(line == null)
            {
                return null;
            }
            logger.LogInfo("Begin parsing");
            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');
            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                logger.LogInfo("Array is less than 3");
                return null;// Log that and return null
            }
            // grab the latitude from your array at index 0
            // grab the longitude from your array at index 1
            string name = cells[2];// grab the name from your array at index 2
            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            // You'll need to create a TacoBell class
            // that conforms to ITrackable
            if(double.TryParse(cells[0], out double Latitude) == false)
            {
                logger.LogInfo("Latitude failed");
                return null;
            }
            if(double.TryParse(cells[1], out double Longitude) == false)
            {
                logger.LogInfo("Longitude failed");
                return null;
            }
            var TacoBell1 = new TacoBell();// Then, you'll need an instance of the TacoBell class
            TacoBell1.Name = name;// With the name and point set correctly
            Point Location = new Point();
            Location.Latitude = Latitude;
            Location.Longitude = Longitude;
            TacoBell1.Location = Location;
            return TacoBell1;// Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable
            // Do not fail if one record parsing fails, return null
             // TODO Implement
        }
    }
}