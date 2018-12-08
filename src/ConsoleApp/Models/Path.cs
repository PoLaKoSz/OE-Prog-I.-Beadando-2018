using System;

namespace PoLaKoSz.OE._2018_.PyramidGame.Models
{
    public class Path
    {
        private Pillar[] _fullRoute;

        public int Length => _fullRoute.Length;



        public Path()
            : this(new Pillar[0]) { }

        public Path(params Pillar[] positions)
        {
            // TODO : Rewrite to List<T> after uploaded to reveiw
            //  this homework end before uploaded to GitHub
            //  Update the Increase method too
            _fullRoute = positions;
        }



        /// <summary>
        /// Increase the <see cref="Path"/> with a new
        /// <see cref="Pillar"/>.
        /// </summary>
        public void Increase(Pillar position)
        {
            Pillar[] updated = new Pillar[_fullRoute.Length + 1];

            for (int i = 0; i < _fullRoute.Length; i++)
            {
                updated[i] = _fullRoute[i];
            }

            updated[_fullRoute.Length] = position;

            _fullRoute = updated;
        }

        /// <summary>
        /// Get the last position of the path.
        /// </summary>
        /// <returns>A non reference object from the <see cref="Map"/></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Pillar Last()
        {
            return _fullRoute[_fullRoute.Length - 1];
        }

        /// <summary>
        /// Get the position before the last position of the path.
        /// </summary>
        /// <returns>A non reference object from the <see cref="Map"/></returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Pillar BeforeLast()
        {
            return _fullRoute[_fullRoute.Length - 2];
        }

        /// <summary>
        /// Get the <see cref="Pillar"/> from a specified index.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Pillar GetByIndex(int index)
        {
            return _fullRoute[index];
        }

        /// <summary>
        /// Create a shallow copy of the object path.
        /// </summary>
        /// <returns>Non null object.</returns>
        public Path Clone()
        {
            var newPath = new Path();

            foreach (var position in _fullRoute)
            {
                newPath.Increase(position);
            }

            return newPath;
        }
    }
}
