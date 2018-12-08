using PoLaKoSz.OE._2018_.PyramidGame.Models;
using System;

namespace PoLaKoSz.OE._2018_.PyramidGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Disable();

            ViewModels.PyramidGame game = new ViewModels.PyramidGame();

            GameSettings.AnimationDelay = 2;

            game.Initialize();

            try
            {
                game.StartGameLoop();
            }
            catch (Exception ex)
            {
                Log.Debug($"\nException: {ex}");
                Log.Rotate();

                Console.WriteLine(ex);
                Console.Read();
            }
        }
    }
}
