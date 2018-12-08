using NUnit.Framework;
using PoLaKoSz.OE._2018_.PyramidGame.Models;

namespace PoLaKoSz.OE._2018_.PyramidGame.Tests.Unit.Models
{
    class MapTests
    {
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(30)]
        public void Constructor_Check_New_Map_Width_Property(int width)
        {
            var map = new Map(width, 1);

            Assert.That(map.Width, Is.EqualTo(width), "map.Width");
        }

        [TestCase(1)]
        [TestCase(3)]
        [TestCase(30)]
        public void Constructor_Check_New_Map_Height_Property(int heigth)
        {
            var map = new Map(1, heigth);

            Assert.That(map.Height, Is.EqualTo(heigth), "map.Height");
        }

        [Test]
        public void Constructor_Check_Initial_Height()
        {
            int width = 3;
            int height = 10;
            var map = new Map(3, 10);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var actual = map.GetField(x, y);

                    Assert.That(actual.Height, Is.EqualTo(1), $"actual({actual.X}; {actual.Y}).Height");
                }
            }
        }



        [Test]
        public void GetField_Method_With_Coordinates()
        {
            int width = 2;
            int height = 5;

            var map = new Map(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var actual = map.GetField(x, y);

                    Assert.That(actual.X, Is.EqualTo(x), "actual.X");
                    Assert.That(actual.Y, Is.EqualTo(y), "actual.Y");
                }
            }
        }



        [Test]
        public void SetField_Method()
        {
            var map = new Map(3);
            var field = new Pillar(1, 2);

            field.Build();
            field.Build();
            map.SetField(field);

            var actual = map.GetField(1, 2);

            Assert.That(actual.X, Is.EqualTo(1), "actual.X");
            Assert.That(actual.Y, Is.EqualTo(2), "actual.Y");
            Assert.That(actual.Height, Is.EqualTo(3), "actual.Height");
        }
    }
}
