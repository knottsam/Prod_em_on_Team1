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
    private string _type;

    public Tile(Texture2D texture, Vector2 position, string type)
    {
        _texture = texture;
        _position = position;
        _type = type;
        _origin = new Vector2(_texture.Width / 2, _texture.Height / 2);

        if (_type == "pothole")
        {
            _box.X = (int)Position.X;
            _box.Y = (int)_position.Y - 32;
            _box.Width = 32;
            _box.Height = 32;
        }
        else if(_type == "ramp")
        {
            _box = new Rectangle((int)_position.X - 100, 468, 192, 192);
        }
    }

    public void Update(Player player)
    {
        if (_type == "pothole")
        {
            if (_box.Intersects(player.Box))
            {
                if (player.AngleOfRotation < 0 && player.Speed.X > 2)
                {
                    player.Speed = new Vector2(player.Speed.X - 2, player.Speed.Y);
                }
                else if (player.Speed.X > 4)
                {
                    player.Speed = new Vector2(player.Speed.X - 1, player.Speed.Y);
                }
            }
        }
        else if(_type == "ramp")
        {
            if(_box.Intersects(player.Box))
            {
                if(player.Speed.Y > -4)
                {
                    player.Speed = new Vector2(player.Speed.X, (int)(-player.Speed.X * 0.3));

                }
                if (player.AngleOfRotation - 0.2f >= -0.8f)
                {
                    player.AngleOfRotation -= 0.2f;
                }
                else if(player.AngleOfRotation > -0.8f || player.AngleOfRotation < -0.8f)
                {
                    player.AngleOfRotation = -0.8f;
                }
                
                if(player.Position.X >= _position.X && player.Position.X <= _position.X + 10)// if(player.Box.Intersects(new Rectangle((int)_position.X, (int)_position.Y, 2, 100)))
                {
                    player.Speed -= new Vector2(0, 6);
                }
            }
        }
        
        
    }
        
    public Vector2 Position { get { return _position; }  set {_position = value; } }
    public Vector2 Origin { get { return _origin; }  set { _origin = value; } }

    public Texture2D Texture { get { return _texture; }  set { _texture = value; } }

    public bool HasTexture { get { return hasTexture; }  set { hasTexture = value; } }

    public string Type { get { return _type; } set { _type = value; } }

    public Rectangle Box { get { return _box; } set { _box = value; } }
    public void Draw(SpriteBatch _spriteBatch)
    {
        /*if(_underRamp < 0)
        {
            _spriteBatch.Draw(_texture, Position, null, Color.White, 0f, Origin, 2.6f, SpriteEffects.None, 0f);
        }*/
        if(_type == "ramp")
        {
            _spriteBatch.Draw(_texture, Position, null, Color.White, 0f, Origin, 1.36f, SpriteEffects.None, 0f);
        }
        else
        {
            _spriteBatch.Draw(_texture, Position, null, Color.White, 0f, Origin, 2.6f, SpriteEffects.None, 0f);
        }
    }
}

