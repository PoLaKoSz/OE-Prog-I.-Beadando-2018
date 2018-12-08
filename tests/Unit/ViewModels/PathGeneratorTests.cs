using NUnit.Framework;
using PoLaKoSz.OE._2018_.PyramidGame.Models;
using PoLaKoSz.OE._2018_.PyramidGame.ViewModels;

namespace PoLaKoSz.OE._2018_.PyramidGame.Tests.Unit.ViewModels
{
    [TestFixtureSource("testInputs")]
    class PathGeneratorTests
    {
        private static readonly TestInput[] testInputs;

        private readonly Map _map;
        private readonly Path[] _paths;
        private readonly int _longestPathIndex;
        private readonly BuilderRules _rules;



        static PathGeneratorTests()
        {
            testInputs = new TestInput[]
            {
                new TestInput().SmallMap(),
                new TestInput().MediumMap(),
                new TestInput().BigMap(),
            };
        }

        public PathGeneratorTests(TestInput testInput)
        {
            _map = testInput.Map;
            _paths = testInput.Paths;
            _rules = testInput.Rules;
            _longestPathIndex = testInput.LongestPathIndex;
        }



        [Test]
        public void Longest_Method()
        {
            var generator = new PathGenerator(_map, _rules);
            Path actualPath = generator.Longest();

            Assert.That(actualPath.Length, Is.EqualTo(_paths[_longestPathIndex].Length), "Longest path.Length");

            Assert.That(generator._rowCount, Is.EqualTo(_paths.Length), "Found paths.Length");

            for (int i = 0; i < actualPath.Length; i++)
            {
                Pillar actualPosition = actualPath.GetByIndex(i);
                Pillar expectedPosition = _paths[_longestPathIndex].GetByIndex(i);

                if (!actualPosition.Equals(expectedPosition))
                {
                    Assert.Fail($"Position at index {i} does not match!" +
                        $"{actualPosition.X} != {expectedPosition.X} || " +
                        $"{actualPosition.Y} != {expectedPosition.Y} ||" +
                        $"{actualPosition.Height} != {expectedPosition.Height}");
                }
            }
        }
    }


    class TestInput
    {
        public Map Map { get; private set; }
        public Path[] Paths { get; private set; }

        public int LongestPathIndex { get; private set; }

        public BuilderRules Rules { get; }



        public TestInput()
        {
            Map = new Map(1);
            Paths = new Path[0];

            // This is kind of hard-coded this will be replaced with Interface
            Rules = new BuilderRules();
        }



        public TestInput SmallMap()
        {
            Map = new Map(1);

            Paths = new Path[]
            {
                new Path(new Pillar(0, 0))
            };

            LongestPathIndex = 0;

            return this;
        }

        public TestInput MediumMap()
        {
            /*
             *
             * y
             * ^
             * |
             * |
             *
             *
             * 2   | 1 | 1 | 1 | 1 |
             * 1   | 1 | 4 | 5 | 1 |
             * 0   | 2 | 3 | 1 | 1 |
             *
             *       0   1   2   3      ---> x
             */
            var map = new Pillar[3, 4]
            {
                { new Pillar(0, 0, 2), new Pillar(1, 0, 3), new Pillar(2, 0),    new Pillar(3, 0) },
                { new Pillar(0, 1),    new Pillar(1, 1, 4), new Pillar(2, 1, 5), new Pillar(3, 1) },
                { new Pillar(0, 2),    new Pillar(1, 2),    new Pillar(2, 2),    new Pillar(3, 2) },
            };

            Map = new Map(map);
            Paths = new Path[]
            {
                new Path(new Pillar(0, 2)),
                new Path(new Pillar(1, 2)),
                new Path(new Pillar(2, 2)),
                new Path(new Pillar(3, 2)),

                new Path(new Pillar(3, 1)),
                new Path(new Pillar(3, 0)),

                new Path(new Pillar(2, 0)),
                new Path(
                    Map.GetField(1, 0),
                    Map.GetField(1, 1),
                    Map.GetField(2, 1)),
                new Path(
                    Map.GetField(0, 0),
                    Map.GetField(1, 0),
                    Map.GetField(1, 1),
                    Map.GetField(2, 1)),
                new Path(
                    Map.GetField(0, 1),
                    Map.GetField(0, 0),
                    Map.GetField(1, 0),
                    Map.GetField(1, 1),
                    Map.GetField(2, 1)),
            };

            LongestPathIndex = 9;

            return this;
        }

        public TestInput BigMap()
        {

            /*
             *
             * y
             * ^
             * |
             * |
             *
             *
             * 3   | 1 | 1 | 1 | 1 | 1 | 1 |
             * 2   | 1 | 3 | 4 | 5 | 6 | 1 |
             * 1   | 3 | 2 | 3 | 4 | 5 | 4 |
             * 0   | 1 | 1 | 4 | 1 | 1 | 1 |
             *
             *       0   1   2   3   4   5   ---> x
             */
            var map = new Pillar[4, 6]
            {
                { new Pillar(0, 0),    new Pillar(1, 0),    new Pillar(2, 0, 4), new Pillar(3, 0),    new Pillar(4, 0),    new Pillar(5, 0) },
                { new Pillar(0, 1, 3), new Pillar(1, 1, 2), new Pillar(2, 1, 3), new Pillar(3, 1, 4), new Pillar(4, 1, 5), new Pillar(5, 1, 4) },
                { new Pillar(0, 2),    new Pillar(1, 2, 3), new Pillar(2, 2, 4), new Pillar(3, 2, 5), new Pillar(4, 2, 6), new Pillar(5, 2) },
                { new Pillar(0, 3),    new Pillar(1, 3),    new Pillar(2, 3),    new Pillar(3, 3),    new Pillar(4, 3),    new Pillar(5, 3) },
            };

            Map = new Map(map);
            Paths = new Path[]
            {
                new Path(new Pillar(0, 3)),
                new Path(new Pillar(1, 3)),
                new Path(new Pillar(2, 3)),
                new Path(new Pillar(3, 3)),
                new Path(new Pillar(4, 3)),
                new Path(new Pillar(5, 3)),

                new Path(new Pillar(5, 2)),
                new Path(
                    Map.GetField(5, 1),
                    Map.GetField(4, 1),
                    Map.GetField(4, 2)),
                new Path(new Pillar(5, 0)),

                new Path(new Pillar(4, 0)),
                new Path(new Pillar(3, 0)),
                new Path(new Pillar(2, 0)),
                new Path(
                    Map.GetField(1, 0),
                    Map.GetField(1, 1),
                    Map.GetField(2, 1),
                    Map.GetField(3, 1),
                    Map.GetField(4, 1),
                    Map.GetField(4, 2)),
                new Path(
                    Map.GetField(1, 0),
                    Map.GetField(1, 1),
                    Map.GetField(2, 1),
                    Map.GetField(3, 1),
                    Map.GetField(3, 2),
                    Map.GetField(4, 2)),
                new Path(
                    Map.GetField(1, 0),
                    Map.GetField(1, 1),
                    Map.GetField(2, 1),
                    Map.GetField(2, 2),
                    Map.GetField(3, 2),
                    Map.GetField(4, 2)),
                new Path(
                    Map.GetField(1, 0),
                    Map.GetField(1, 1),
                    Map.GetField(1, 2),
                    Map.GetField(2, 2),
                    Map.GetField(3, 2),
                    Map.GetField(4, 2)),
                new Path(
                    Map.GetField(1, 0),
                    Map.GetField(1, 1),
                    Map.GetField(0, 1)),
                new Path(new Pillar(0, 0)),

                new Path(new Pillar(0, 1)),
                new Path(new Pillar(0, 2)),
            };

            LongestPathIndex = 12;

            return this;
        }
    }
}
