using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(@"C:\Users\natem\OneDrive\Desktop\repos\TacoParser\LoggingKata\TacoBell-US-AL.csv");
            if(lines.Length == 0)
            {
                logger.LogError("0 lines");
                
            }
            if(lines.Length == 1)
            {
                logger.LogWarning("1 line");
            }
            logger.LogInfo($"Lines: {lines[0]}");
          
            var parser = new TacoParser();
            
            var locations = lines.Select(parser.Parse).ToArray();

            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            ITrackable TB1 = null;
            ITrackable TB2 = null;
            double distance = 0;
            // HINT:  You'll need two nested forloops
            var CorB = new GeoCoordinate();
            var CorA = new GeoCoordinate();
            for (int i = 0;i < locations.Length;i++)
            {

                    
                    CorA.Latitude = locations[i].Location.Latitude;
                    CorA.Longitude = locations[i].Location.Longitude;
                    
                for (int j = 0; j < locations.Length; j++)
                {
                        
                        CorB.Latitude = locations[j].Location.Latitude;
                        CorB.Longitude = locations[j].Location.Longitude;
                    double newDis = CorA.GetDistanceTo(CorB);
                    if (newDis > distance)
                    {
                        
                        TB1 = locations[i];
                        TB2 = locations[j];
                        distance = newDis;
                    }
                }
            }
            Console.WriteLine($"{TB1.Name}, {TB2.Name}");
            Console.ReadLine();
        }
    }
}