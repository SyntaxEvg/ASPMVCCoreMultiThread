using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    internal class Sample04
    {
        static void Main(string[] args)
        {
            var logFileSource = new LogFileSource("С:/logs/sample.log");
            foreach (LogEntry log in logFileSource)
            {
                Console.WriteLine(log);
            }

            Console.ReadKey();
        }
    }

    public class LogFileSource : IEnumerable<LogEntry>
    {
        private readonly string _fileName;

        public LogFileSource(string fileName)
        {
            _fileName = fileName;
        }

        public IEnumerator<LogEntry> GetEnumerator()
        {
            foreach (var line in  File.ReadAllLines(_fileName))
            {
                yield return LogEntry.Parse(line);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
