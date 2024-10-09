using System;

namespace jogo;

public class Chunk
{
    public Tiles[] tiles = new Tiles[8 * 8];
    public int X {get;}
    public int Y {get;}

    public Chunk(int x, int y)
    {
        X = x;
        Y = y;
        for (int i = 0; i < tiles.Length; i++)
        {
            Random random = new Random();
            tiles[i] = (Tiles)random.Next(0, 4);
        }
    }

    public void Update(GameTime gameTime)
    {

    }

    public void Draw(GameTime gameTime)
    {
        
    }
}