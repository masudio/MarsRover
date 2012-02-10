using System.Collections.Generic;
using System.IO;

namespace MarsRover
{
    public static class DataParser
    {
        public static string[] Parse(string s)
        {
            var result = new List<string>();
            using (var streamReader = new StreamReader(s))
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