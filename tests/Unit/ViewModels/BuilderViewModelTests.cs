using NUnit.Framework;
using PoLaKoSz.OE._2018_.PyramidGame.Models;
using PoLaKoSz.OE._2018_.PyramidGame.ViewModels;

namespace PoLaKoSz.OE._2018_.PyramidGame.Tests.Unit.ViewModels
{
    class BuilderViewModelTests
    {
        private readonly Map _map;
        private readonly BuilderViewModel _viewModel;



        public BuilderViewModelTests()
        {
            var map = new Pillar[4, 4]
            {
                { new Pillar(0, 0, 100), new Pillar(1, 0, 100), new Pillar(2, 0, 1), new Pillar(3, 0, 100) },
                { new Pillar(0, 1, 100), new Pillar(1, 1, 100), new Pillar(2, 1, 2), new Pillar(3, 1, 100) },
                { new Pillar(0, 2, 100), new Pillar(1, 2, 100), new Pillar(2, 2, 3), new Pillar(3, 2, 100) },
                { new Pillar(0, 3, 100), new Pillar(1, 3, 100), new Pillar(2, 3, 4), new Pillar(3, 3, 100) },
            };
            _map = new Map(map);
            _viewModel = new BuilderViewModel(_map);
        }



        [Test]
        public void Bind_Method()
        {
            var actual = _viewModel.Bind();

            Assert.IsTrue(actual);
        }
    }
}
