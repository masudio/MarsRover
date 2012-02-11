using System;

namespace MarsRover
{
    public interface IRoverFactory
    {
        IRover GetRover(string locationString, string instructionsString, int gridXMax, int gridYMax);
    }

    public class RoverFactory : IRoverFactory
    {
        private static readonly IRoverFactory Factory = new RoverFactory();

        public IRover GetRover(string locationString, string instructionsString, int gridXMax, int gridYMax)
        {
            string[] locationSplit = locationString.Split(' ');
            int x = Convert.ToInt32(locationSplit[0]);
            int y = Convert.ToInt32(locationSplit[1]);
            string facing = locationSplit[2];

            return new Rover(x, y, facing, instructionsString, gridXMax, gridYMax);
        }

        public static IRoverFactory GetFactory()
        {
            return Factory;
        }
    }
}