using System;
using TiledReader;
using Xunit;

namespace TiledReaderTest
{
    public class TiledReaderTests
    {
        [Fact]
        public void TiledReaderCSVFile()
        {
            string testFilePath = @"C:\Users\JFavo\source\repos\TiledReader\TiledReaderTest\TestData\CSVTestMap.tmx";

            var data = TiledMapReader.GenerateMap(testFilePath);
        }

        [Fact]
        public void TiledReaderBase64File()
        {
            string path = @"C:\Users\JFavo\source\repos\TiledReader\TiledReaderTest\TestData\Base64TestMap.tmx";

            var data = TiledMapReader.GenerateMap(path);
        }
    }
}
