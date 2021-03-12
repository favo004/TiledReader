﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TiledReader
{
    public class TiledMapData
    {
        // Number of tiles high of the map
        public int MapHeight;
        // Number of tiles wide of the map
        public int MapWidth;
        // Height of a tile
        public int TileHeight;
        // Width of a tile
        public int TileWidth;

        public List<TileSetData> TileSets;
        public List<TileLayerData> TileLayers;

        public TiledMapData()
        {
            TileSets = new List<TileSetData>();
            TileLayers = new List<TileLayerData>();
        }

        /// <summary>
        /// Sets end ids for tilesets
        /// </summary>
        public void UpdateTileSetIds()
        {

        }
    }

    public class TileSetData
    {
        public string Name { get; set; }
        public int StartId { get; set; }
        public int EndId { get; set; }

    }

    public class TileLayerData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TilesWide { get; set; }
        public int TilesHigh { get; set; }

        public Dictionary<string, string> EncodingData;
        public string Encoding
        {
            get
            {
                if(EncodingData != null &&
                   EncodingData.ContainsKey("encoding"))
                {
                    return EncodingData["encoding"];
                }
                else
                {
                    return "xml";
                }
            }
        }
        public string Compression
        {
            get
            {
                if (EncodingData != null &&
                    EncodingData.ContainsKey("compression"))
                {
                    return EncodingData["compression"];
                }

                return "";
            }
        }
        public string RawTileData;
        public int[][] Tiles;

        public TileLayerData()
        {

        }
        public TileLayerData(int id, string name, int tilesWide, int tilesHigh)
        {

        }

        /// <summary>
        /// Loads in data and decompresses based on compression code
        /// </summary>
        /// <param name="data"></param>
        /// <param name="compression"></param>
        public void LoadInTiles()
        {
            RawTileData = RawTileData.Replace("\n", "").Trim();

            switch (Encoding)
            {
                case "csv":
                    CSVDecompression();
                    break;
                case "base64":
                    switch (Compression)
                    {
                        case "zstd":
                            ZStandardDecompression();
                            break;
                        case "zlib":
                            ZLibDecompression();
                            break;
                        case "gzip":
                            GZipDecompression();
                            break;
                        case "":
                            StandardBase64();
                            break;
                    }
                    break;
                case "xml":
                    XMLDecompression();
                    break;
            }
        }

        private void CSVDecompression()
        {
            int[] splitData = Array.ConvertAll(RawTileData.Split(','), s => int.Parse(s));

            GetTileDataFromRaw(splitData);
        }
        private void ZStandardDecompression()
        {
            
        }
        private void ZLibDecompression()
        {

        }
        private void StandardBase64()
        {
            var data = Convert.FromBase64String(RawTileData);
            int tileCount = TilesWide * TilesHigh;
            int[] tmp = new int[tileCount];
            Buffer.BlockCopy(data, 0, tmp, 0, tmp.Length);

            GetTileDataFromRaw(tmp);
        }
        private void GZipDecompression()
        {

        }
        private void XMLDecompression()
        {

        }

        private void GetTileDataFromRaw(int[] raw)
        {
            Tiles = new int[TilesHigh][];

            for (int i = 0; i < TilesHigh; i++)
            {
                Tiles[i] = raw.Skip(i * TilesWide).Take(TilesWide).ToArray();
            }
        }
    }
}
