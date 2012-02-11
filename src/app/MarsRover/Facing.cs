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
        public abstract void Execute(IRover rover, Instruction instruction);

        public static Facing NewFacing(char newDirection)
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

        public override void Execute(IRover rover, Instruction instruction)
        {
            switch(instruction.GetInstruction())
            {
                case Instruction.TurnLeft:
                    rover.SetFacing(West);
                    break;
                case Instruction.TurnRight:
                    rover.SetFacing(East);
                    break;
                case Instruction.MoveForward:
                    rover.MoveNorth();
                    break;
                default:
                    throw new ArgumentException("Incorrect facing code.");
            }
        }
    }

    public class FacingEast : Facing
    {
        public override char GetFacing()
        {
            return East;
        }

        public override void Execute(IRover rover, Instruction instruction)
        {
            switch (instruction.GetInstruction())
            {
                case Instruction.TurnLeft:
                    rover.SetFacing(North);
                    break;
                case Instruction.TurnRight:
                    rover.SetFacing(South);
                    break;
                case Instruction.MoveForward:
                    rover.MoveEast();
                    break;
                default:
                    throw new ArgumentException("Incorrect facing code.");
            }
        }
    }

    public class FacingSouth : Facing
    {
        public override char GetFacing()
        {
            return South;
        }

        public override void Execute(IRover rover, Instruction instruction)
        {
            switch (instruction.GetInstruction())
            {
                case Instruction.TurnLeft:
                    rover.SetFacing(East);
                    break;
                case Instruction.TurnRight:
                    rover.SetFacing(West);
                    break;
                case Instruction.MoveForward:
                    rover.MoveSouth();
                    break;
                default:
                    throw new ArgumentException("Incorrect facing code.");
            }
        }
    }

    public class FacingWest : Facing
    {
        public override char GetFacing()
        {
            return West;
        }

        public override void Execute(IRover rover, Instruction instruction)
        {
            switch (instruction.GetInstruction())
            {
                case Instruction.TurnLeft:
                    rover.SetFacing(South);
                    break;
                case Instruction.TurnRight:
                    rover.SetFacing(North);
                    break;
                case Instruction.MoveForward:
                    rover.MoveWest();
                    break;
                default:
                    throw new ArgumentException("Incorrect facing code.");
            }
        }
    }
}