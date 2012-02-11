using System;
using System.Text.RegularExpressions;

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
            MatchCollection matchCollection = Regex.Matches(locationString, @"([a-zA-Z0-9]+)");
            int x = Convert.ToInt32(matchCollection[0].Value);
            int y = Convert.ToInt32(matchCollection[1].Value);
            string facing = matchCollection[2].Value;

            return new Rover(x, y, facing, instructionsString, gridXMax, gridYMax);
        }

        public static IRoverFactory GetFactory()
        {
            return Factory;
        }
    }
}