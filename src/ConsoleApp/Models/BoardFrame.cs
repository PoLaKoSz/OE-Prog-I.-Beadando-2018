using System;

namespace PoLaKoSz.OE._2018_.PyramidGame.Models
{
    public class BoardFrame
    {
        private readonly ColoredPillar[,] _board;

        public int Width => _board.GetLength(1);
        public int Height => _board.GetLength(0);



        public BoardFrame(Map map)
        {
            _board = new ColoredPillar[map.Height, map.Width];

            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    _board[y, x] = ColoredPillar.Parse(map.GetField(x, y));
                }
            }
        }

        /// <summary>
        /// Initialize a new instance while droping reference.
        /// </summary>
        /// <param name="frame">Old <see cref="BoardFrame"/>.</param>
        public BoardFrame(BoardFrame frame)
        {
            _board = new ColoredPillar[frame.Height, frame.Width];

            for (int x = 0; x < frame.Width; x++)
            {
                for (int y = 0; y < frame.Height; y++)
                {
                    _board[y, x] = frame.GetFrom(x, y);
                }
            }
        }



        /// <summary>
        /// Change values on the frame at a specific position.
        /// </summary>
        /// <param name="position">Can be a non reference <see cref="ColoredPillar"/>.</param>
        public void SetInPosition(ColoredPillar position)
        {
            _board[position.Y, position.X] = position;

            Log.Debug($"BoardFrame.SetInPosition({position.X}; {position.Y}) Height: {position.Height}", -1);
        }

        /// <summary>
        /// Get a reference <see cref="ColoredPillar"/> from the frame.
        /// </summary>
        /// <param name="x">X coordinate.</param>
        /// <param name="y">Y coordinate.</param>
        /// <returns>Reference <see cref="ColoredPillar"/>.</returns>
        public ColoredPillar GetFrom(int x, int y)
        {
            return _board[y, x];
        }
    }
}
