using NUnit.Framework;
using PoLaKoSz.OE._2018_.PyramidGame.Models;
using PoLaKoSz.OE._2018_.PyramidGame.ViewModels;
using System;

namespace PoLaKoSz.OE._2018_.PyramidGame.Tests.Unit.ViewModels
{
    [TestFixture]
    public class PathHistoryTests
    {
        public class ContructorTests
        {
            [Test]
            public void IsEnd_Should_Be_True_With_Fresh_Builder()
            {
                var builder = new Builder();
                var pathHistory = new PathHistory(builder);

                Assert.That(pathHistory.IsEnded, Is.True);
            }

            [Test]
            public void HasBegun_Should_Be_False_With_Fresh_Builder()
            {
                var builder = new Builder();
                var pathHistory = new PathHistory(builder);

                Assert.That(pathHistory.HasBegun, Is.False);
            }
        }

        public class GetOldTests
        {
            [Test]
            public void Builder_Without_Path_Should_Throw_IndexOutOfRangeException()
            {
                var model = new Builder();
                var pathHistory = new PathHistory(model);

                Assert.Throws<IndexOutOfRangeException>(() => pathHistory.GetOld());
            }

            [Test]
            public void Builder_With_One_Step_Should_Return_The_First_Step()
            {
                var model = new Builder();
                var pathHistory = new PathHistory(model);

                model.Path.Increase(new Pillar(3, 10));

                var actual = pathHistory.GetOld();

                Assert.That(actual.X, Is.EqualTo(3), "pillar.X");
                Assert.That(actual.Y, Is.EqualTo(10), "pillar.Y");
            }

            [TestCase(2)]
            [TestCase(3)]
            [TestCase(4)]
            public void Builder_With_Multiple_Steps(int skipOldStepCount)
            {
                var model = new Builder();
                var pathHistory = new PathHistory(model);

                model.Path.Increase(new Pillar(0, 0));
                model.Path.Increase(new Pillar(2, 1));
                model.Path.Increase(new Pillar(4, 2));
                model.Path.Increase(new Pillar(6, 3));
                model.Path.Increase(new Pillar(8, 4));

                for (int i = 0; i < skipOldStepCount; i++)
                {
                    pathHistory.GetOld();
                }

                var actual = pathHistory.GetOld();

                Assert.That(actual.X, Is.EqualTo(skipOldStepCount * 2), "pillar.X");
                Assert.That(actual.Y, Is.EqualTo(skipOldStepCount), "pillar.Y");
            }
        }

        public class LastTests
        {
            [Test]
            public void Builder_Without_Path_Should_Throw_IndexOutOfRangeException()
            {
                var model = new Builder();
                var pathHistory = new PathHistory(model);

                Assert.Throws<IndexOutOfRangeException>(() => pathHistory.Last());
            }

            [Test]
            public void Builder_With_Multiple_Steps_Should_Return_The_Last_One()
            {
                var model = new Builder();
                var pathHistory = new PathHistory(model);

                model.Path.Increase(new Pillar(0, 0));
                model.Path.Increase(new Pillar(2, 1));
                model.Path.Increase(new Pillar(4, 2));
                model.Path.Increase(new Pillar(6, 3));
                model.Path.Increase(new Pillar(8, 4));

                var actual = pathHistory.Last();

                Assert.That(actual.X, Is.EqualTo(8), "pillar.X");
                Assert.That(actual.Y, Is.EqualTo(4), "pillar.Y");
            }
        }
    }
}
