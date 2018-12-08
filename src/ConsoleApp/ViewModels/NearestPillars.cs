using PoLaKoSz.OE._2018_.PyramidGame.Models;

namespace PoLaKoSz.OE._2018_.PyramidGame.ViewModels
{
    public class NearestPillars
    {
        private readonly Map _map;
        private int _count;

        public Pillar[] Pillars { get; private set; }
        public bool HasAny => (0 < _count);



        public NearestPillars(Map map)
        {
            Pillars = new Pillar[0];
            _map = map;
        }



        /// <summary>
        /// Calculate what direction can the object move.
        /// This is only when the object only had one step.
        /// </summary>
        /// <param name="lastPillar">The last pillar of the <see cref="Builder"/> path.</param>
        public void SetPillars(Pillar lastPillar)
        {
            SetPillars(lastPillar, null);
        }

        /// <summary>
        /// Calculate what direction can the object move when the object
        /// has more than old steps.
        /// </summary>
        /// <param name="lastPillar">The last pillar of the <see cref="Builder"/> path.</param>
        /// <param name="beforeLast">Can be null. This position reached before the lastPillar.</param>
        public void SetPillars(Pillar lastPillar, Pillar beforeLast)
        {
            string logMsg = beforeLast == null ? "null" : $"({beforeLast.X}; {beforeLast.Y})";

            Log.Debug($"SetPillars( ({lastPillar.X}; {lastPillar.Y}), {logMsg}), Height: {lastPillar.Height}", 1);

            _count = 0;

            Pillar[] nearestPillars = GetNearestFields(lastPillar);

            if (beforeLast != null)
            {
                RemoveWrongDirection(nearestPillars, beforeLast);
            }

            ShrinkArray(nearestPillars);

            Log.Debug(-1, $"SetPillars() END");
        }


        private Pillar[] GetNearestFields(Pillar centerField)
        {
            Log.Debug($"GetNearestFields({centerField.X}; {centerField.Y})", 1);

            Pillar[] fields = new Pillar[4];

            int index = 0;

            if (HasRight(centerField))
            {
                SetField(fields, ref index, centerField.X + 1, centerField.Y);
            }

            if (HasBottom(centerField))
            {
                SetField(fields, ref index, centerField.X, centerField.Y + 1);
            }

            if (HasLeft(centerField))
            {
                SetField(fields, ref index, centerField.X - 1, centerField.Y);
            }

            if (HasTop(centerField))
            {
                SetField(fields, ref index, centerField.X, centerField.Y - 1);
            }

            Log.Debug(-1, $"GetNearestFields() END");

            _count = index;

            return fields;
        }

        private void SetField(Pillar[] fields, ref int index,  int x, int y)
        {
            fields[index] = _map.GetField(x, y);

            Log.Debug($"Found: ({fields[index].X}; {fields[index].Y}), Height: {fields[index].Height}");

            index++;
        }

        private bool HasRight(Pillar centerField)
        {
            return -1 <= centerField.X && centerField.X + 1 < _map.Width
                && 0 <= centerField.Y && centerField.Y < _map.Height;
        }

        private bool HasBottom(Pillar centerField)
        {
            return -1 <= centerField.Y && centerField.Y + 1 < _map.Height
                && 0 <= centerField.X && centerField.X < _map.Width;
        }

        private bool HasLeft(Pillar centerField)
        {
            return 0 < centerField.X && centerField.X <= _map.Width
                && 0 <= centerField.Y && centerField.Y < _map.Height;
        }

        private bool HasTop(Pillar centerField)
        {
            return 0 < centerField.Y && centerField.Y <= _map.Height
                && 0 <= centerField.X && centerField.X < _map.Width;
        }

        private void RemoveWrongDirection(Pillar[] fields, Pillar oldPosition)
        {
            Log.Debug($"RemoveWrongDirection(Length: {fields.Length}, ({oldPosition.X}; {oldPosition.Y}))", 1);

            int index = 0;

            for (int i = 0; i < fields.Length; i++)
            {
                Pillar pillar = fields[i];

                if (pillar != null && !pillar.Equals(oldPosition))
                {
                    fields[index] = pillar;

                    Log.Debug($"Stayed: ({fields[index].X}; {fields[index].Y})");

                    index++;
                }
            }

            _count = index;

            Log.Debug(-1, $"RemoveWrongDirection() END");
        }

        private void ShrinkArray(Pillar[] array)
        {
            Log.Debug($"ShrinkArray()", 1);

            Pillars = new Pillar[_count];

            for (int i = 0; i < _count; i++)
            {
                Pillars[i] = array[i];

                Log.Debug($"#{i}: ({Pillars[i].X}; {Pillars[i].Y})");
            }

            Log.Debug(-1, $"ShrinkArray() END");
        }
    }
}
