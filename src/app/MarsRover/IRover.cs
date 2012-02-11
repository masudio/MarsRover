using System;

namespace MarsRover
{
    public interface IRover
    {
        void Go();
        string CurrentPosition();
        int GetY();
        int GetX();
    }

    public class Rover : IRover
    {
        private int x, y;
        private readonly int gridXMax, gridYMax;
        private char facingOld;
        private Facing facing;
        private bool dead;
        private readonly char[] instructions;

        public Rover(int x, int y, string facing, string instructions, int gridXMax, int gridYMax)
        {
            this.x = x;
            this.y = y;
            this.gridXMax = gridXMax;
            this.gridYMax = gridYMax;
            SetFacing(facing.ToUpper()[0]);
            this.instructions = instructions.ToUpper().ToCharArray();

            dead = false;
            if( 0 > x || gridXMax < x ||
                0 > y || gridYMax < y )
            {
                dead = true;
            }
        }

        private char GetFacing()
        {
            return facing.GetFacing();
        }

        private void SetFacing(char newDirection)
        {
            facing = Facing.NewDirection(newDirection);
        }

        public void Go()
        {
            foreach (var instruction in instructions)
            {
                Execute(instruction);
            }
        }

        public string CurrentPosition()
        {
            return dead ? "DEAD" : x + " " + y + " " + GetFacing();
        }

        public int GetX()
        {
            return this.x;
        }

        public int GetY()
        {
            return this.y;
        }

        private void Execute(char instruction)
        {
            if(dead)
            {
                return;
            }

            switch (instruction)
            {
                case 'L':
                    if (Facing.North == GetFacing())
                        SetFacing(Facing.West);
                    else if (Facing.East == GetFacing())
                        SetFacing(Facing.North);
                    else if (Facing.South == GetFacing())
                        SetFacing(Facing.East);
                    else if (Facing.West == GetFacing())
                        SetFacing(Facing.South);
                    break;
                case 'R':
                    if (Facing.North == GetFacing())
                        SetFacing(Facing.East);
                    else if (Facing.East == GetFacing())
                        SetFacing(Facing.South);
                    else if (Facing.South == GetFacing())
                        SetFacing(Facing.West);
                    else if (Facing.West == GetFacing())
                        SetFacing(Facing.North);
                    break;
                case 'M':
                    if (Facing.North == GetFacing())
                        y++;
                    else if (Facing.East == GetFacing())
                        x++;
                    else if (Facing.South == GetFacing())
                        y--;
                    else if (Facing.West == GetFacing())
                        x--;
                    break;
                default:
                    throw new Exception();
            }

            
            if( 0 > x || gridXMax < x ||
                0 > y || gridYMax < y )
            {
                dead = true;
            }
        }
    }
}