using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    internal class Sample03
    {
        static void MyLogFileReader(string text)
        {
            Console.WriteLine(text);
        }

        static void Main(string[] args)
        {
            using MyLogFileReader myLogFileReader = new MyLogFileReader("C:/logs/sample.log", MyLogFileReader);

            Console.ReadKey();
        }
    }

    public class MyLogFileReader : IDisposable
    {
        private readonly Action<string> _logEntrySubscriber;
        private readonly string _logFileName;
        private readonly StreamReader _streamReader;
        private readonly FileStream _fileStream;
        private readonly Timer _timer;
        private readonly static TimeSpan CheckFileInterval = TimeSpan.FromSeconds(5);


        public MyLogFileReader(string logFileName, Action<string> logEntrySubscriber)
        {
            
            if (!File.Exists(logFileName))
                throw new FileNotFoundException();

            _logFileName = logFileName;
            _logEntrySubscriber = logEntrySubscriber;


            _fileStream = new FileStream(_logFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            _streamReader = new StreamReader(_fileStream);

            _timer = new Timer(f => CheckFile(), null, CheckFileInterval, CheckFileInterval);
        }

        private void CheckFile()
        {
            foreach(var logEntry in ReadNewLogEntries())
            {
                _logEntrySubscriber(logEntry);
            }
        }

        private IEnumerable<string> ReadNewLogEntries()
        {
            while (!_streamReader.EndOfStream)
            {
               yield return _streamReader.ReadLine()!;
            }
        }

        public void Dispose()
        {
            _timer.Dispose();
            _fileStream.Dispose();
            _streamReader.Dispose();

        }
    }
}
