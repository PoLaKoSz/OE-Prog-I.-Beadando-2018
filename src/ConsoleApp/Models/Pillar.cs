using System;

namespace PoLaKoSz.OE._2018_.PyramidGame.Models
{
    public class Pillar
    {
        private StoneCube[] _stoneCubes;

        public int X { get; }
        public int Y { get; }
        public int Height => _stoneCubes.Length;



        public Pillar(int x, int y)
            : this(x, y, 1) { }

        public Pillar(int x, int y, int height)
        {
            X = x;
            Y = y;
            _stoneCubes = new StoneCube[height];
        }



        /// <summary>
        /// Increase the Height of this <see cref="Pillar"/>
        /// </summary>
        public void Build()
        {
            _stoneCubes = new StoneCube[_stoneCubes.Length + 1];
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != typeof(Pillar))
                return false;

            var anotherCube = (Pillar)obj;

            if (X != anotherCube.X)
                return false;

            if (Y != anotherCube.Y)
                return false;

            if (Height != anotherCube.Height)
                return false;

            return true;
        }

        public override string ToString()
        {
            return $"({X}; {Y}) Height: {Height}";
        }

        public override int GetHashCode()
        {
            var hashCode = 711704877;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + Height.GetHashCode();
            return hashCode;
        }
    }
}
