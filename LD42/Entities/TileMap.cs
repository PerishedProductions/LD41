using LD41.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Xml;

namespace LD41.Entities
{
    public class TileMap : Entity
    {

        public List<Tile> tiles = new List<Tile>();

        public int Width { get; set; }
        public int Height { get; set; }

        public int TileWidth { get; set; }
        public int TileHeight { get; set; }

        public TileMap(MainGame game, Scene scene) : base(game, scene)
        {
            
        }

        public override void Update()
        {

            for (int i = 0; i < tiles.Count; i++)
            {
                tiles[i].Update();
            }

            base.Update();
        }

        public override void Draw()
        {

            for (int i = 0; i < tiles.Count; i++)
            {
                tiles[i].Draw();
            }

            base.Draw();
        }

        public void LoadMap()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Maps/maps.tmx");

            Width = int.Parse(doc.SelectSingleNode("map").Attributes["width"].Value);
            Height = int.Parse(doc.SelectSingleNode("map").Attributes["height"].Value);

            TileWidth = int.Parse(doc.SelectSingleNode("map").Attributes["tilewidth"].Value);
            TileHeight = int.Parse(doc.SelectSingleNode("map").Attributes["tileheight"].Value);

            string mapData = doc.SelectSingleNode("map/layer/data").InnerText;
            //mapData = mapData.Replace("\r\n", "");

            string[] mapArray = mapData.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int y = 0; y < Height; y++)
            {

                string[] currentLine = mapArray[y].Split(',');

                for (int x = 0; x < Width; x++)
                {
                    string current = currentLine[x];
                    if (current == "1")
                    {
                        Tile newTile = new Tile(Game, scene);
                        newTile.Init();
                        newTile.Position = new Vector2(TileWidth * x, TileHeight * y);
                        tiles.Add(newTile);
                    }
                }
            }

        }

    }
}
