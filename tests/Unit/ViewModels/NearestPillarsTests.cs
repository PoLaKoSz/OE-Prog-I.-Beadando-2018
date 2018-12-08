using NUnit.Framework;
using PoLaKoSz.OE._2018_.PyramidGame.Models;
using PoLaKoSz.OE._2018_.PyramidGame.ViewModels;

namespace PoLaKoSz.OE._2018_.PyramidGame.Tests.Unit.ViewModels
{
    [TestFixture]
    public class NearestPillarsTests
    {
        public class ConstructorTests
        {
            private NearestPillars _nearestPillars;



            [OneTimeSetUp]
            public void Init()
            {
                var map = new Map(new Pillar[0, 0]);
                _nearestPillars = new NearestPillars(map);
            }



            [Test]
            public void Pillars_Array_Should_Not_Be_Null()
            {
                Assert.That(_nearestPillars.Pillars, Is.Not.Null);
            }

            [Test]
            public void Pillars_Array_Length_Should_Be_Zero()
            {
                Assert.That(_nearestPillars.Pillars.Length, Is.EqualTo(0));
            }

            [Test]
            public void HasPillars_Should_Be_False()
            {
                Assert.That(_nearestPillars.HasAny, Is.False);
            }
        }

        public class SetPillarsTests
        {
            [Test]
            public void Test_1x1_Board()
            {
                /*
                 * P = Pillar (some game element path's last position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0     -> x
                 *   -2
                 *   -1
                 *    0   P  | 0 |
                */

                var map = new Map(new Pillar[1, 1]
                {
                    { new Pillar(0, 0) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(0, -1));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(1), "Pillars.Length");

                Pillar onlyDirection = nearesPillars.Pillars[0];

                Assert.That(onlyDirection.X, Is.EqualTo(0), "onlyDirection.X");
                Assert.That(onlyDirection.Y, Is.EqualTo(0), "onlyDirection.Y");
            }

            [Test]
            public void Test_3x3_Board_Center()
            {
                /*
                 * P = Pillar (some game element path's last position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1
                 *    0      | 0 | 0 | 0 |
                 *    1      | 0 | P | 0 |
                 *    2      | 0 | 0 | 0 |
                */

                var map = new Map(new Pillar[3, 3]
                {
                    { new Pillar(x: 0, y: 0), new Pillar(1, 0), new Pillar(2, 0) },
                    { new Pillar(0, 1), new Pillar(1, 1), new Pillar(2, 1) },
                    { new Pillar(0, 2), new Pillar(1, 2), new Pillar(2, 2) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(1, 1));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(4), "Pillars.Length");

                ChechAtIndex(index: 0, nearesPillars: nearesPillars, x: 2, y: 1);
                ChechAtIndex(index: 1, nearesPillars: nearesPillars, x: 1, y: 2);
                ChechAtIndex(index: 2, nearesPillars: nearesPillars, x: 0, y: 1);
                ChechAtIndex(index: 3, nearesPillars: nearesPillars, x: 1, y: 0);
            }

            [Test]
            public void Test_3x3_Board_Left_Side()
            {
                /*
                 * P = Pillar (some game element path's last position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1
                 *    0      | 0 | 0 | 0 |
                 *    1      | P | 0 | 0 |
                 *    2      | 0 | 0 | 0 |
                */

                var map = new Map(new Pillar[3, 3]
                {
                    { new Pillar(x: 0, y: 0), new Pillar(1, 0), new Pillar(2, 0) },
                    { new Pillar(0, 1), new Pillar(1, 1), new Pillar(2, 1) },
                    { new Pillar(0, 2), new Pillar(1, 2), new Pillar(2, 2) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(0, 1));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(3), "Pillars.Length");

                ChechAtIndex(index: 0, nearesPillars: nearesPillars, x: 1, y: 1);
                ChechAtIndex(index: 1, nearesPillars: nearesPillars, x: 0, y: 2);
                ChechAtIndex(index: 2, nearesPillars: nearesPillars, x: 0, y: 0);
            }

            [Test]
            public void Test_3x3_Board_Top_Side()
            {
                /*
                 * P = Pillar (some game element path's last position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1
                 *    0      | 0 | P | 0 |
                 *    1      | 0 | 0 | 0 |
                 *    2      | 0 | 0 | 0 |
                */

                var map = new Map(new Pillar[3, 3]
                {
                    { new Pillar(x: 0, y: 0), new Pillar(1, 0), new Pillar(2, 0) },
                    { new Pillar(0, 1), new Pillar(1, 1), new Pillar(2, 1) },
                    { new Pillar(0, 2), new Pillar(1, 2), new Pillar(2, 2) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(1, 0));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(3), "Pillars.Length");

                ChechAtIndex(index: 0, nearesPillars: nearesPillars, x: 2, y: 0);
                ChechAtIndex(index: 1, nearesPillars: nearesPillars, x: 1, y: 1);
                ChechAtIndex(index: 2, nearesPillars: nearesPillars, x: 0, y: 0);
            }

            [Test]
            public void Test_3x3_Board_Right_Side()
            {
                /*
                 * P = Pillar (some game element path's last position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1
                 *    0      | 0 | 0 | 0 |
                 *    1      | 0 | 0 | P |
                 *    2      | 0 | 0 | 0 |
                */

                var map = new Map(new Pillar[3, 3]
                {
                    { new Pillar(x: 0, y: 0), new Pillar(1, 0), new Pillar(2, 0) },
                    { new Pillar(0, 1), new Pillar(1, 1), new Pillar(2, 1) },
                    { new Pillar(0, 2), new Pillar(1, 2), new Pillar(2, 2) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(2, 1));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(3), "Pillars.Length");

                ChechAtIndex(index: 0, nearesPillars: nearesPillars, x: 2, y: 2);
                ChechAtIndex(index: 1, nearesPillars: nearesPillars, x: 1, y: 1);
                ChechAtIndex(index: 2, nearesPillars: nearesPillars, x: 2, y: 0);
            }

            [Test]
            public void Test_3x3_Board_Right_Top_Corner()
            {
                /*
                 * P = Pillar (some game element path's last position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1
                 *    0      | 0 | 0 | P |
                 *    1      | 0 | 0 | 0 |
                 *    2      | 0 | 0 | 0 |
                */

                var map = new Map(new Pillar[3, 3]
                {
                    { new Pillar(x: 0, y: 0), new Pillar(1, 0), new Pillar(2, 0) },
                    { new Pillar(0, 1), new Pillar(1, 1), new Pillar(2, 1) },
                    { new Pillar(0, 2), new Pillar(1, 2), new Pillar(2, 2) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(2, 0));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(2), "Pillars.Length");

                ChechAtIndex(index: 0, nearesPillars: nearesPillars, x: 2, y: 1);
                ChechAtIndex(index: 1, nearesPillars: nearesPillars, x: 1, y: 0);
            }

            [Test]
            public void Test_3x3_Board_Right_Bottom_Corner()
            {
                /*
                 * P = Pillar (some game element path's last position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1
                 *    0      | 0 | 0 | 0 |
                 *    1      | 0 | 0 | 0 |
                 *    2      | 0 | 0 | P |
                */

                var map = new Map(new Pillar[3, 3]
                {
                    { new Pillar(x: 0, y: 0), new Pillar(1, 0), new Pillar(2, 0) },
                    { new Pillar(0, 1), new Pillar(1, 1), new Pillar(2, 1) },
                    { new Pillar(0, 2), new Pillar(1, 2), new Pillar(2, 2) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(2, 2));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(2), "Pillars.Length");

                ChechAtIndex(index: 0, nearesPillars: nearesPillars, x: 1, y: 2);
                ChechAtIndex(index: 1, nearesPillars: nearesPillars, x: 2, y: 1);
            }

            [Test]
            public void Test_3x3_Board_Left_Bottom_Corner()
            {
                /*
                 * P = Pillar (some game element path's last position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1
                 *    0      | 0 | 0 | 0 |
                 *    1      | 0 | 0 | 0 |
                 *    2      | P | 0 | 0 |
                */

                var map = new Map(new Pillar[3, 3]
                {
                    { new Pillar(x: 0, y: 0), new Pillar(1, 0), new Pillar(2, 0) },
                    { new Pillar(0, 1), new Pillar(1, 1), new Pillar(2, 1) },
                    { new Pillar(0, 2), new Pillar(1, 2), new Pillar(2, 2) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(0, 2));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(2), "Pillars.Length");

                ChechAtIndex(index: 0, nearesPillars: nearesPillars, x: 1, y: 2);
                ChechAtIndex(index: 1, nearesPillars: nearesPillars, x: 0, y: 1);
            }

            [Test]
            public void Test_3x3_Board_Left_Top_Corner()
            {
                /*
                 * P = Pillar (some game element path's last position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1
                 *    0      | P | 0 | 0 |
                 *    1      | 0 | 0 | 0 |
                 *    2      | 0 | 0 | 0 |
                */

                var map = new Map(new Pillar[3, 3]
                {
                    { new Pillar(x: 0, y: 0), new Pillar(1, 0), new Pillar(2, 0) },
                    { new Pillar(0, 1), new Pillar(1, 1), new Pillar(2, 1) },
                    { new Pillar(0, 2), new Pillar(1, 2), new Pillar(2, 2) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(0, 0));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(2), "Pillars.Length");

                ChechAtIndex(index: 0, nearesPillars: nearesPillars, x: 1, y: 0);
                ChechAtIndex(index: 1, nearesPillars: nearesPillars, x: 0, y: 1);
            }

            [Test]
            public void Out_Top()
            {
                /*
                 * P = position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1        P
                 *    0      | 0 |
                */

                var map = new Map(new Pillar[1, 1]
                {
                    { new Pillar(x: 0, y: 0) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(0, -1));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(1), "Pillars.Length");

                ChechAtIndex(0, nearesPillars, 0, 0);
            }

            [Test]
            public void Out_Top_Right_Corner()
            {
                /*
                 * P = position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1            P
                 *    0      | 0 |
                */

                var map = new Map(new Pillar[1, 1]
                {
                    { new Pillar(x: 0, y: 0) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(1, -1));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(0), "Pillars.Length");
            }

            [Test]
            public void Out_Right()
            {
                /*
                 * P = position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1
                 *    0      | 0 | P
                */

                var map = new Map(new Pillar[1, 1]
                {
                    { new Pillar(x: 0, y: 0) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(1, 0));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(1), "Pillars.Length");

                ChechAtIndex(0, nearesPillars, 0, 0);
            }

            [Test]
            public void Out_Bottom_Right_Corner()
            {
                /*
                 * P = position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1
                 *    0      | 0 |
                 *    1            P
                */

                var map = new Map(new Pillar[1, 1]
                {
                    { new Pillar(x: 0, y: 0) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(1, 1));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(0), "Pillars.Length");
            }

            [Test]
            public void Out_Bottom()
            {
                /*
                 * P = position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1
                 *    0      | 0 |
                 *    1        P
                */

                var map = new Map(new Pillar[1, 1]
                {
                    { new Pillar(x: 0, y: 0) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(0, 1));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(1), "Pillars.Length");

                ChechAtIndex(0, nearesPillars, 0, 0);
            }

            [Test]
            public void Out_Bottom_Left_Corner()
            {
                /*
                 * P = position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1
                 *    0      | 0 |
                 *    1    P
                */

                var map = new Map(new Pillar[1, 1]
                {
                    { new Pillar(x: 0, y: 0) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(-1, 1));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(0), "Pillars.Length");
            }

            [Test]
            public void Out_Left()
            {
                /*
                 * P = position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1
                 *    0    P | 0 |
                */

                var map = new Map(new Pillar[1, 1]
                {
                    { new Pillar(x: 0, y: 0) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(-1, 0));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(1), "Pillars.Length");

                ChechAtIndex(0, nearesPillars, 0, 0);
            }

            [Test]
            public void Out_Top_Left_Corner()
            {
                /*
                 * P = position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1    P
                 *    0      | 0 |
                */

                var map = new Map(new Pillar[1, 1]
                {
                    { new Pillar(x: 0, y: 0) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(-1, -1));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(0), "Pillars.Length");
            }

            [Test]
            public void Out_Far_Left()
            {
                /*
                 * P = position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1
                 *    0      | 0 |     P
                */

                var map = new Map(new Pillar[1, 1]
                {
                    { new Pillar(x: 0, y: 0) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(2, 0));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(0), "Pillars.Length");
            }

            [Test]
            public void Out_Far_Bottom()
            {
                /*
                 * P = position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1   0   1   2   -> x
                 *   -2
                 *   -1
                 *    0      | 0 |
                 *    1
                 *    2        P
                */

                var map = new Map(new Pillar[1, 1]
                {
                    { new Pillar(x: 0, y: 0) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(0, 2));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(0), "Pillars.Length");
            }

            [Test]
            public void Out_Far_Right()
            {
                /*
                 * P = position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -2   -1   0   1   2   -> x
                 *   -2
                 *   -1
                 *    0    P      | 0 |
                */

                var map = new Map(new Pillar[1, 1]
                {
                    { new Pillar(x: 0, y: 0) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(-2, 0));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(0), "Pillars.Length");
            }

            [Test]
            public void Out_Far_Top()
            {
                /*
                 * P = position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -2   -1   0   1   2   -> x
                 *   -2             P
                 *   -1
                 *    0           | 0 |
                */

                var map = new Map(new Pillar[1, 1]
                {
                    { new Pillar(x: 0, y: 0) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(0, -2));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(0), "Pillars.Length");
            }

            [Test]
            public void Bottom_With_BeforeLastPosition()
            {
                /*
                 * P = Pillar (some game element path's last position
                 *
                 *    y
                 *    ^
                 *    |
                 *        -1    0     1    2    3       -> x
                 *   -2
                 *   -1
                 *    0      | 100 | 100 | 1 | 100 |
                 *    1      | 100 | 100 | 2 | 100 |
                 *    2      | 100 | 100 | 3 | 100 |
                 *    3      | 100 | 100 | 4 | 100 |
                 *    4
                */

                var map = new Map(new Pillar[4, 4]
                {
                    { new Pillar(x: 0, y: 0, height: 100), new Pillar(1, 0, 100), new Pillar(2, 0), new Pillar(3, 0, 100) },
                    { new Pillar(0, 1, 100), new Pillar(1, 1, 100), new Pillar(2, 1), new Pillar(3, 1, 100) },
                    { new Pillar(0, 2, 100), new Pillar(1, 2, 100), new Pillar(2, 2), new Pillar(3, 2, 100) },
                    { new Pillar(0, 3, 100), new Pillar(1, 3, 100), new Pillar(2, 3), new Pillar(3, 3, 100) }
                });
                var nearesPillars = new NearestPillars(map);

                nearesPillars.SetPillars(new Pillar(2, 3), new Pillar(2, 2));

                Assert.That(nearesPillars.Pillars, Is.Not.Null, "Pillars");
                Assert.That(nearesPillars.Pillars.Length, Is.EqualTo(2), "Pillars.Length");

                ChechAtIndex(index: 0, nearesPillars: nearesPillars, x: 3, y: 3);
                ChechAtIndex(index: 1, nearesPillars: nearesPillars, x: 1, y: 3);
            }


            private void ChechAtIndex(int index, NearestPillars nearesPillars, int x, int y)
            {
                Assert.That(nearesPillars.Pillars[index].X, Is.EqualTo(x), "Pillar[" + index + "].X");
                Assert.That(nearesPillars.Pillars[index].Y, Is.EqualTo(y), "Pillar[" + index + "].Y");
            }
        }
    }
}
