using NUnit.Framework;
using PoLaKoSz.OE._2018_.PyramidGame.Models;
using System;

namespace PoLaKoSz.OE._2018_.PyramidGame.Tests.Unit.Models
{
    class BoardFrameTests
    {
        [Test]
        public void Constructor_Can_Drop_Reference()
        {
            var map = new Pillar[4, 4]
            {
                { new Pillar(0, 0, 100), new Pillar(1, 0, 100), new Pillar(2, 0, 1), new Pillar(3, 0, 100) },
                { new Pillar(0, 1, 100), new Pillar(1, 1, 100), new Pillar(2, 1, 2), new Pillar(3, 1, 100) },
                { new Pillar(0, 2, 100), new Pillar(1, 2, 100), new Pillar(2, 2, 3), new Pillar(3, 2, 100) },
                { new Pillar(0, 3, 100), new Pillar(1, 3, 100), new Pillar(2, 3, 4), new Pillar(3, 3, 100) },
            };
            var oldFrame = new BoardFrame(new Map(map));
            var actual = new BoardFrame(oldFrame);
            int x = 1;
            int y = 2;

            var oldColoredPillar = new ColoredPillar(x, y, 4, ConsoleColor.Magenta, ConsoleColor.Black);
            oldFrame.SetInPosition(oldColoredPillar);

            Assert.IsFalse(ReferenceEquals(
                oldFrame.GetFrom(x, y),
                actual.GetFrom(x, y)),
                $"oldframe[{x}, {y}] should not reference actual[{x}, {y}]");

            var oldFramePillar = oldFrame.GetFrom(x, y);
            Assert.That(oldFramePillar.X, Is.EqualTo(x), "oldFramePillar.X");
            Assert.That(oldFramePillar.Y, Is.EqualTo(y), "oldFramePillar.Y");
            Assert.That(oldFramePillar.Height, Is.EqualTo(4), "oldFramePillar.Height");

            var actualFramePillar = actual.GetFrom(x, y);
            Assert.That(actualFramePillar.X, Is.EqualTo(x), "actualFramePillar.X");
            Assert.That(actualFramePillar.Y, Is.EqualTo(y), "actualFramePillar.Y");
            Assert.That(actualFramePillar.Height, Is.EqualTo(100), "actualFramePillar.Height");
        }
    }
}
