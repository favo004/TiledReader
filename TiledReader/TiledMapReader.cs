using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace TiledReader
{
    /// <summary>
    /// Takes a .tsx tiled file and converts it to a map or map room
    /// </summary>
    public static class TiledMapReader
    {

        /// <summary>
        /// Takes filepath and generates map from file
        /// </summary>
        /// <param name="tiledFilePath"></param>
        public static TiledMapData GenerateMap(string tiledFilePath)
        {
            TiledMapData mapData = null;
            if (File.Exists(tiledFilePath))
            {
                // Check to see if file has tiled extension
                if (tiledFilePath.EndsWith(".tmx"))
                {
                    try
                    {

                        XElement tiledFile = XElement.Load(tiledFilePath);

                        mapData = tiledFile.DescendantsAndSelf("map").Select(x => new TiledMapData
                        {
                            MapWidth = int.Parse(x.Attribute("width").Value),
                            MapHeight = int.Parse(x.Attribute("height").Value),
                            TileWidth = int.Parse(x.Attribute("tilewidth").Value),
                            TileHeight = int.Parse(x.Attribute("tileheight").Value),
                            TileSets = x.Descendants("tileset").Select(ts => new TileSetData
                            {
                                Name = ts.Attribute("source").Value,
                                StartId = int.Parse(ts.Attribute("firstgid").Value)
                            }).ToList(),
                            TileLayers = x.Descendants("layer").Select(tl => new TileLayerData
                            {
                                Id = int.Parse(tl.Attribute("id").Value),
                                Name = tl.Attribute("name").Value,
                                TilesWide = int.Parse(tl.Attribute("width").Value),
                                TilesHigh = int.Parse(tl.Attribute("height").Value),
                                EncodingData = tl.Element("data")
                                                                .Attributes()
                                                                .ToDictionary(k =>
                                                                    k.Name.LocalName,
                                                                    v => v.Value),
                                RawTileData = tl.Element("data").Value
                            }).ToList()

                        }).FirstOrDefault();

                        foreach (var layer in mapData.TileLayers)
                        {
                            layer.LoadInTiles();
                        }

                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error parsing through tiled file, {e.Message}");
                    }
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"File could not be found at {tiledFilePath}");
            }

            return mapData;
        }
    }
}
