using System;

namespace PoLaKoSz.OE._2018_.PyramidGame.Models
{
    public class Map
    {
        private readonly Pillar[,] _map;

        public int Width => _map.GetLength(1);
        public int Height => _map.GetLength(0);



        /// <summary>
        /// Initialize a square <see cref="Map"/>.
        /// </summary>
        /// <param name="size">Should be at least 1.</param>
        public Map(int size)
            : this(size, size) { }

        /// <summary>
        /// Initialize a custom size <see cref="Map"/>.
        /// </summary>
        /// <param name="width">Should be at least 1.</param>
        /// <param name="height">Should be at least 1.</param>
        public Map(int width, int height)
        {
            _map = new Pillar[height, width];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    _map[y, x] = new Pillar(x, y);
                }
            }
        }

        /// <summary>
        /// Initialize a predefinied <see cref="Pillar"/> collection
        /// as a <see cref="Map"/>.
        /// </summary>
        /// <param name="map">Non null array.</param>
        public Map(Pillar[,] map)
        {
            _map = map;
        }



        /// <summary>
        /// Get a reference <see cref="Pillar"/> from the <see cref="Map"/>
        /// </summary>
        /// <param name="x">Pillar's X coordinate</param>
        /// <param name="y">Pillar's Y coordinate</param>
        public Pillar GetField(int x, int y)
        {
            return _map[y, x];
        }

        /// <summary>
        /// Get a reference <see cref="Pillar"/> from the <see cref="Map"/>
        /// </summary>
        /// <param name="x">Pillar's X coordinate</param>
        /// <param name="y">Pillar's Y coordinate</param>
        public Pillar GetField(Pillar position)
        {
            return GetField(position.X, position.Y);
        }

        public void SetField(Pillar position)
        {
            _map[position.Y, position.X] = position;
        }
    }
}
