using System.IO;

namespace MarsRover
{
    public class StreamReaderFactory
    {
        private static readonly StreamReaderFactory Factory = new StreamReaderFactory();

        public StreamReader GetStreamReader(string filePath)
        {
            return new StreamReader(filePath);
        }

        public static StreamReaderFactory GetFactory()
        {
            return Factory;
        }
    }
}