using PoLaKoSz.OE._2018_.PyramidGame.Models;
using System;

namespace PoLaKoSz.OE._2018_.PyramidGame.Views
{
    public class BoardView
    {
        public void Display(BoardFrame frame)
        {
            for (int y = 0; y < frame.Height; y++)
            {
                for (int x = 0; x < frame.Width; x++)
                {
                    ColoredPillar position = frame.GetFrom(x, y);

                    Console.Write(" ");
                    Console.BackgroundColor = position.BackGroundColor;
                    Console.ForegroundColor = position.FontColor;
                    Console.Write("{0, 3}", position.Height);
                    Console.ResetColor();
                    Console.Write(" |");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
