using System;

namespace MarsRover
{
    public abstract class Facing
    {
        public const char North = 'N';
        public const char East = 'E';
        public const char South = 'S';
        public const char West = 'W';

        public abstract char GetFacing();

        public static Facing NewDirection(char newDirection)
        {
            switch (newDirection)
            {
                case North:
                    return new FacingNorth();
                case East:
                    return new FacingEast();
                case South:
                    return new FacingSouth();
                case West:
                    return new FacingWest();
                default:
                    throw new ArgumentException("Incorrect facing code.");
            }
        }
    }

    public class FacingNorth : Facing
    {
        public override char GetFacing()
        {
            return North;
        }
    }

    public class FacingEast : Facing
    {
        public override char GetFacing()
        {
            return East;
        }
    }

    public class FacingSouth : Facing
    {
        public override char GetFacing()
        {
            return South;
        }
    }

    public class FacingWest : Facing
    {
        public override char GetFacing()
        {
            return West;
        }
    }
}