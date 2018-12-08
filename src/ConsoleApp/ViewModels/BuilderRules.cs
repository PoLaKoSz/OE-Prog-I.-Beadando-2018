using PoLaKoSz.OE._2018_.PyramidGame.Models;
using System;

namespace PoLaKoSz.OE._2018_.PyramidGame.ViewModels
{
    public class BuilderRules
    {
        public Pillar[] Steppable(Pillar[] positions, Pillar lastPosition)
        {
            Log.Debug("BuilderRules.Steppable()", 1);

            int index = 0;

            for (int i = 0; i < positions.Length; i++)
            {
                if (CanStep(lastPosition, positions[i]))
                {
                    positions[index] = positions[i];

                    index++;
                }
            }

            Pillar[] available = new Pillar[index];

            for (int i = 0; i < available.Length; i++)
            {
                available[i] = positions[i];

                Log.Debug($"({available[i].X}; {available[i].Y})");
            }

            Log.Debug(-1, "BuilderRules.Steppable() END");

            return available;
        }

        /// <summary>
        /// Get one or more positions where the <see cref="Builder"/> can build.
        /// </summary>
        /// <param name="posititons">Positions where the <see cref="Builder"/> can move (max 3 position)</param>
        ///<param name="lastPosition">Position where the <see cref="Builder"/> came from.</param>
        /// <returns>Collection of <see cref="Pillar"/> where the <see cref="Builder"/> can build.</returns>
        public Pillar[] Buildable(Pillar[] posititons, Pillar lastPosition)
        {
            Log.Debug("BuilderRules.Buildable()", 1);

            int index = 0;

            for (int i = 0; i < posititons.Length; i++)
            {
                if (posititons[i].Height <= lastPosition.Height)
                {
                    posititons[index] = posititons[i];

                    index++;
                }
            }

            Pillar[] available = new Pillar[index];

            for (int i = 0; i < available.Length; i++)
            {
                available[i] = posititons[i];

                Log.Debug($"({available[i].X}; {available[i].Y})");
            }

            Log.Debug(-1, "BuilderRules.Buildable() END");

            return available;
        }

        public bool IsNextEachOther(Pillar one, Pillar two)
        {
            return (ColumnDistance(one, two) + RowDistance(one, two) == 1);
        }

        /// <summary>
        /// Get a valid starting point for the <see cref="Builder"/>.
        /// </summary>
        /// <param name="map">The board where the action is happening.</param>
        /// <returns>Reference object from the <see cref="Map"/>.</returns>
        public Pillar InitialPosition(Map map)
        {
            int x = PyramidGame.Random.Next(0, map.Width);
            int y = PyramidGame.Random.Next(0, map.Height);

            if ((x != 0 || x != map.Width - 1) && (y != 0 || y != map.Height - 1))
            {
                var randInt = PyramidGame.Random.Next(0, 4);

                if (0 == randInt)
                    x = 0;
                else if (1 == randInt)
                    x = map.Width - 1;
                else if (2 == randInt)
                    y = 0;
                else
                    y = map.Height - 1;
            }

            Pillar position = map.GetField(x, y);

            Log.Debug($"InitialPosition({position.X}; {position.Y})");

            return position;
        }


        private bool CanStep(Pillar from, Pillar to)
        {
            return ((from.Height + 1) == to.Height)
                && IsNextEachOther(from, to);
        }

        private int ColumnDistance(Pillar one, Pillar two)
        {
            return Math.Abs(one.X - two.X);
        }

        private int RowDistance(Pillar one, Pillar two)
        {
            return Math.Abs(one.Y - two.Y);
        }
    }
}
