using MarsRover;
using NUnit.Framework;
using Rhino.Mocks;

namespace test
{
    [TestFixture]
    public class FacingSouthTests
    {
        private Facing sut;

        [SetUp]
        public void SetUp()
        {
            sut = new FacingSouth();
        }

        [Test]
        public void Instruction_TurnLeft_Should_Call_SetFacingEast()
        {
            Instruction instruction = new TurnLeft();
            IRover rover = MockRepository.GenerateMock<IRover>();

            sut.Execute(rover, instruction);

            rover.AssertWasCalled(x => x.SetFacing(Facing.East));
        }

        [Test]
        public void Instruction_TurnRight_Should_Call_SetFacingWest()
        {
            Instruction instruction = new TurnRight();
            IRover rover = MockRepository.GenerateMock<IRover>();

            sut.Execute(rover, instruction);

            rover.AssertWasCalled(x => x.SetFacing(Facing.West));
        }
        [Test]
        public void Instruction_MoveForward_Should_Call_MoveSouth()
        {
            Instruction instruction = new MoveForward();
            IRover rover = MockRepository.GenerateMock<IRover>();

            sut.Execute(rover, instruction);

            rover.AssertWasCalled(x => x.MoveSouth());
        }
    }
}