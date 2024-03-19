/*using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Prod_em_on_Team1;

public class TrackMap
{
	private Point _mapSize = new(5, 720);
	private Tile[,] _tiles;
	private Gate[] _gates;
	public Point TileSize { get; private set; }
	public Point mapSize { get; private set; }


	*//*public void Update(ContentManager content, Player player)
	{
    }*//*


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

                _tiles[i, j] = new(textures[k], new(j * TileSize.X, 500 + i * TileSize.Y), false);

				 
                if (obst_chance != 15 && _tiles[i, j].HasTexture == false ) _tiles[i, j] = new(textures[k], new(j * TileSize.X, 500 + i * TileSize.Y), false);
                if (obst_chance == 15 && _tiles[i, j].HasTexture == false) {
					_tiles[i, j] = new(content.Load<Texture2D>($"pothole1"), new(j * TileSize.X, 500 + i * TileSize.Y), true);
					if (i == 4)
					{ 
						_tiles[2, j] = new(content.Load<Texture2D>($"pothole1"), new(j * TileSize.X, 500 + i * TileSize.Y), true);
                        _tiles[1, j].HasTexture = true;
						_tiles[1, j].IsPothole = true; 
                    }
					else if (i == 3)
					{
						_tiles[1, j] = new(content.Load<Texture2D>($"pothole1"), new(j * TileSize.X, 500 + i * TileSize.Y), true);
						_tiles[1, j].HasTexture = true;
                        _tiles[1, j].IsPothole = true;
                    }
				}
				
			}
		}






		for(int i = 0; i < _mapSize.X; i++)
		{
			ramp_chance = 20;

			

			if (ramp_chance == 20) { 
			
				for(int p = i; p < i + 8; p++)
				{
					for(int q = 0; q < _mapSize.X ; q++)
					{
						_tiles[q,p] = new(content.Load<Texture2D>($"ramp1"), new(q * TileSize.X, 500 + p * TileSize.Y), false);
						//_tiles[q,p].Texture.Dispose();
					}
				}
			}
		


		}

		_gates = new Gate[6];
		for(int i=0;i<6;i++)
		{
			_gates[i] = new Gate(new Vector2(500,468 + i * 32), content);
		}
	}

	public void Update(Player player)
	{
		*//*int temp1 = (int)((player.Position.Y - 468) / 32);
		int temp2 = (int)((player.Position.X - 500) / 32);

        if (_tiles[temp1 , temp2].IsPothole && player.Speed.X > 3)
		{
			player.Speed = new Vector2(3, player.Speed.Y);
		}


		if(Game1.raceStarted)
		{

		}*//*

		foreach(Tile tile in _tiles)
		{
			tile.Update(player);
		}
	}

	public void OpenGates()
	{
		foreach(Gate gate in _gates)
		{
			gate.Open();
		}
	}

		




	 
	
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < _mapSize.Y; y++)
            {
                for(int x = 0; x < _mapSize.X; x++) _tiles[x, y].Draw(spriteBatch);
            }
			
			foreach(Gate gate in _gates)
			{
				gate.Draw(spriteBatch);
			}
        }
    }*/