namespace Lesson5
{
    internal class Sample01
    {
        static void Main(string[] args)
        {
            LogProcessor logProcessor3 = new LogProcessor(() => new WindowsEventLogReader().Read());
            logProcessor3.ProcessLogs();

            Console.ReadKey();
        }
    }

    public class LogEntry
    {
        private string line;

        public LogEntry(string line)
        {
            this.line = line;
        }

        public LogEntry()
        {
        }

        public static LogEntry Parse(string line)
        {
            return new LogEntry(line);
        }

        public override string ToString()
        {
            return line;
        }

    }

    public interface ILogReader
    {
        public List<LogEntry> Read();
    }

    public interface ILogWriter
    {
        public void Write(string message);

        public void WriteError (Exception exception);

    }

    public class LogFileReader : ILogReader, ILogWriter
    {
        public List<LogEntry> Read()
        {
            throw new NotImplementedException();
        }

        public void Write(string message)
        {
            throw new NotImplementedException();
        }

        public void WriteError(Exception exception)
        {
            throw new NotImplementedException();
        }
    }

    public class WindowsEventLogReader : ILogReader, ILogWriter
    {
        public List<LogEntry> Read()
        {
            var list = new List<LogEntry>();
            list.Add(new LogEntry());
            list.Add(new LogEntry());
            list.Add(new LogEntry());
            list.Add(new LogEntry());
            list.Add(new LogEntry());
            list.Add(new LogEntry());
            list.Add(new LogEntry());
            list.Add(new LogEntry());
            return list;

        }

        public void Write(string message)
        {
            throw new NotImplementedException();
        }

        public void WriteError(Exception exception)
        {
            throw new NotImplementedException();
        }
    }

    public class LogProcessor
    {
        private ILogWriter _logWriter;
        private readonly Func<List<LogEntry>> _logImporter;

        public LogProcessor(Func<List<LogEntry>> logImporter)
        {
            _logImporter = logImporter;
        }

        public LogProcessor(ILogWriter logWriter)
        {
            _logWriter = logWriter;
        }



        public void Write(string message)
        {
            _logWriter.Write(message);
        }

        public void WriteError(Exception exception)
        {
            _logWriter.WriteError(exception);
        }

        public void ProcessLogs()
        {
            foreach(var logEntry in _logImporter.Invoke())
            {
                SaveLogEntry(logEntry);
            }
        }

        private void SaveLogEntry(LogEntry log)
        {
            Console.WriteLine("Save log.");
        }

    }







}