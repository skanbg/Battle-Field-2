namespace BattleFieldGame.Helpers
{
    public struct Coords
    {
        private int coordX;
        private int coordY;

        public Coords(int coordX, int coordY) : this()
        {
            this.Y = coordY;
            this.X = coordX;
        }

        public int Y
        {
            get
            {
                return this.coordY;
            }

            set
            {
                this.coordY = value;
            }
        }

        public int X
        {
            get
            {
                return this.coordX;
            }

            set
            {
                this.coordX = value;
            }
        }
    }
}
