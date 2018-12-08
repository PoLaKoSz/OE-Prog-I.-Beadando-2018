using PoLaKoSz.OE._2018_.PyramidGame.Models;
using PoLaKoSz.OE._2018_.PyramidGame.Views;

namespace PoLaKoSz.OE._2018_.PyramidGame.ViewModels
{
    public class BuilderViewModel
    {
        private readonly Map _map;
        private readonly NearestPillars _nearestPillars;
        private readonly static BuilderRules _rules;


        public Builder Model { get; private set; }
        public BuilderView View { get; private set; }



        static BuilderViewModel()
        {
            _rules = new BuilderRules();
        }

        public BuilderViewModel(Map map)
        {
            Model = new Builder();
            View = new BuilderView();

            _map = map;
            _nearestPillars = new NearestPillars(_map);
        }



        /// <summary>
        /// Make the <see cref="Builder"/> to step one or
        /// place a <see cref="StoneCube"/> to one of the nearest place.
        /// </summary>
        /// <returns><c>TRUE</c> when this method should be called again</summary>
        public bool Bind()
        {
            if (Model.Path.Length == 0)
            {
                Pillar lastPosition = _rules.InitialPosition(_map);

                Step(lastPosition);

                return true;
            }
            else
            {
                Pillar lastPosition = Model.Path.Last();
                Pillar beforeLastPosition = null;

                if (1 < Model.Path.Length)
                    beforeLastPosition = Model.Path.BeforeLast();

                return StepOrBuild(lastPosition, beforeLastPosition);
            }
        }


        private bool StepOrBuild(Pillar lastPosition, Pillar beforeLastPosition)
        {
            _nearestPillars.SetPillars(lastPosition, beforeLastPosition);

            Pillar[] steppablePositions = _rules.Steppable(_nearestPillars.Pillars, lastPosition);

            if (0 < steppablePositions.Length)
            {
                lastPosition = _map.GetField(steppablePositions[PyramidGame.Random.Next(0, steppablePositions.Length)]);

                Step(lastPosition);

                return true;
            }
            else
            {
                Pillar[] buildablePos = _rules.Buildable(_nearestPillars.Pillars, lastPosition);

                if (buildablePos.Length != 0)
                {
                    lastPosition = _map.GetField(buildablePos[PyramidGame.Random.Next(0, buildablePos.Length)]);
                }

                Build(lastPosition);

                return false;
            }
        }

        private void Step(Pillar position)
        {
            Model.Step(position);

            Log.Debug($"STEP ({position.X}; {position.Y})");
        }

        private void Build(Pillar position)
        {
            Model.Step(position);

            position.Build();

            Log.Debug($"BUILD ({position.X}; {position.Y}) Height : {position.Height - 1} -> {_map.GetField(position).Height}", 1);
        }
    }
}