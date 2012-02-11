namespace MarsRover
{
    public interface IRover
    {
        void Go();
        string CurrentPosition();
        int GetY();
        int GetX();
        void SetFacing(char direction);
        void MoveNorth();
        void MoveEast();
        void MoveSouth();
        void MoveWest();
    }

    public class Rover : IRover
    {
        private int x, y;
        private readonly int gridXMax, gridYMax;
        private Facing facing;
        private bool dead;
        private readonly Instruction[] instructions;

        public Rover(int x, int y, string facing, string instructions, int gridXMax, int gridYMax)
        {
            this.x = x;
            this.y = y;
            this.gridXMax = gridXMax;
            this.gridYMax = gridYMax;
            SetFacing(facing.ToUpper()[0]);
            this.instructions = Instruction.GetInstructions(instructions.ToUpper());

            dead = false;
            if (0 > x || gridXMax < x ||
                0 > y || gridYMax < y)
            {
                dead = true;
            }
        }

        private char GetFacing()
        {
            return facing.GetFacing();
        }

        public void SetFacing(char direction)
        {
            facing = Facing.NewFacing(direction);
        }

        public void Go()
        {
            foreach (var instruction in instructions)
            {
                if (dead)
                {
                    return;
                }

                Execute(instruction);

                if (0 > x || gridXMax < x ||
                    0 > y || gridYMax < y)
                {
                    dead = true;
                }
            }
        }

        public string CurrentPosition()
        {
            return dead ? "DEAD" : x + " " + y + " " + GetFacing();
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        private void Execute(Instruction instruction)
        {
            facing.Execute(this, instruction);
        }

        public void MoveNorth()
        {
            y++;
        }

        public void MoveEast()
        {
            x++;
        }

        public void MoveSouth()
        {
            y--;
        }

        public void MoveWest()
        {
            x--;
        }
    }
}