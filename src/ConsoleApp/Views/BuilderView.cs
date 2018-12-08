using PoLaKoSz.OE._2018_.PyramidGame.Models;
using System;

namespace PoLaKoSz.OE._2018_.PyramidGame.Views
{
    public class BuilderView
    {
        /// <summary>
        /// Display the <see cref="Builder"/> old route on the UI.
        /// </summary>
        public ColoredPillar RouteReWalk(Pillar position)
        {
            return new ColoredPillar(position.X, position.Y, position.Height, ConsoleColor.Blue, ConsoleColor.Black);
        }

        /// <summary>
        /// Display the <see cref="Builder"/> new route on the UI.
        /// </summary>
        public ColoredPillar NewStep(Pillar position)
        {
            return new ColoredPillar(position.X, position.Y, position.Height, ConsoleColor.Black, ConsoleColor.White);
        }

        /// <summary>
        /// Animation for the <see cref="Builder"/> to place a <see cref="StoneCube"/>
        /// to the <see cref="Pillar"/>.
        /// </summary>
        public ColoredPillar Build(Pillar position)
        {
            return new ColoredPillar(position.X, position.Y, position.Height, ConsoleColor.DarkRed, ConsoleColor.Black);
        }
    }
}
