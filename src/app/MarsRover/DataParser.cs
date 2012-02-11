using System.Collections.Generic;

namespace MarsRover
{
    public static class DataParser
    {
        public static string[] Parse(string s, StreamReaderFactory streamReaderFactory)
        {
            var result = new List<string>();
            using (var streamReader = streamReaderFactory.GetStreamReader(s))
            {
                string line;
                while (null != (line = streamReader.ReadLine()))
                {
                    result.Add(line);
                }
            }

            return result.ToArray();
        }
    }
}