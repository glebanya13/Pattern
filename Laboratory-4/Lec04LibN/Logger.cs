using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Lec04LibN
{
    public partial class Logger : ILogger
    {
        private static Logger _instance;
        private string LogFileName; // имя файла журнала
        private string currName = "";
        private Logger()
        {
            LogFileName = Path.Combine(
                @"D:\Labs\Pattern",
                $"Log_{DateTime.Now:yyyyMMdd_HHmmss}.txt"
            );
        }
        private StreamWriter _writer;
        public void log(                        // вывод сообщения в текущем пространстве
                                           string message = ""    // текст
                                          )
        {
            if (_writer == null)
            {
                Console.WriteLine("logger isn't started");
                return;
            }
            if (!string.IsNullOrEmpty(message))
            {
                string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}";
                _writer.WriteLine(logEntry);
                Console.WriteLine(logEntry);
            }
        }
        public static ILogger create()
        {
            if(_instance is null)
            {
                _instance = new Logger();
            }
            return _instance;
        }
        public void start(                      // создать/подключиться к Logger
                                            string title          // старт пространства имен
                                            )
        {
                try
                {
                if (_writer == null)
                {
                    _writer = new StreamWriter(LogFileName, true);
                }
                currName = string.IsNullOrEmpty(currName) ? title : $"{currName}:{title}";
                _writer.WriteLine($"start logging: {currName}");
                Console.WriteLine($"logger started: {currName}");
                return;
                }
                catch (IOException ex)
                {
                    Console.Write("");
                }
        }              // имя пространства
        public void stop()
        {
            if (_writer != null)
            {
                _writer.WriteLine($"stop {currName}");
                Console.WriteLine($"logger stopped {currName}.");
                int lastIndex = currName.LastIndexOf(':');
                currName = lastIndex > 0 ? currName.Substring(0, lastIndex) : "";
                
                _writer.Close();
                _writer = null;
            }
            else
            {
                Console.WriteLine("logger is not started.");
            }
        }                // завершить пространство имен
    }
}

