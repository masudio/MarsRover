using MarsRover;
using NUnit.Framework;

namespace test
{
    [TestFixture]
    public class RoverTests
    {
        private IRover sut;

        [SetUp]
        public void SetUp()
        {
            sut = new Rover(4, 5, "N", "LRM", 10, 10);
        }

        [Test]
        public void CurrentPosition_Should_Return_Current_Position()
        {
            string result = sut.CurrentPosition();

            Assert.AreEqual("4 5 N", result);
        }

        [Test]
        public void Go_Should_Change_Current_Position()
        {
            sut.Go();
            string result = sut.CurrentPosition();

            Assert.AreEqual("4 6 N", result);
        }

        [Test]
        public void Go_Should_Not_Throw_When_Lower_Case_Input_Given()
        {
            sut = new Rover(5, 5, "n", "LrM", 10, 10);

            sut.Go();
        }

        [Test]
        public void GetX_Should_Return_X_Value()
        {
            int result = sut.GetX();

            Assert.AreEqual(4, result);
        }

        [Test]
        public void GetY_Should_Return_Y_Value()
        {
            int result = sut.GetY();

            Assert.AreEqual(5, result);
        }

        [Test]
        public void Rover_Can_Be_At_Very_Edge_Of_Plateau()
        {
            sut = new Rover(10, 10, "N", "M", 10, 10);

            string result = sut.CurrentPosition();

            Assert.AreEqual("10 10 N", result);
        }

        [Test]
        public void Go_Should_Kill_Rover_If_It_Goes_Off_North_Edge_Plateau()
        {
            sut = new Rover(10, 10, "N", "M", 10, 10);

            sut.Go();
            string result = sut.CurrentPosition();

            Assert.AreEqual("DEAD", result);
        }

        [Test]
        public void Go_Should_Kill_Rover_If_It_Goes_Off_East_Edge_Plateau()
        {
            sut = new Rover(10, 10, "E", "M", 10, 10);

            sut.Go();
            string result = sut.CurrentPosition();

            Assert.AreEqual("DEAD", result);
        }

        [Test]
        public void Go_Should_Kill_Rover_If_It_Goes_Off_West_Edge_Plateau()
        {
            sut = new Rover(0, 10, "W", "M", 10, 10);

            sut.Go();
            string result = sut.CurrentPosition();

            Assert.AreEqual("DEAD", result);
        }

        [Test]
        public void Go_Should_Kill_Rover_If_It_Goes_Off_South_Edge_Plateau()
        {
            sut = new Rover(10, 0, "S", "M", 10, 10);

            sut.Go();
            string result = sut.CurrentPosition();

            Assert.AreEqual("DEAD", result);
        }
        [Test]
        public void Rover_Stays_Dead_Even_If_Instructions_Bring_It_Back_On_To_Plateau()
        {

            sut = new Rover(10, 10, "N", "MLLM", 10, 10);

            sut.Go();
            string result = sut.CurrentPosition();

            Assert.AreEqual("DEAD", result);
        }
    }
}