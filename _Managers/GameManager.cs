namespace jogo;

public class GameManager
{
    private readonly Guria _guria;

    public GameManager()
    {
        _guria = new();
    }

    public void Update(GameTime gameTime)
    {
        _guria.Update(gameTime);
    }

    public void Draw(GameTime gameTime)
    {
        _guria.Draw();
    }
}