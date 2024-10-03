namespace jogo;

public class Game1 : Game
{
    private SpriteBatch _spriteBatch;
    private GameManager _gameManager;
    private RenderTarget2D renderTarget;
    private Vector2 scaleFactor;

    public Game1()
    {
        Globals.Graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        Globals.WindowSize = new(128, 64);

        Globals.Graphics.PreferredBackBufferWidth = Globals.WindowSize.X * 4;
        Globals.Graphics.PreferredBackBufferHeight = Globals.WindowSize.Y * 4;

        Globals.Graphics.ApplyChanges();

        renderTarget = new RenderTarget2D(
            GraphicsDevice,
            Globals.WindowSize.X,
            Globals.WindowSize.Y
            );

        scaleFactor = new Vector2(2f, 2f);

        Globals.Content = Content;
        _gameManager = new();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Globals.SpriteBatch = _spriteBatch;
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        Globals.Update(gameTime);
        _gameManager.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.SetRenderTarget(renderTarget);
        GraphicsDevice.Clear(Color.CornflowerBlue);

        Globals.SpriteBatch.Begin();
        _gameManager.Draw(gameTime);
        Globals.SpriteBatch.End();

        GraphicsDevice.SetRenderTarget(null);
        GraphicsDevice.Clear(Color.Black);

        Globals.SpriteBatch.Begin();
        Globals.SpriteBatch.Draw(
            renderTarget,
            new Rectangle(0, 0, Globals.Graphics.PreferredBackBufferWidth, Globals.Graphics.PreferredBackBufferHeight),
            Color.White
        );
        Globals.SpriteBatch.End();

        base.Draw(gameTime);
    }
}
