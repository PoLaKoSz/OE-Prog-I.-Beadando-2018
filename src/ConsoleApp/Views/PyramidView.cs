using PoLaKoSz.OE._2018_.PyramidGame.Models;
using System;

namespace PoLaKoSz.OE._2018_.PyramidGame.Views
{
    public class PyramidView
    {
        public char CharInput(string message)
        {
            Console.WriteLine(message);

            return char.Parse(Console.ReadLine());
        }

        public ColoredPillar DrawPillar(Pillar position)
        {
            return ColoredPillar.Parse(position);
        }
    }
}
