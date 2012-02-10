using System;
using System.Collections.Generic;

namespace MarsRover
{
    public interface IRoverCommand
    {
        void AllRoversGo();
        string GetAllRoverLocations();
    }

    public class RoverCommand : IRoverCommand
    {
        private readonly List<IRover> rovers;

        /**
         * Assume input is of odd Length, where first element is size of grid.
         */
        public RoverCommand(string[] input, IRoverFactory roverFactory)
        {
            int gridXMax = Convert.ToInt32(input[0].Split(' ')[0]);
            int gridYMax = Convert.ToInt32(input[0].Split(' ')[1]);

            rovers = new List<IRover>();
            for(int i = 1; i < input.Length; i+=2)
            {
                rovers.Add(roverFactory.GetRover(input[i], input[i + 1], gridXMax, gridYMax));
            }
        }

        public void AllRoversGo()
        {
            foreach (var rover in rovers)
            {
                rover.Go();
            }
        }

        public string GetAllRoverLocations()
        {
            string result = "";

            foreach (var rover in rovers)
            {
                result += rover.CurrentPosition() + "\n";
            }

            return result;
        }
    }
}