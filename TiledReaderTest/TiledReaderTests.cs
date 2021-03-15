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

            Assert.NotNull(data);
            Assert.Equal(2, data.TileSets.Count);
            Assert.Equal(4, data.TileLayers.Count);
        }

        [Fact]
        public void TiledReaderBase64File()
        {
            string path = @"C:\Users\JFavo\source\repos\TiledReader\TiledReaderTest\TestData\Base64TestMap.tmx";

            var data = TiledMapReader.GenerateMap(path);

            Assert.NotNull(data);
            Assert.Equal(2, data.TileSets.Count);
            Assert.Equal(4, data.TileLayers.Count);
        }

        [Fact]
        public void TiledReaderZstdFile()
        {
            string path = @"C:\Users\JFavo\source\repos\TiledReader\TiledReaderTest\TestData\ZstdTestMap.tmx";

            var data = TiledMapReader.GenerateMap(path);

            Assert.NotNull(data);
            Assert.Equal(2, data.TileSets.Count);
            Assert.Equal(4, data.TileLayers.Count);
        }

        [Fact]
        public void TiledReaderZlibFile()
        {
            string path = @"C:\Users\JFavo\source\repos\TiledReader\TiledReaderTest\TestData\ZlibTestMap.tmx";

            var data = TiledMapReader.GenerateMap(path);

            Assert.NotNull(data);
            Assert.Equal(2, data.TileSets.Count);
            Assert.Equal(4, data.TileLayers.Count);
        }

        [Fact]
        public void TiledReaderGZipFile()
        {
            string path = @"C:\Users\JFavo\source\repos\TiledReader\TiledReaderTest\TestData\GZipTestMap.tmx";

            var data = TiledMapReader.GenerateMap(path);

            Assert.NotNull(data);
            Assert.Equal(2, data.TileSets.Count);
            Assert.Equal(4, data.TileLayers.Count);
        }
    }
}
