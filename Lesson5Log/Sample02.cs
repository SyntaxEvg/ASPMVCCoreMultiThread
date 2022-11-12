using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    public class Sample02
    {
        static void Main(string[] args)
        {
            var reader = new BaseReader();
            var logs = reader.ReadLogEntry();

            logs = reader.ReadLogEntry();


            logs = reader.ReadLogEntry();

            Console.ReadKey();
        }
    }

    public class A
    {
        public A(string str)
        {

        }
    }

    public abstract class LogReader
    {
        private int _currentPosition;
        public IEnumerable<LogEntry> ReadLogEntry()
        {
             return ReadEntries(ref _currentPosition).Select(ParseLogEntry);
        }

        protected abstract IEnumerable<string> ReadEntries(ref int position);

        protected abstract LogEntry ParseLogEntry(string stringEntry);
    }

    public class BaseReader : LogReader
    {
        protected override LogEntry ParseLogEntry(string stringEntry)
        {
            
            return new LogEntry();
        }

        protected override IEnumerable<string> ReadEntries(ref int position)
        {
            List<string> list = new List<string>();
            list.Add($"Line {position++}");
            list.Add($"Line {position++}");
            list.Add($"Line {position++}");
            list.Add($"Line {position++}");
            return list;
        }
    }

}
