using PoLaKoSz.OE._2018_.PyramidGame.Models;
using System;

namespace PoLaKoSz.OE._2018_.PyramidGame.ViewModels
{
    public class PathGenerator
    {
        private readonly Map _map;

        /// <summary>
        /// Container for <see cref="Path"/>s.
        /// Use the <see cref="_rowCount"/> field to index properly.
        /// </summary>
        public Path[] _results; // TODO : Make it private

        /// <summary>
        /// Indicates how many not null rows has the <see cref="_results"/>.
        /// </summary>
        public int _rowCount; // TODO : make it private

        private readonly NearestPillars _nearestPillars;
        private readonly BuilderRules _rules;



        /// <summary>
        /// Initialize an instance to calculate path details.
        /// </summary>
        /// <param name="map">Has to be at least 1x1.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <see cref="Map.Width"/> or <see cref="Map.Height"/> is less than 1.</exception>
        public PathGenerator(Map map, BuilderRules rules)
        {
            if (map.Width < 1)
                throw new ArgumentOutOfRangeException($"{nameof(map.Width)} has to be at least 1.");

            if (map.Height < 1)
                throw new ArgumentOutOfRangeException($"{nameof(map.Height)} has to be at least 1.");

            _map = map;

            int rowCount = (int) Math.Pow(Math.Max(map.Width, map.Height), 3);
            _results = new Path[rowCount];

            _nearestPillars = new NearestPillars(_map);
            _rules = rules;
        }



        /// <summary>
        /// Discover the longest <see cref="Path"/> on the <see cref="Map"/>.
        /// </summary>
        /// <returns>Non null object.</returns>
        public Path Longest()
        {
            Discover();

            int maxIndex = 0;

            for (int i = 0; i < _results.Length; i++)
            {
                if (_rowCount <= i)
                {
                    i = _results.Length;
                }
                else if (_results[maxIndex].Length < _results[i].Length)
                {
                    maxIndex = i;
                }
            }

            return _results[maxIndex];
        }


        /// <summary>
        /// Fill up the <seealso cref="_results"/> array with values.
        /// </summary>
        private void Discover()
        {
            DiscoverFromTop();

            DiscoverFromLeft();

            DiscoverFromBottom();

            DiscoverFromRight();
        }

        private void DiscoverFromTop()
        {
            for (int x = 0; x < _map.Width; x++)
            {
                AddInitialPosition(x, 0);

                DiscoverRoutes(_results[_rowCount]);

                _rowCount++;
            }
        }

        private void DiscoverFromLeft()
        {
            for (int y = 1; y < _map.Height; y++)
            {
                AddInitialPosition(_map.Width - 1, y);

                DiscoverRoutes(_results[_rowCount]);

                _rowCount++;
            }
        }

        private void DiscoverFromBottom()
        {
            for (int x = _map.Width - 2; 0 <= x; x--)
            {
                AddInitialPosition(x, _map.Height - 1);

                DiscoverRoutes(_results[_rowCount]);

                _rowCount++;
            }
        }

        private void DiscoverFromRight()
        {
            for (int y = _map.Height - 2; 1 <= y; y--)
            {
                AddInitialPosition(0, y);

                DiscoverRoutes(_results[_rowCount]);

                _rowCount++;
            }
        }

        /// <summary>
        /// Creates a new <see cref="Path"/> instance from the given
        /// coordinate which should be the edge of the <see cref="Map"/>.
        /// </summary>
        /// <param name="x">Greater or equal to 0.</param>
        /// <param name="y">Greater or equal to 0.</param>
        private void AddInitialPosition(int x, int y)
        {
            if (_results.Length == _rowCount)
                AddMoreEmptyRows(10);

            _results[_rowCount] = new Path();
            _results[_rowCount].Increase(_map.GetField(x, y));
        }

        private void DiscoverRoutes(Path path)
        {
            Pillar lastPosition = path.Last();

            _nearestPillars.SetPillars(lastPosition);

            if (_nearestPillars.HasAny)
            {
                Pillar[] nearestPositions = _nearestPillars.Pillars;

                Pillar[] steppablePositions = _rules.Steppable(nearestPositions, lastPosition);

                if (steppablePositions.Length == 1)
                {
                    path.Increase(steppablePositions[0]);

                    DiscoverRoutes(path);
                }
                else if (1 < steppablePositions.Length)
                {
                    foreach (var newBranch in steppablePositions)
                    {
                        int cloneIndex = Clone(path);

                        DiscoverRoutes(_results[cloneIndex]);
                    }
                }
            }
        }

        /// <summary>
        /// Clone the given path to a new row into the <see cref="_results"/>.
        /// </summary>
        /// <param name="path">Non null object.</param>
        /// <returns>The index, where the clone has placed.</returns>
        private int Clone(Path path)
        {
            if (_rowCount == _results.Length)
            {
                AddMoreEmptyRows(10);
            }

            _results[_rowCount] = path.Clone();

            _rowCount++;

            return _rowCount - 1;
        }

        /// <summary>
        /// Increase the row number in the <see cref="_results"/> array.
        /// </summary>
        /// <param name="count">Number how much rows should be added.</param>
        private void AddMoreEmptyRows(int count)
        {
            var tmp = _results;

            _results = new Path[_results.Length + count];

            for (int i = 0; i < tmp.Length; i++)
            {
                _results[i] = tmp[i];
            }
        }
    }
}
