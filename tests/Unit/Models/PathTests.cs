using NUnit.Framework;
using PoLaKoSz.OE._2018_.PyramidGame.Models;
using System;

namespace PoLaKoSz.OE._2018_.PyramidGame.Tests.Unit.Models
{
    class PathTests
    {
        class ConstructorTests
        {
            private Path _path;



            [OneTimeSetUp]
            public void Init()
            {
                _path = new Path();
            }



            [Test]
            public void Length_Should_Be_Zero()
            {
                Assert.That(_path.Length, Is.EqualTo(0));
            }

            [Test]
            public void GetByIndex_With_Zero_Parameter_Should_Throw_IndexOutOfRangeException()
            {
                Assert.Throws<IndexOutOfRangeException>(() => { _path.GetByIndex(0); });
            }
        }

        class IncreaseTests
        {
            [Test]
            public void Increase_Method_Should_Not_Throw_Exception()
            {
                Path path = new Path();

                Assert.DoesNotThrow(() => path.Increase(new Pillar(0, 0)));
            }

            [TestCase(1)]
            [TestCase(10)]
            public void Length_Should_Be(int count)
            {
                Path path = new Path();

                for (int i = 0; i < count; i++)
                {
                    path.Increase(new Pillar(0, 0));
                }

                Assert.That(path.Length, Is.EqualTo(count));
            }
        }

        class GetByIndexTests
        {
            [TestCase(1)]
            [TestCase(10)]
            public void Chech_Coordinates_On_Generated_Item_Of(int xCoord)
            {
                Path path = new Path();
                int coordDiff = 2;

                for (int i = 0; i < xCoord; i++)
                {
                    path.Increase(new Pillar(i, i + coordDiff));
                }

                for (int i = 0; i < xCoord; i++)
                {
                    Pillar pillar = path.GetByIndex(i);

                    Assert.That(pillar.X, Is.EqualTo(i));
                    Assert.That(pillar.Y, Is.EqualTo(i + coordDiff));
                }

                Assert.Pass("");
            }
        }

        [Test]
        public void Clone_Method_Return_Drop_Paht_Reference()
        {
            var oldPath = new Path();
            oldPath.Increase(new Pillar(0, 0));

            var newPath = oldPath.Clone();

            Assert.That(newPath.Length, Is.EqualTo(1), "newPath.Length");

            oldPath.Increase(new Pillar(0, 1));

            Assert.That(newPath.Length, Is.EqualTo(1), "newPath.Length after oldPath increased");
        }
    }
}
