using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public class Tile
{
    public Tile() { }
	

    private Texture2D _texture;
    private Vector2 _origin;
    private Vector2 _position;
    private bool hasTexture; 

    public Tile(Texture2D texture, Vector2 position)
    {
        _texture = texture;
        _position = position;
        _origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
        this.hasTexture = false;
        
    }



    public Vector2 Position { get { return _position; }  set {_position = value; } }
    public Vector2 Origin { get { return _origin; }  set { _origin = value; } }

    public Texture2D Texture { get { return _texture; }  set { _texture = value; } }

    public bool HasTexture { get { return hasTexture; }  set { hasTexture = value; } }

    public void Draw(SpriteBatch _spriteBatch)
    {
        _spriteBatch.Draw(_texture, Position, null, Color.White, 0f, Origin, 2.6f, SpriteEffects.None, 0f);
    }
}

