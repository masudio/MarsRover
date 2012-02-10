using MarsRover;
using NUnit.Framework;
using Rhino.Mocks;

namespace test
{
    [TestFixture]
    public class RoverCommandTests
    {
        [Test]
        public void Should_Create_RoverCommand()
        {
            string[] input = {"5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM"};
            var roverFactoryMock = MockRepository.GenerateMock<IRoverFactory>();
            roverFactoryMock.Stub(x => x.GetRover(Arg<string>.Is.Anything,
                                                    Arg<string>.Is.Anything,
                                                    Arg<int>.Is.Anything,
                                                    Arg<int>.Is.Anything))
            .Return(null);
            
            IRoverCommand result = new RoverCommand(input, roverFactoryMock);

            Assert.NotNull(result);
        }

        [Test]
        public void GetAllRoverLocations_Should_Return_Original_Locations()
        {
            string[] input = { "5 5", "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM" };
            var roverFactoryMock = MockRepository.GenerateMock<IRoverFactory>();
            var roverMock = MockRepository.GenerateMock<IRover>();
            roverMock.Stub(x => x.CurrentPosition()).Return("returnme!");
            roverFactoryMock.Stub(x => x.GetRover(Arg<string>.Is.Anything,
                                                    Arg<string>.Is.Anything,
                                                    Arg<int>.Is.Anything,
                                                    Arg<int>.Is.Anything))
            .Return(roverMock);
            IRoverCommand sut = new RoverCommand(input, roverFactoryMock);

            string result = sut.GetAllRoverLocations();

            Assert.AreEqual("returnme!\nreturnme!\n", result);
        }
    }
}