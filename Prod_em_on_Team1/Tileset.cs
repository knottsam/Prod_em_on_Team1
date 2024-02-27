using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Prod_em_on_Team1;

public class Tile
{
    public Tile() { }
	

    private Texture2D _texture;
    private Vector2 _origin;
    private Vector2 _position;
    private Rectangle _box;
    private bool hasTexture;
    private bool isPothole;

    public Tile(Texture2D texture, Vector2 position)
    {
        _texture = texture;
        _position = position;
        _origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
        this.hasTexture = false;
        this.isPothole = false; 
    }

    public void Update(Player player)
    {
        if(this.isPothole)
        {
            this._box.X = (int)this.Position.X;
            this._box.Y = (int)this._position.Y; 
            this._box.Width = (int)this._texture.Width;   
            this._box.Height = (int)this._texture.Height;   
        }

        
    }
        
    public Vector2 Position { get { return _position; }  set {_position = value; } }
    public Vector2 Origin { get { return _origin; }  set { _origin = value; } }

    public Texture2D Texture { get { return _texture; }  set { _texture = value; } }

    public bool HasTexture { get { return hasTexture; }  set { hasTexture = value; } }

    public bool IsPothole { get { return isPothole; } set { isPothole = value; } }

    public Rectangle Box { get { return _box; } set { _box = value; } }
    public void Draw(SpriteBatch _spriteBatch)
    {
        _spriteBatch.Draw(_texture, Position, null, Color.White, 0f, Origin, 2.6f, SpriteEffects.None, 0f);
    }
}

