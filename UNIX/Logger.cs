using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UNIX_Log
{
    public class Logger
    {
        public static string _FILEname = "UNIX.log"; // имя файла

        public enum Level
        {
            INFO,
            WARNING,
            ERROR,
            MESSAGE,
            SPACE
        }

        public static void ClearLog()
        {
            File.Delete(_FILEname);
        }

        public static void SendLog(Level level, string message)
        {
            switch (level)
            {
                case Level.INFO:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("UNIX | INFO: " + message);
                    using (StreamWriter fileStream = File.Exists(_FILEname) ? File.AppendText(_FILEname) : File.CreateText(_FILEname))
                    {
                        fileStream.WriteLine("UNIX | INFO: " + message);
                    }

                    break;

                case Level.WARNING:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("UNIX | WARNING: " + message);

                    using (StreamWriter fileStream = File.Exists(_FILEname) ? File.AppendText(_FILEname) : File.CreateText(_FILEname))
                    {
                        fileStream.WriteLine("UNIX | WARNING: " + message);
                    }
                    break;

                case Level.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("UNIX | ERROR: " + message);

                    using (StreamWriter fileStream = File.Exists(_FILEname) ? File.AppendText(_FILEname) : File.CreateText(_FILEname))
                    {
                        fileStream.WriteLine("UNIX | ERROR: " + message);
                    }
                    break;

                case Level.MESSAGE:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("UNIX | MESSAGE: " + message);

                    using (StreamWriter fileStream = File.Exists(_FILEname) ? File.AppendText(_FILEname) : File.CreateText(_FILEname))
                    {
                        fileStream.WriteLine("UNIX | MESSAGE: " + message);
                    }
                    break;

                case Level.SPACE:
                    Console.WriteLine("");

                    using (StreamWriter fileStream = File.Exists(_FILEname) ? File.AppendText(_FILEname) : File.CreateText(_FILEname))
                    {
                        fileStream.WriteLine("");
                    }
                    break;
            }

            Console.ResetColor();
        }
    }
}
