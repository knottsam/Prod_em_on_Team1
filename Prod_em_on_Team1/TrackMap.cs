using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using System.Data;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;

public class TrackMap
{
	private Point _mapSize = new(5, 30);
	private Tile[,] _tiles;
	public Point TileSize { get; private set;}
	public Point mapSize { get; private set; }


	public TrackMap(ContentManager content)
	{
		_tiles = new Tile[_mapSize.X, _mapSize.Y];
		List<Texture2D> textures = new List<Texture2D>();
		for (int i = 0; i < 3; i++) textures.Add(content.Load<Texture2D>($"track{i+1}"));

		TileSize = new(textures[0].Width, textures[0].Height);
		mapSize = new(TileSize.X * _mapSize.X, TileSize.Y * _mapSize.Y);

		Random myRand = new Random();

		for (int i = 0; i < _mapSize.X; i++)
		{
			for (int j = 0; j < _mapSize.Y; j++) {
				int k = myRand.Next(0, textures.Count);
				_tiles[i, j] = new(textures[k], new(j * TileSize.X, i * TileSize.Y));
			}
		}
	 }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < _mapSize.Y; y++)
            {
                for (int x = 0; x < _mapSize.X; x++) _tiles[x, y].Draw(spriteBatch);
            }
        }
    }



