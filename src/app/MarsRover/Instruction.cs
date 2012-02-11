using System;
using System.Linq;

namespace MarsRover
{
    public abstract class Instruction
    {
        public const char TurnLeft = 'L';
        public const char TurnRight = 'R';
        public const char MoveForward = 'M';

        public abstract char GetInstruction();

        public static Instruction[] GetInstructions(string instructions)
        {
            return (from instruction in instructions
                        select NewInstruction(instruction)).ToArray();
        }

        private static Instruction NewInstruction(char instruction)
        {
            switch(instruction)
            {
                case TurnLeft:
                    return new TurnLeft();
                case TurnRight:
                    return new TurnRight();
                case MoveForward:
                    return new MoveForward();
                default:
                    throw new ArgumentException("Incorrect instruction code.");
            }
        }
    }

    public class TurnLeft : Instruction
    {
        public override char GetInstruction()
        {
            return TurnLeft;
        }
    }

    public class TurnRight : Instruction
    {
        public override char GetInstruction()
        {
            return TurnRight;
        }
    }

    public class MoveForward : Instruction
    {
        public override char GetInstruction()
        {
            return MoveForward;
        }
    }
}