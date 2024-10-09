namespace jogo;

public class StatsManager
{
    public StatsManager(SettingsManager settingsManager)
    {
        Draw(settingsManager);
    }

    public void Draw(SettingsManager settingsManager)
    {
        Globals.SpriteBatch.DrawString(Globals.Font, $"Scale: ${settingsManager.WindowScale}", new Vector2(10, 10), Color.White);
    }
}