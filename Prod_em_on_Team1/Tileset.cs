﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public static class Tile
{
	public Tile()
	{

    private readonly Texture2D _texture;
    public Vector2 Position { get; protected set; }
    public Vector2 Origin { get; protected set; }

    public Tile(Texture2D texture, Vector2 position)
    {
        _texture = texture;
        Position = position;
        Origin = new(_texture.Width / 2, _texture.Height / 2);
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(_texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffects.None, 0f);
    }
}
}
