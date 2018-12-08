using System;

namespace PoLaKoSz.OE._2018_.PyramidGame.Models
{
    public class Builder
    {
        public Path Path { get; protected set; }



        public Builder()
        {
            Path = new Path();
        }



	    public void Step(Pillar position)
        {
            Path.Increase(position);
        }
    }
}
