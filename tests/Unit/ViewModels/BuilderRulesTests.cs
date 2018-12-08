using NUnit.Framework;
using PoLaKoSz.OE._2018_.PyramidGame.Models;
using PoLaKoSz.OE._2018_.PyramidGame.ViewModels;

namespace PoLaKoSz.OE._2018_.PyramidGame.Tests.Unit.ViewModels
{
    public class BuilderRulesTests
    {
        public class SteppableTests
        {
            private readonly BuilderRules _rules = new BuilderRules();



            [Test]
            public void No_Steppable_Pillars_Should_Return_Empty_Array()
            {
                /*
                 * X = lastPosition
                 *
                 *       0   1   2     X axis
                 *  0  |   | 0 |   |
                 *  1  | 0 | X | 0 |
                 *  2  |   | 0 |   |
                 *
                 *  Y
                 *
                 *  a
                 *  x
                 *  i
                 *  s
                */
                var nearestPillars = new Pillar[4]
                {
                    new Pillar(1, 0),
                    new Pillar(2, 1),
                    new Pillar(1, 2),
                    new Pillar(0, 1),
                };

                var lastPosition = new Pillar(1, 1);
                lastPosition.Build();

                var actual = _rules.Steppable(nearestPillars, lastPosition);

                Assert.That(actual, Is.Not.Null);
                Assert.That(actual.Length, Is.EqualTo(0));
            }

            [Test]
            public void One_Steppable_Pillars_Should_Return_One_Item()
            {
                /*
                 * X = lastPosition
                 *
                 *       0   1   2     X axis
                 *  0  |   | 0 |   |
                 *  1  | 0 | X | 2 |
                 *  2  |   | 0 |   |
                 *
                 *  Y
                 *
                 *  a
                 *  x
                 *  i
                 *  s
                */

                var highestPillar = new Pillar(2, 1);
                highestPillar.Build();
                highestPillar.Build();

                var nearestPillars = new Pillar[4]
                {
                    new Pillar(1, 0),
                    highestPillar,
                    new Pillar(1, 2),
                    new Pillar(0, 1),
                };

                var lastPosition = new Pillar(1, 1);
                lastPosition.Build();

                var actual = _rules.Steppable(nearestPillars, lastPosition);

                Assert.That(actual, Is.Not.Null);
                Assert.That(actual.Length, Is.EqualTo(1));

                Assert.That(actual[0].X, Is.EqualTo(highestPillar.X), "highestPillar.X");
                Assert.That(actual[0].Y, Is.EqualTo(highestPillar.Y), "highestPillar.Y");

            }

            [Test]
            public void Two_Steppable_Pillars_Should_Return_One_Item()
            {
                /*
                 * X = lastPosition
                 *
                 *       0   1   2     X axis
                 *  0  |   | 0 |   |
                 *  1  | 0 | X | 2 |
                 *  2  |   | 2 |   |
                 *
                 *  Y
                 *
                 *  a
                 *  x
                 *  i
                 *  s
                */

                var right = new Pillar(2, 1);
                right.Build();
                right.Build();

                var bottom = new Pillar(1, 2);
                bottom.Build();
                bottom.Build();

                var nearestPillars = new Pillar[4]
                {
                    new Pillar(1, 0),
                    right,
                    bottom,
                    new Pillar(0, 1),
                };

                var lastPosition = new Pillar(1, 1);
                lastPosition.Build();

                var actual = _rules.Steppable(nearestPillars, lastPosition);

                Assert.That(actual, Is.Not.Null);
                Assert.That(actual.Length, Is.EqualTo(2));

                Assert.That(actual[0].X, Is.EqualTo(right.X), "right.X");
                Assert.That(actual[0].Y, Is.EqualTo(right.Y), "right.X");

                Assert.That(actual[1].X, Is.EqualTo(bottom.X), "bottom.X");
                Assert.That(actual[1].Y, Is.EqualTo(bottom.Y), "bottom.X");

            }

            [Test]
            public void Three_Steppable_Pillars_Should_Return_One_Item()
            {
                /*
                 * X = lastPosition
                 *
                 *       0   1   2     X axis
                 *  0  |   | 0 |   |
                 *  1  | 2 | X | 2 |
                 *  2  |   | 2 |   |
                 *
                 *  Y
                 *
                 *  a
                 *  x
                 *  i
                 *  s
                */

                var right = new Pillar(2, 1);
                right.Build();
                right.Build();

                var bottom = new Pillar(1, 2);
                bottom.Build();
                bottom.Build();

                var left = new Pillar(0, 1);
                left.Build();
                left.Build();

                var nearestPillars = new Pillar[4]
                {
                    new Pillar(1, 0),
                    right,
                    bottom,
                    left,
                };

                var lastPosition = new Pillar(1, 1);
                lastPosition.Build();

                var actual = _rules.Steppable(nearestPillars, lastPosition);

                Assert.That(actual, Is.Not.Null);
                Assert.That(actual.Length, Is.EqualTo(3));

                Assert.That(actual[0].X, Is.EqualTo(right.X), "right.X");
                Assert.That(actual[0].Y, Is.EqualTo(right.Y), "right.X");

                Assert.That(actual[1].X, Is.EqualTo(bottom.X), "bottom.X");
                Assert.That(actual[1].Y, Is.EqualTo(bottom.Y), "bottom.X");

                Assert.That(actual[2].X, Is.EqualTo(left.X), "left.X");
                Assert.That(actual[2].Y, Is.EqualTo(left.Y), "left.X");

            }

            [Test]
            public void Four_Steppable_Pillars_Should_Return_One_Item()
            {
                /*
                 * X = lastPosition
                 *
                 *       0   1   2     X axis
                 *  0  |   | 2 |   |
                 *  1  | 2 | X | 2 |
                 *  2  |   | 2 |   |
                 *
                 *  Y
                 *
                 *  a
                 *  x
                 *  i
                 *  s
                */

                var right = new Pillar(2, 1);
                right.Build();
                right.Build();

                var bottom = new Pillar(1, 2);
                bottom.Build();
                bottom.Build();

                var left = new Pillar(0, 1);
                left.Build();
                left.Build();

                var top = new Pillar(1, 0);
                top.Build();
                top.Build();

                var nearestPillars = new Pillar[4]
                {
                    right,
                    bottom,
                    left,
                    top,
                };

                var lastPosition = new Pillar(1, 1);
                lastPosition.Build();

                var actual = _rules.Steppable(nearestPillars, lastPosition);

                Assert.That(actual, Is.Not.Null);
                Assert.That(actual.Length, Is.EqualTo(4));

                Assert.That(actual[0].X, Is.EqualTo(right.X), "right.X");
                Assert.That(actual[0].Y, Is.EqualTo(right.Y), "right.X");

                Assert.That(actual[1].X, Is.EqualTo(bottom.X), "bottom.X");
                Assert.That(actual[1].Y, Is.EqualTo(bottom.Y), "bottom.X");

                Assert.That(actual[2].X, Is.EqualTo(left.X), "left.X");
                Assert.That(actual[2].Y, Is.EqualTo(left.Y), "left.X");

                Assert.That(actual[3].X, Is.EqualTo(top.X), "top.X");
                Assert.That(actual[3].Y, Is.EqualTo(top.Y), "top.Y");

            }
        }

        public class IsNextEachOtherTests
        {
            private readonly BuilderRules _rules = new BuilderRules();



            [Test]
            public void Beneath_Each_Other_Should_Return_True()
            {
                var first = new Pillar(3, 3);
                var second = new Pillar(4, 3);

                var actual = _rules.IsNextEachOther(first, second);
                Assert.That(actual, Is.True);

                actual = _rules.IsNextEachOther(second, first);
                Assert.That(actual, Is.True);
            }

            [Test]
            public void Next_To_Each_Other_Should_Return_True()
            {
                var first = new Pillar(3, 3);
                var second = new Pillar(3, 4);

                var actual = _rules.IsNextEachOther(first, second);
                Assert.That(actual, Is.True);

                actual = _rules.IsNextEachOther(second, first);
                Assert.That(actual, Is.True);
            }

            [Test]
            public void Diagonally_Should_Return_False()
            {
                var first = new Pillar(3, 3);
                var second = new Pillar(4, 4);

                var actual = _rules.IsNextEachOther(first, second);
                Assert.That(actual, Is.False, "↘");

                actual = _rules.IsNextEachOther(second, first);
                Assert.That(actual, Is.False, "↖");

                first = new Pillar(5, 3);

                actual = _rules.IsNextEachOther(first, second);
                Assert.That(actual, Is.False, "↗");

                actual = _rules.IsNextEachOther(second, first);
                Assert.That(actual, Is.False, "↙");
            }

            [Test]
            public void Huge_Distance_Should_Return_False()
            {
                var first = new Pillar(3, 3);
                var second = new Pillar(10, 10);

                var actual = _rules.IsNextEachOther(first, second);
                Assert.That(actual, Is.False);

                actual = _rules.IsNextEachOther(second, first);
                Assert.That(actual, Is.False);
            }
        }
    }
}
