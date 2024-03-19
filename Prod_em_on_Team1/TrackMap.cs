using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Prod_em_on_Team1;
using System.Security.Cryptography;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Input;

public class TrackMap
{
	private Point _mapSize = new(5, 920);
	private Point outsideMapSize = new(6,920);
	private Tile[,] _tiles;
	private Point walls = new Point(1, 92);
	private Point crowd = new Point(1, 92);
	private Tile[,] grassTiles;
    private Tile[,] wallTiles;
	private Tile[,] crowdTiles;
    public Point TileSize { get; private set; }
	public Point mapSize { get; private set; }


	public void Update(ContentManager content, Player player)
	{
		
    }

	
    public TrackMap(ContentManager content)
	{
		_tiles = new Tile[_mapSize.X, _mapSize.Y];
		grassTiles = new Tile[outsideMapSize.X, outsideMapSize.Y];
		wallTiles = new Tile[walls.X, walls.Y];
		crowdTiles = new Tile[crowd.X, crowd.Y];

		List<Texture2D> textures = new List<Texture2D>();
	

        for (int i = 0; i < 3; i++) textures.Add(content.Load<Texture2D>($"track{i + 1}"));


		TileSize = new(textures[0].Width, textures[0].Height);
		mapSize = new(TileSize.X * _mapSize.X, TileSize.Y * _mapSize.Y);
        

        Random myRand = new Random();


		for(int i = 0; i < outsideMapSize.X; i++)
		{
			for(int j = 0; j < outsideMapSize.Y; j++)
			{
				grassTiles[i, j] = new(content.Load<Texture2D>($"green square"), new(j * TileSize.X, 264 + i * TileSize.Y), true);

            }
		}

		for(int i = 0; i < walls.Y; i++)
		{
			wallTiles[0, i] = new(content.Load<Texture2D>($"wall with logo"), new(i * 10 * TileSize.X, 181 + TileSize.Y), true);
        }
        for (int i = 0; i < walls.Y; i++)
        {
            crowdTiles[0, i] = new(content.Load<Texture2D>($"crowd"), new(i * 10 * TileSize.X, 60 + TileSize.Y), true);
        }

        for (int i = 0; i < _mapSize.X; i++)
		{

			for (int j = 0; j < _mapSize.Y; j++)
			{
				int k = myRand.Next(0, textures.Count);
				int obst_chance = myRand.Next(0, 120); //random chance for tile to be pothole
				int boost_chance = myRand.Next(0, 200);

				
				_tiles[i, j] = new Tile(false);


				if (obst_chance != 15 && _tiles[i, j].HasTexture == false && boost_chance != 15) {
                    _tiles[i, j] = new(textures[k], new(j * TileSize.X, 500 + i * TileSize.Y), true);
                }
				
				if (obst_chance == 15 && !_tiles[i, j].HasTexture && boost_chance!= 15 || obst_chance == 15 && boost_chance == 15 && !_tiles[i, j].HasTexture)
				{
					_tiles[i, j] = new(content.Load<Texture2D>($"pothole1"), new(j * TileSize.X, 500 + i * TileSize.Y),true);
					_tiles[i, j].IsPothole = true;

				}
				if (boost_chance == 15 && obst_chance != 15 && !_tiles[i, j].HasTexture)
				{
                    _tiles[i, j] = new(content.Load<Texture2D>($"boost"), new(j * TileSize.X, 500 + i * TileSize.Y),true);
                    _tiles[i, j].IsBoost = true;
                }
			}
		}

	}

		




	 
	
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < _mapSize.Y; y++)
            {
                for(int x = 0; x < _mapSize.X; x++) _tiles[x, y].Draw(spriteBatch);
            }

        for (int y = 0; y < outsideMapSize.Y; y++)
        {
            for (int x = 0; x < outsideMapSize.X; x++) grassTiles[x, y].Draw(spriteBatch);
        }

		for(int y = 0; y < walls.Y; y++)
		{
			wallTiles[0,y].Draw(spriteBatch);
			crowdTiles[0, y].Draw(spriteBatch);
		}
    }
    }


