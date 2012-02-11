﻿using MarsRover;
using NUnit.Framework;
using Rhino.Mocks;

namespace test
{
    [TestFixture]
    public class FacingEastTests
    {
        private Facing sut;

        [SetUp]
        public void SetUp()
        {
            sut = new FacingEast();
        }

        [Test]
        public void Instruction_TurnLeft_Should_Call_SetFacingNorth()
        {
            Instruction instruction = new TurnLeft();
            IRover rover = MockRepository.GenerateMock<IRover>();

            sut.Execute(rover, instruction);

            rover.AssertWasCalled(x => x.SetFacing(Facing.North));
        }

        [Test]
        public void Instruction_TurnRight_Should_Call_SetFacingSouth()
        {
            Instruction instruction = new TurnRight();
            IRover rover = MockRepository.GenerateMock<IRover>();

            sut.Execute(rover, instruction);

            rover.AssertWasCalled(x => x.SetFacing(Facing.South));
        }
        [Test]
        public void Instruction_MoveForward_Should_Call_MoveNorth()
        {
            Instruction instruction = new MoveForward();
            IRover rover = MockRepository.GenerateMock<IRover>();

            sut.Execute(rover, instruction);

            rover.AssertWasCalled(x => x.MoveEast());
        }
    }
}