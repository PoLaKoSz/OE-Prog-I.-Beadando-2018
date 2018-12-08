using NUnit.Framework;
using PoLaKoSz.OE._2018_.PyramidGame.Models;

namespace PoLaKoSz.OE._2018_.PyramidGame.Tests.Unit.Models
{
    [TestFixture]
    public class BuilderTests
    {
        [Test]
        public void Initialization_Should_Create_A_Zero_Length_Path()
        {
            var builder = new Builder();

            Assert.That(builder.Path.Length, Is.EqualTo(0));
        }

        [TestCase(3)]
        [TestCase(5)]
        public void Step_Method_Should_Increase_Path_Length_By_(int stepCount)
        {
            var builder = new Builder();

            for (int i = 0; i < stepCount; i++)
            {
                builder.Step(new Pillar(0, 0));
            }

            Assert.That(builder.Path.Length, Is.EqualTo(stepCount));
        }
    }
}
