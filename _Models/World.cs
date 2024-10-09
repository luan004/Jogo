namespace jogo;

public class World
{
    Texture2D tilesSpriteSheet;
    Chunk chunk;

    public World()
    {
        tilesSpriteSheet = Globals.Content.Load<Texture2D>("sprites/tiles");
        chunk = new Chunk(0,0);
    }

    public void Update(GameTime gameTime)
    {
        chunk.Update(gameTime);
    }

    public void Draw()
    {
        Rectangle sourceRectangle = new Rectangle(0, 0, 8, 8);

        for (int i = 0; i < chunk.tiles.Length; i++)
        {
            sourceRectangle.X = (int)chunk.tiles[i] * 8;
            sourceRectangle.Y = 0;
 
            int x = (i % 8) * 8 + (int)Globals.WindowSize.X / 2 - 32;
            int y = (i / 8) * 8 + (int)Globals.WindowSize.Y / 2 - 32;

            Globals.SpriteBatch.Draw(tilesSpriteSheet, new Vector2(x, y), sourceRectangle, Color.White);
        }
    }
}