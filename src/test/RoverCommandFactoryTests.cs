using MarsRover;
using NUnit.Framework;
using Rhino.Mocks;

namespace test
{
    [TestFixture]
    public class RoverCommandFactoryTests
    {
        [Test]
        public void Should_Pass()
        {
            Assert.Pass();
        }

        [Test]
        public void Should_Return_New_Rover_Command_Object()
        {
            string[] input = {"5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"};
            var roverFactoryMock = MockRepository.GenerateMock<IRoverFactory>();
            RoverCommandFactory.CreateRoverCommandFrom(input, roverFactoryMock);

            IRoverCommand result = RoverCommandFactory.GetRoverCommand();

            Assert.NotNull(result);
        }
    }
}