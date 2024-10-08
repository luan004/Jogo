using System;
using System.IO;
using System.Text.Json;

namespace jogo;

public class SettingsManager
{
    private string settingsPath = "settings.json";

    public int WindowWidth { get; set; }
    public int WindowHeight { get; set; }
    public int Scale { get; set; }

    public SettingsManager()
    {
        if (File.Exists(settingsPath))
        {
            LoadSettings();
        }
        else
        {
            CreateSettings();
            LoadSettings();
        }
    }

    public void Update(GameTime gameTime)
    {
        //
    }

    public void Draw(GameTime gameTime)
    {
        //
    }

    private void LoadSettings()
    {
        var settings = JsonSerializer.Deserialize<JsonElement>(File.ReadAllText("settings.json"));

        var window = settings.GetProperty("window");

        WindowWidth = window.GetProperty("width").GetInt32();
        WindowHeight = window.GetProperty("height").GetInt32();
        Scale = window.GetProperty("scale").GetInt32();
    }

    private void CreateSettings()
    {
        var settings = new
        {
            window = new {
                width = 1366,
                height = 768,
                scale = 4
            }
        };

        File.WriteAllText("settings.json", JsonSerializer.Serialize(settings));
    }
}