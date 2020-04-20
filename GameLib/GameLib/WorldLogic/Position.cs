using System;
using System.Collections.Generic;
using System.Text;

namespace GameLib
{
    public class Position
    {
        public int x;

        public int y;
        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override bool Equals(object obj)
        {try
            {
                if (this.x == ((Position)obj).x && this.y == ((Position)obj).y)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;

        }
        public override int GetHashCode()
        {
            return ((x + y) * (x + y + 1) + y)/2;
        }
    }
    enum Direction
    {
        North,
        South,
        East,
        West

    }
}
