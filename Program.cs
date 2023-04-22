using SFML.Graphics;
using SFML.System;
using SFML.Window;
namespace Space_Invaders;

public class Game
{
    public const int WIDTH = 1040;
    public const int HEIGHT = 880;
    private const string TITLE = "Space Invaders";
    private RenderWindow _window;
    private Sprite _background;
    private Player _player;
    private Player2 _player2;
    
    public Game()
    {
        var mode = new VideoMode(WIDTH, HEIGHT);
        _window = new RenderWindow(mode, TITLE);

        _window.SetVerticalSyncEnabled(true);
        _window.Closed += (_, _) => _window.Close();
        _background = new Sprite();
        _background.Texture = TextureManager.BackgroundTexture;
        _player = new Player();
        _player2 = new Player2();

    }

    private void HandleEvents() 
        {
        _window.DispatchEvents(); 
        }

        private void Update()
        {
            _player.Update();
            _player2.Update();
        } 
        private void Draw() 
    {
        _window.Draw(_background);
        _player.Draw(_window);
        _player2.Draw(_window);
        _window.Display();
    } 
        public void Run()
    {
        while (_window.IsOpen)
        {
            HandleEvents();
            Update();
            Draw();
        }
    }
}

public class TextureManager
{    
    private const string ASSETS_PATH = "C:/Users/minva/RiderProjects/Space Invaders/Space Invaders/Assets";
    private const string BACKGROUND_TEXTURE_PATH = "/Backgrounds/greenBG.png";
    private const string PLAYER_TEXTURE_PATH = "/Ships/playerShip2_green.png";
    private const string PLAYER2_TEXTURE_PATH = "/Ships/playerShip1_blue.png";
    public static Texture BackgroundTexture;
    public static Texture PlayerTexture;
    public static Texture PlayerTexture2;

    static TextureManager()
    {
        BackgroundTexture = new Texture(ASSETS_PATH + BACKGROUND_TEXTURE_PATH);
        PlayerTexture = new Texture(ASSETS_PATH + PLAYER_TEXTURE_PATH);
        PlayerTexture2 = new Texture(ASSETS_PATH + PLAYER2_TEXTURE_PATH);
    }  
}
public class Player
{
    private const float PLAYER_SPEED = 4f;    
    private Sprite _sprite;

    public Player()
    {
        _sprite = new Sprite();
        _sprite.Texture = TextureManager.PlayerTexture;
        var spriteSize = new Vector2f(_sprite.TextureRect.Width, _sprite.TextureRect.Height);
        var screenCenter = new Vector2f(Game.WIDTH / 2f, Game.HEIGHT / 2f);
        var startPosition = screenCenter - spriteSize / 4f;
        _sprite.Position = startPosition;
    }
    public void Draw(RenderWindow window)
    {
        window.Draw(_sprite);
    }
    private void Move()
    {
        bool shouldMoveLeft = Keyboard.IsKeyPressed(Keyboard.Key.A);
        bool shouldMoveRight = Keyboard.IsKeyPressed(Keyboard.Key.D);
        bool shouldMoveUp = Keyboard.IsKeyPressed(Keyboard.Key.W);
        bool shouldMoveDown = Keyboard.IsKeyPressed(Keyboard.Key.S);
        bool shouldMove = shouldMoveLeft || shouldMoveRight || shouldMoveUp || shouldMoveDown;

        if (!shouldMove)
        {
            return;
        }
        var position = _sprite.Position;
        
        if (shouldMoveLeft)
        {
            position.X -= PLAYER_SPEED;
        }

        if (shouldMoveRight)
        {
            position.X += PLAYER_SPEED;
        }

        if (shouldMoveUp)
        {
            position.Y -= PLAYER_SPEED;
        }

        if (shouldMoveDown)
        {
            position.Y += PLAYER_SPEED;
        }
        _sprite.Position = position;
    }
    public void Update()
    {
        Move();
    }
}

public class Player2
{
    private const float PLAYER_SPEED = 4f;    
    private Sprite _sprite;

    public Player2()
    {
        _sprite = new Sprite();
        _sprite.Texture = TextureManager.PlayerTexture2;
        var spriteSize = new Vector2f(_sprite.TextureRect.Width, _sprite.TextureRect.Height);
        var screenCenter = new Vector2f(Game.WIDTH / 2f, Game.HEIGHT / 2f);
        var startPosition = screenCenter - spriteSize ;
        _sprite.Position = startPosition;
    }
    
    public void Draw(RenderWindow window)
    {
        window.Draw(_sprite);
    }
    private void Move()
    {
        bool shouldMoveLeft = Keyboard.IsKeyPressed(Keyboard.Key.J);
        bool shouldMoveRight = Keyboard.IsKeyPressed(Keyboard.Key.L);
        bool shouldMoveUp = Keyboard.IsKeyPressed(Keyboard.Key.I);
        bool shouldMoveDown = Keyboard.IsKeyPressed(Keyboard.Key.K);
        bool shouldMove = shouldMoveLeft || shouldMoveRight || shouldMoveUp || shouldMoveDown;

        if (!shouldMove)
        {
            return;
        }
        var position = _sprite.Position;
        
        if (shouldMoveLeft)
        {
            position.X -= PLAYER_SPEED;
        }

        if (shouldMoveRight)
        {
            position.X += PLAYER_SPEED;
        }

        if (shouldMoveUp)
        {
            position.Y -= PLAYER_SPEED;
        }

        if (shouldMoveDown)
        {
            position.Y += PLAYER_SPEED;
        }
        _sprite.Position = position;
    }
    public void Update()
    {
        Move();
    }
}

   

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.Run();
    }
    
}