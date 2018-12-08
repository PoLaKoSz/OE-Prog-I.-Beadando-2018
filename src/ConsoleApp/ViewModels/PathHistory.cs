using PoLaKoSz.OE._2018_.PyramidGame.Models;
using System;

namespace PoLaKoSz.OE._2018_.PyramidGame.ViewModels
{
    public class PathHistory
    {
        private readonly Builder _model;
        private int _currentPosition;


        public bool IsEnded => (_currentPosition == _model.Path.Length);
        public bool HasBegun => (_model.Path.Length != 0);



        public PathHistory(Builder model)
        {
            _model = model;
        }



        /// <summary>
        /// Get the next position of the <see cref="Builder"/>'s path.
        /// The next position calculated and stored in this instance.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException">Use IsEnd and / or
        /// HasBegun property before access this method to prevent this
        /// Exception.</exception>
        public Pillar GetOld()
        {
            Pillar step = _model.Path.GetByIndex(_currentPosition);

            Log.Debug($"OLD POSITION({step.X}; {step.Y}), Height: {step.Height}");

            _currentPosition++;

            return step;
        }

        /// <summary>
        /// Get the last place where the <see cref="Builder"/> was.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public Pillar Last()
        {
            return _model.Path.GetByIndex(_model.Path.Length - 1);
        }
    }
}
