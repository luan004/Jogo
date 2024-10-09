using System;
using System.IO;
using System.Text.Json;

namespace jogo;

public class SettingsManager
{
    private string settingsPath = "settings.json";

    public int WindowWidth { get; set; }
    public int WindowHeight { get; set; }
    public int WindowScale { get; set; }
    public bool WindowIsFullscreen { get; set; }

    public SettingsManager()
    {
        if (File.Exists(settingsPath))
        {
            LoadSettingsFile();
        }
        else
        {
            CreateSettingsFile();
            LoadSettingsFile();
        }
    }

    private void LoadSettingsFile()
    {
        var settings = JsonSerializer.Deserialize<JsonElement>(File.ReadAllText("settings.json"));

        var window = settings.GetProperty("window");

        try
        {
            WindowWidth = window.GetProperty("width").GetInt32();
            WindowHeight = window.GetProperty("height").GetInt32();
            WindowScale = window.GetProperty("scale").GetInt32();
            WindowIsFullscreen = window.GetProperty("fullscreen").GetBoolean();
        }
        catch (Exception)
        {
            CreateSettingsFile();
            LoadSettingsFile();
        }
    }

    private void CreateSettingsFile()
    {
        var settings = new
        {
            window = new {
                width = 1280,
                height = 720,
                scale = 4,
                fullscreen = false
            }
        };

        File.WriteAllText("settings.json", JsonSerializer.Serialize(settings));
    }

    public void SaveSettingsFile()
    {
        var settings = new
        {
            window = new {
                width = WindowWidth,
                height = WindowHeight,
                scale = WindowScale,
                fullscreen = WindowIsFullscreen
            }
        };

        File.WriteAllText("settings.json", JsonSerializer.Serialize(settings));
    }
}