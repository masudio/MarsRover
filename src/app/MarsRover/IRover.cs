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
        private char facing;
        private bool dead;
        private readonly char[] instructions;

        public Rover(int x, int y, string facing, string instructions, int gridXMax, int gridYMax)
        {
            this.x = x;
            this.y = y;
            this.gridXMax = gridXMax;
            this.gridYMax = gridYMax;
            this.facing = facing.ToUpper()[0];
            this.instructions = instructions.ToUpper().ToCharArray();

            dead = false;
            if( 0 > x || gridXMax < x ||
                0 > y || gridYMax < y )
            {
                dead = true;
            }
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
            return dead ? "DEAD" : x + " " + y + " " + facing;
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
                    if ('N' == facing)
                        facing = 'W';
                    else if ('E' == facing)
                        facing = 'N';
                    else if ('S' == facing)
                        facing = 'E';
                    else if ('W' == facing)
                        facing = 'S';
                    break;
                case 'R':
                    if ('N' == facing)
                        facing = 'E';
                    else if ('E' == facing)
                        facing = 'S';
                    else if ('S' == facing)
                        facing = 'W';
                    else if ('W' == facing)
                        facing = 'N';
                    break;
                case 'M':
                    if ('N' == facing)
                        y++;
                    else if ('E' == facing)
                        x++;
                    else if ('S' == facing)
                        y--;
                    else if ('W' == facing)
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