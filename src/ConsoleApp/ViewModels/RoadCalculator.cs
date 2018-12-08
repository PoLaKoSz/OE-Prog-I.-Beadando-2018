using PoLaKoSz.OE._2018_.PyramidGame.Models;

namespace PoLaKoSz.OE._2018_.PyramidGame.ViewModels
{
    public class RoadCalculator
    {
        private readonly Pillar[] _directions;

        public bool HasRoad => false;



        public RoadCalculator()
        {
            _directions = new Pillar[3];
        }



        /// <summary>
        /// A pálya négy oldalához tartozó összes KoKockához generál utat
        /// </summary>
	    public void UtszakaszokGeneralasa()
        {

        }

        /// <summary>
        /// A megadott KoKockához generál utakat
        ///     Utszakasz->Utszakasz->Utszakasz
        /// </summary>
        public void UtszakaszGeneralasa(Pillar kezdoPont)
        {

        }

        public int LeghosszabbUtszakasz()
        {
            return 0;
        }

        /// <summary>
        /// Törli a korábban generált utakat
        ///     (optimálisabb lenne a már nem érvényes utakat törölni)
        /// </summary>
	    public void Torol()
        {

        }

        public void KornyezoMezok(Pillar ut)
        {

        }
    }
}
