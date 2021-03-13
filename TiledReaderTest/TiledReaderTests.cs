using TiledReader;
using Xunit;

namespace TiledReaderTest
{
    public class TiledReaderTests
    {
        [Fact]
        public void TiledReaderCSVFile()
        {
            string path = @"C:\Users\JFavo\source\repos\TiledReader\TiledReaderTest\TestData\CSVTestMap.tmx";

            var data = TiledMapReader.GenerateMap(path);
        }

        [Fact]
        public void TiledReaderBase64File()
        {
            string path = @"C:\Users\JFavo\source\repos\TiledReader\TiledReaderTest\TestData\Base64TestMap.tmx";

            var data = TiledMapReader.GenerateMap(path);
        }

        [Fact]
        public void TiledReaderZstdFile()
        {
            string path = @"C:\Users\JFavo\source\repos\TiledReader\TiledReaderTest\TestData\ZstdTestMap.tmx";

            var data = TiledMapReader.GenerateMap(path);
        }
    }
}
