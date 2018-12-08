using PoLaKoSz.OE._2018_.PyramidGame.Models;
using System.IO;

namespace PoLaKoSz.OE._2018_.PyramidGame.DataAccessLayer
{
    public class FileAccess
    {
        private readonly char _separator;
        private readonly string _inputFilePath;



        public FileAccess()
        {
            _separator = ' ';
            _inputFilePath = "PIRAMIS.BE";
        }



        public void Write(Map map, Pillar startingPosition)
        {
            string filePath = "PIRAMIS.KI";

            File.Delete(filePath);

            File.AppendAllText(filePath, $"{map.Width}\n");

            File.AppendAllText(filePath, $"{startingPosition.X} {startingPosition.Y}\n");
        }

        public Map Read()
        {
            string[] lines = File.ReadAllLines(_inputFilePath);

            int size = int.Parse(lines[0]);

            Pillar[,] map = new Pillar[size, size];

            for (int y = 0; y < map.GetLength(0); y++)
            {
                ParseLine(y, lines[y + 1], map);
            }

            return new Map(map);
        }

        public bool CanRead()
        {
            return File.Exists(_inputFilePath);
        }


        private void ParseLine(int lineIndex, string line, Pillar[,] map)
        {
            string[] pillarHeights = line.Split(_separator);

            for (int x = 0; x < map.GetLength(1); x++)
            {
                map[lineIndex, x] = new Pillar(x, lineIndex, int.Parse(pillarHeights[x]));
            }
        }
    }
}
