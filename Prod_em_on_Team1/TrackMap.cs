using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Prod_em_on_Team1;
using System.Security.Cryptography;
using System.Reflection.Metadata;

public class TrackMap
{
	private Point _mapSize = new(5, 720);
	private Tile[,] _tiles;
	public Point TileSize { get; private set; }
	public Tile[,] Tiles {  get {return _tiles; } private set{value = _tiles; } }	
	public Point mapSize { get; private set; }


	public void Update(ContentManager content, Player player)
	{
		
    }


    public TrackMap(ContentManager content)
	{
		_tiles = new Tile[_mapSize.X, _mapSize.Y];

		List<Texture2D> textures = new List<Texture2D>();
		List<Sprite> ramps = new List<Sprite>();

		for (int i = 0; i < 3; i++) textures.Add(content.Load<Texture2D>($"track{i + 1}"));


		TileSize = new(textures[0].Width, textures[0].Height);
		mapSize = new(TileSize.X * _mapSize.X, TileSize.Y * _mapSize.Y);
        

        Random myRand = new Random();
		int ramp_chance;

		


        for (int i = 0; i < _mapSize.X; i++)
		{
            
            for (int j = 0; j < _mapSize.Y; j++) {
				int k = myRand.Next(0, textures.Count);
                int obst_chance = myRand.Next(0, 100);

                _tiles[i, j] = new(textures[k], new(j * TileSize.X, 500 + i * TileSize.Y));

				 
                if (obst_chance != 15 && _tiles[i, j].HasTexture == false ) _tiles[i, j] = new(textures[k], new(j * TileSize.X, 500 + i * TileSize.Y));
                if (obst_chance == 15 && _tiles[i, j].HasTexture == false ) {
					_tiles[i, j] = new(content.Load<Texture2D>($"pothole1"), new(j * TileSize.X, 500 + i * TileSize.Y));
                    _tiles[i, j].IsPothole = true;
                    if (i == 4)
					{ 
						_tiles[2, j] = new(content.Load<Texture2D>($"pothole1"), new(j * TileSize.X, 500 + i * TileSize.Y));
                        _tiles[1, j].HasTexture = true;
						_tiles[1, j].IsPothole = true; 
                    }
					else if (i == 3)
					{
						_tiles[1, j] = new(content.Load<Texture2D>($"pothole1"), new(j * TileSize.X, 500 + i * TileSize.Y));
						_tiles[1, j].HasTexture = true;
                        _tiles[1, j].IsPothole = true;
                    }
				}
				
			}
		}






		/*for(int i = 0; i < _mapSize.X; i++)
		{
			ramp_chance = myRand.Next(1,100);

			

			if (ramp_chance == 20) { 
			
				for(int p = i; p < i + 8; p++)
				{
					for(int q = 0; q < _mapSize.X ; q++)
					{
						_tiles[q,p] = new(content.Load<Texture2D>($"ramp1"), new(q * TileSize.X, 500 + p * TileSize.Y));
						_tiles[q,p].Texture.Dispose();
					}
				}
			}
		


		}
		
		*/
	}

		




	 
	
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < _mapSize.Y; y++)
            {
                for(int x = 0; x < _mapSize.X; x++) _tiles[x, y].Draw(spriteBatch);
            }
        }
    }



