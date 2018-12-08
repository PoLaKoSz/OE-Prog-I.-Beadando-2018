using System;

namespace PoLaKoSz.OE._2018_.PyramidGame.Models
{
    public class ColoredPillar// : Pillar
    {
        public int X { get; }
        public int Y { get; }
        public int Height { get; }
        public ConsoleColor FontColor { get; }
        public ConsoleColor BackGroundColor { get; }



        /// <summary>
        /// Initialize a new instance with the default
        /// FontColor and BackGroundColor properties.
        /// </summary>
        public ColoredPillar(ColoredPillar pillar)
            : this(pillar.X, pillar.Y, pillar.Height, ConsoleColor.White, ConsoleColor.Black) { }

        public ColoredPillar(int x, int y, int height, ConsoleColor fontColor, ConsoleColor bgColor)
        {
            X = x;
            Y = y;
            Height = height;
            FontColor = fontColor;
            BackGroundColor = bgColor;
        }



        public static ColoredPillar Parse(Pillar pillar)
        {
            return new ColoredPillar(pillar.X, pillar.Y, pillar.Height, ConsoleColor.White, ConsoleColor.Black);
        }
    }
}
