using System;
using System.IO;

namespace PoLaKoSz.OE._2018_.PyramidGame
{
    public static class Log
    {
        private static int _level = 0;
        private static int _intentLevel;
        private static readonly string _filePath;

        private static string _logMessages;



        static Log()
        {
            SetForDebug();

            _logMessages = "";

            string fullPath = System.Reflection.Assembly.GetAssembly(typeof(Log)).Location;

            string theDirectory = Path.GetDirectoryName(fullPath);

            _filePath = Path.Combine(theDirectory, "log.txt");

            if (File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }
        }



        public static void SetForDebug()
        {
            _level = 0;
        }

        public static void SetForInfo()
        {
            _level = 2;
        }

        public static void Disable()
        {
            _level = 100;
        }

        public static void Debug(string message)
        {
            Debug(message, 0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="increaseIntent">-1 = decrease
        /// 0 = not change
        /// 1 = increase</param>
        public static void Debug(string message, int nextIntentLength)
        {
            if (_level <= 0)
            {
                Write(message);

                _intentLevel += nextIntentLength;
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="increaseIntent">-1 = decrease
        /// 0 = not change
        /// 1 = increase</param>
        public static void Debug(int nextIntentLength, string message)
        {
            if (_level <= 0)
            {
                _intentLevel += nextIntentLength;

                Write(message);

            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="message"></param>
        /// <param name="increaseIntent">-1 = decrease
        /// 0 = not change
        /// 1 = increase</param>
        public static void Debug(int nextIntentLength, string message, int intentLengthAfterMessage)
        {
            if (_level <= 0)
            {
                _intentLevel += nextIntentLength;

                Write(message);

                _intentLevel += intentLengthAfterMessage;
            }
        }

        public static void Info(string message)
        {
            if (_level <= 2)
            {
                Write(message);
            }
        }

        public static void Rotate()
        {
            File.AppendAllText(_filePath, _logMessages);

            _logMessages = "";
        }

        private static void Write(string message)
        {
            string debugInfo = "";

            for (int i = 0; i < _intentLevel; i++)
            {
                debugInfo += "\t";
            }

            string msg = $"{DateTime.Now.ToString("HH:mm:ss:fff")}\t{debugInfo}{message}";

            _logMessages += msg + "\n";

            if (99999 < _logMessages.Length)
            {
                Rotate();
            }

#if DEBUG
            System.Diagnostics.Debug.WriteLine(msg);
#endif
            Console.WriteLine(msg);
        }
    }
}
