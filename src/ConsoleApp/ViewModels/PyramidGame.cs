using PoLaKoSz.OE._2018_.PyramidGame.DataAccessLayer;
using PoLaKoSz.OE._2018_.PyramidGame.Models;
using PoLaKoSz.OE._2018_.PyramidGame.Views;
using System;
using System.Threading;

namespace PoLaKoSz.OE._2018_.PyramidGame.ViewModels
{
    public class PyramidGame
    {
        private Map _map;
        private BuilderViewModel _builder;
        private readonly PyramidView _view;
        private readonly BoardViewModel _boardViewGenerator;
        private readonly FileAccess _file;
        private readonly PathGenerator _pathGenerator;

        internal static readonly Random Random;



        static PyramidGame()
        {
            Random = new Random();
        }

        public PyramidGame()
        {
            _map = new Map(1);
            _boardViewGenerator = new BoardViewModel(_map);
            _builder = new BuilderViewModel(_map);
            _view = new PyramidView();
            _file = new FileAccess();
            _pathGenerator = new PathGenerator(_map, new BuilderRules());
        }



        public void Initialize()
        {
            if (_file.CanRead())
            {
                _map = _file.Read();
            }
            else
            {
                _map = new Map(Random.Next(3, 10), Random.Next(3, 13));
            }

            _builder = new BuilderViewModel(_map);
        }

        /// <summary>
        /// Modify the Board and display the changes on the UI
        /// </summary>
        public void StartGameLoop()
        {
            do
            {
                Log.Debug("StartGameLoop() LOOP", 1);

                _boardViewGenerator.ChangeBoard(_map);

                Log.Debug("Builder().Bind()", 1);

                while (_builder.Bind())
                {

                }

                Log.Debug(-2, "Builder().Bind() END");

                _boardViewGenerator.GenerateFrames(_builder.Model, _builder.View);

                while (_boardViewGenerator.ShowNextFrame())
                {
                    Delay();
                }

                Delay();

                _builder = new BuilderViewModel(_map);

                Log.Debug(-1, "StartGameLoop() LOOP END\n");

                Console.WriteLine("\n\n");
            } while (ShouldRun());

            _file.Write(_map, _pathGenerator.Longest().GetByIndex(0));
        }


        private bool ShouldSave()
        {
            return 's' == char.ToLower(_view.CharInput("Nyomd meg az 's' betűt a jelenlegi állás elmentéséhez!"));
        }

        private bool ShouldRun()
        {
            // TODO : Skip animation with [Enter] or something
            return true;
            return 'q' != char.ToLower(_view.CharInput("Nyomd meg a 'q' betűt az animáció megállításához!"));
        }

        private void Delay()
        {
            Thread.Sleep(GameSettings.AnimationDelay * 1000);
        }
    }
}
