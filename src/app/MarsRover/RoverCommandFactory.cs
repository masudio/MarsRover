namespace MarsRover
{
    public static class RoverCommandFactory
    {
        private static IRoverCommand roverCommand;

        public static void CreateRoverCommandFrom(string[] input, IRoverFactory roverFactory)
        {
            roverCommand = new RoverCommand(input, roverFactory);
        }

        /*
         * if roverCommand is not initialized, should return null.
         */
        public static IRoverCommand GetRoverCommand()
        {
            return roverCommand;
        }
    }
}