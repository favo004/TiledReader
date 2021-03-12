using System;
using TiledReader;
using Xunit;

namespace TiledReaderTest
{
    public class TiledReaderTests
    {
        [Fact]
        public void TiledReaderReadsInFile()
        {
            string testFilePath = @"C:\Users\JFavo\source\repos\TiledReader\TiledReaderTest\TestData\CSVTestMap.tmx";

            var data = TiledMapReader.GenerateMap(testFilePath);
        }
    }
}
