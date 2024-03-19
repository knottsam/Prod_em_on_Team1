using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

namespace Prod_em_on_Team1
{
    internal class Track
    {
        private Tile[,] _map;
        private int _mapLength;
        private Gate[] _gates;
        private Point walls = new Point(1, 92);
        private Point crowd = new Point(1, 92);
        private Tile[,] grassTiles;
        private Tile[,] wallTiles;
        private Tile[,] crowdTiles;
        public Track(ContentManager content)
        {
            grassTiles = new Tile[6, 920];
            wallTiles = new Tile[walls.X, walls.Y];
            crowdTiles = new Tile[crowd.X, crowd.Y];


            Random rnd = new Random();
            Texture2D[] textures = new Texture2D[3];
            Texture2D potholeTexture = content.Load<Texture2D>($"pothole1");
            Texture2D rampTexture = content.Load<Texture2D>($"ramp2");
            Texture2D finishTexture = content.Load<Texture2D>($"finish line");
            _mapLength = 731;
            _map = new Tile[_mapLength, 6];

            for (int i = 0; i < 3; i++)
            {
                textures[i] = content.Load<Texture2D>($"track{i + 1}");
            }


            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 920; j++)
                {
                    grassTiles[i, j] = new(content.Load<Texture2D>("grassTileExciteBike"), new(j * 32, 264 + i * 32), "thing");

                }
            }

            for (int i = 0; i < walls.Y; i++)
            {
                wallTiles[0, i] = new(content.Load<Texture2D>($"wall with logo"), new(i * 10 * 32, 181 + 32), "thing");
            }
            for (int i = 0; i < walls.Y; i++)
            {
                crowdTiles[0, i] = new(content.Load<Texture2D>($"ExcitebikeCrowd"), new(i * 10 * 32, 60 + 32), "thing");
            }


            string line = "";
            string[] linesInFile = new string[6];
            linesInFile = File.ReadAllLines(@".\map1.txt");

            for(int i = 0; i<linesInFile.Length; i++)
            {
                line = linesInFile[i];
                for(int j = 0; j<line.Length; j++)
                {
                    switch (line[j])
                    {
                        case '0':
                            _map[j, i] = new Tile(textures[rnd.Next(0,3)], new Vector2(468 + j * 32, 500 + i * 32), "false");
                            break;

                        case '1':
                            _map[j, i] = new Tile(potholeTexture, new Vector2(468 + j * 32, 500 + i * 32), "pothole");
                            break;

                        case '2':
                            _map[j, i] = new Tile(rampTexture, new Vector2(468 + j * 32, 530 + i * 32), "ramp");
                            break;

                        case '3':
                            _map[j, i] = new Tile(finishTexture, new Vector2(468 + j * 32, 530 + i * 32), "finish line");
                            break;
                    }
                }
            }

            _gates = new Gate[6];
            for (int i = 0; i < 6; i++)
            {
                _gates[i] = new Gate(new Vector2(500, 468 + i * 32), content);
            }
        }

        public void Update(Player player)
        {
            foreach(Tile tile in _map)
            {
                tile.Update(player);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < 920; y++)
            {
                for (int x = 0; x < 6; x++) grassTiles[x, y].Draw(spriteBatch);
            }

            for (int y = 0; y < walls.Y; y++)
            {
                wallTiles[0, y].Draw(spriteBatch);
                crowdTiles[0, y].Draw(spriteBatch);
            }

            for (int i = 0; i < _mapLength; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    _map[i, j].Draw(spriteBatch);
                }
            }

            /*foreach (Tile tile in _map)
            {
                if(tile.Type != "ramp")
                {
                    tile.Draw(spriteBatch);
                }
            }*/
            foreach(Tile tile in _map)
            {
                if(tile.Type == "ramp")
                {
                    tile.Draw(spriteBatch);
                }
            }

            foreach (Gate gate in _gates)
            {
                gate.Draw(spriteBatch);
            }

            
        }

        public void OpenGates()
        {
            foreach (Gate gate in _gates)
            {
                gate.Open();
            }
        }

    }
}
