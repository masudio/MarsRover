/**
 * Mars Rover
 * Problem 3
 * Thoughtworks coding test
 * 
 * Author: Masud Khan
 *          masudio@gmail.com
 */

using System;
using System.IO;

namespace MarsRover
{
    class Program
    {
        /**
         * command-line argument 1 is filepath of input file.
         */
        static void Main(string[] args)
        {
            CheckArgs(args);
            string[] input = DataParser.Parse(args[0]);
            RoverCommandFactory.CreateRoverCommandFrom(input, RoverFactory.GetFactory());
            IRoverCommand roverCommand = RoverCommandFactory.GetRoverCommand();
            roverCommand.AllRoversGo();

            Console.WriteLine(roverCommand.GetAllRoverLocations());
        }

        private static void CheckArgs(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("usage: MarsRover.exe <input file path>");
                Environment.Exit(-1);
            }
            if (File.Exists(args[0])) return;

            Console.WriteLine("Specified file not found.  Exiting.");
            Environment.Exit(-1);
        }
    }
}
