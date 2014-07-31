namespace BattleFieldGame.Helpers
{
    public struct Coords
    {
        private int xCoord;
        private int yCoord;

        public Coords(int xCoord, int yCoord) : this()
        {
            this.Y = yCoord;
            this.X = xCoord;
        }

        public int Y
        {
            get
            {
                return this.yCoord;
            }

            set
            {
                this.yCoord = value;
            }
        }

        public int X
        {
            get
            {
                return this.xCoord;
            }

            set
            {
                this.xCoord = value;
            }
        }
    }
}
