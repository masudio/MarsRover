using MarsRover;
using NUnit.Framework;

namespace test
{
    [TestFixture]
    public class FacingTests
    {
        [Test]
        public void NewFacing_Should_Return_FacingNorth_With_Argument_N()
        {
            Facing result = Facing.NewFacing('N');

            Assert.IsTrue(result is FacingNorth);
        }

        [Test]
        public void NewFacing_Should_Return_FacingEast_With_Argument_E()
        {
            Facing result = Facing.NewFacing('E');

            Assert.IsTrue(result is FacingEast);
        }

        [Test]
        public void NewFacing_Should_Return_FacingSout_With_Argument_S()
        {
            Facing result = Facing.NewFacing('S');

            Assert.IsTrue(result is FacingSouth);
        }

        [Test]
        public void NewFacing_Should_Return_FacingWest_With_Argument_W()
        {
            Facing result = Facing.NewFacing('W');

            Assert.IsTrue(result is FacingWest);
        }
    }
}