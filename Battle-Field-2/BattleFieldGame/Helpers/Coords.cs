using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFieldGame.Helpers
{
    public struct Coords
    {
        private int xCoord;
        private int yCoord;


        public Coords(int yCoord, int xCoord)
            : this()
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
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Coordinate cannot be a negative value!");
                }
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
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Coordinate cannot be a negative value!");
                }
                this.xCoord = value;
            }
        }

    }
}
