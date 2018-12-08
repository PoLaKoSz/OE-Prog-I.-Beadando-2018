using System;
using PoLaKoSz.OE._2018_.PyramidGame.Models;
using PoLaKoSz.OE._2018_.PyramidGame.Views;

namespace PoLaKoSz.OE._2018_.PyramidGame.ViewModels
{
    public class BoardViewModel
    {
        private readonly BoardView _view;
        private BoardFrame[] _frames;
        private Map _map;
        private int _setterIndex;
        private int _displayIndex;



        public BoardViewModel(Map map)
        {
            ChangeBoard(map);

            _view = new BoardView();
        }



        public bool ShowNextFrame()
        {
            Log.Debug($"ShowNextFrame() #{_displayIndex}");

            BoardFrame frame = _frames[_displayIndex];

            _view.Display(frame);

            _displayIndex++;

            return _displayIndex < _frames.Length;
        }

        /// <summary>
        /// Generate a collection of <see cref="BoardFrame"/>
        /// to display it on the <see cref="Console"/>.
        /// </summary>
        /// <param name="model">Object with a Path property.</param>
        /// <param name="view">View for the model.</param>
        public void GenerateFrames(Builder model, BuilderView view)
        {
            for (int i = 0; i < model.Path.Length - 1; i++)
            {
                ColoredPillar newStep = view.NewStep(model.Path.GetByIndex(i));
                SetInCurrentFrame(newStep, "STEP");

                SwitchToNextFrame();

                RouteRewalk(model, view, i);
            }

            if (0 < model.Path.Length)
            {
                ColoredPillar position = view.Build(_map.GetField(model.Path.Last()));

                SetInCurrentFrame(position, "BUILD");
            }
        }

        /// <summary>
        /// Purge every frame and initialize a new UI for a <see cref="Map"/>.
        /// </summary>
        /// <param name="newMap"><see cref="Map"/> that should be in the
        /// first <see cref="BoardFrame"/>.</param>
        public void ChangeBoard(Map newMap)
        {
            _map = newMap;

            Log.Debug("Clean frames - Add map");

            _frames = new BoardFrame[1]
            {
                new BoardFrame(newMap)
            };

            ResetVariables();

            SwitchToNextFrame();
        }


        /// <summary>
        /// Increase the frame collection with one and
        /// initialize the last frame with the <see cref="Map"/> values.
        /// </summary>
        private void SwitchToNextFrame()
        {
            _setterIndex++;

            Log.Debug("");

            BoardFrame[] oldFrames = _frames;
            _frames = new BoardFrame[oldFrames.Length + 1];

            for (int i = 0; i < oldFrames.Length; i++)
            {
                _frames[i] = new BoardFrame(oldFrames[i]);
            }

            _frames[_frames.Length - 1] = new BoardFrame(oldFrames[oldFrames.Length - 1]);
        }

        private void SetInCurrentFrame(ColoredPillar position, string msg)
        {
            Log.Debug($"SetInCurrentFrame #{_setterIndex} {msg} : ({position.X}; {position.Y}) Height: {position.Height}", 1);

            _frames[_setterIndex].SetInPosition(position);
        }

        private void RouteRewalk(Builder model, BuilderView view, int maxIndex)
        {
            for (int i = 0; i <= maxIndex; i++)
            {
                ColoredPillar oldStep = view.RouteReWalk(model.Path.GetByIndex(i));
                SetInCurrentFrame(oldStep, "REWALK");
            }
        }

        private void ResetVariables()
        {
            _setterIndex = 0;
            _displayIndex = 0;
        }
    }
}
