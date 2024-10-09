namespace jogo;

public class GameManager
{
    private readonly Guria _guria;
    private readonly World _world;
    private readonly StatsManager _stats;

    public GameManager(SettingsManager settingsManager)
    {
        _world = new();
        _guria = new();
        _stats = new(settingsManager);
    }

    public void Update(GameTime gameTime)
    {
        _world.Update(gameTime);
        _guria.Update(gameTime);
    }

    public void Draw(GameTime gameTime)
    {
        _world.Draw();
        _guria.Draw();
    }
}