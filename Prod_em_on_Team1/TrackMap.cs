using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;


public class TrackMap
{
	private Point _mapSize = new(6, 5);
	private Sprite[,] _tiles;
	public Point TileSize { get; private set;}
	public Point mapSize { get; private set; }	


	public TrackMap()
	{
		_tiles = new Tile[_mapSize.X, _mapSize.Y];
		List<Texture2D> textures = new[2];
		for (int i = 0; i < 3; i++) textures.Add(Globals.Content.Load<Texture2D>($"track(i)"));

		TileSize = new(textures[0].width, textures[0].height);
		mapSize = new(TileSize.X * _mapSize.X, TileSize.Y * _mapSize.Y);

		Random myRand = new Random();

		for(int i = 0; i < _mapSize.Y; y++)
		{
			for(int j = 0; j < _mapSize.X; j++) { 
				int k = myRand.Next(0, textures.Count);
				_tiles(i,j) = new(tex)
			}
		}
	}


}
