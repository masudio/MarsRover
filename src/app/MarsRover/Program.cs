/**
 * Mars Rover
 * Problem 3
 * Thoughtworks coding test
 * 
 * Author: Masud Khan
 *          masudio@gmail.com
 */

using System;

namespace MarsRover
{
    class Program
    {
        /**
         * command-line argument 1 is filepath of input file.
         */
        static void Main(string[] args)
        {
            string[] input = DataParser.Parse(args[0]);
            RoverCommandFactory.CreateRoverCommandFrom(input, RoverFactory.GetFactory());
            IRoverCommand roverCommand = RoverCommandFactory.GetRoverCommand();
            roverCommand.AllRoversGo();

            Console.WriteLine(roverCommand.GetAllRoverLocations());
        }
    }
}
