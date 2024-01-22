
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;                                                  

public static class Sprite
{

    private Vector2 _origin;
    private Texture2D _texture;
    private Vector2 _position;
    private Rectangle _box;
    private int _lane = 0;
    private int _speed = 0;


    public Sprite()
    { }

    public Sprite(Vector2 inPosition, Rectangle inBox, int inLane, int inSpeed, Texture2D _texture)
    {
        _position = inPosition;
        _box = inBox;
        _lane = inLane;
        _speed = inSpeed;
        _origin = new Vector2(_texture.width / 2, _texture.height / 2)
    }

    public virtual void LoadContent(ContentManager myContent)
    {

    }
    public virtual void Update()
    {
        _position.X += _speed;
        _box.X = (int)_position.X;
        _box.Y = (int)_position.Y;
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, Position,null, Color.White, 0f, _origin, 1f, SpriteEffects.None, 0f);
    }

    public Vector2 Position
    {
        get { return _position; }
        set { _position = value; }
    }

    public Vector2 Texture { get { return _texture} set { _position = value; } }

    public Rectangle Box
    {
        get { return _box; }
        set { _box = value; }
    }

    public Texture2D Texture
    {
        get { return _texture; }
    }
    public int Lane
    {
        get { return _lane; }
        set { _lane = value; }
    }

    public int Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

}

