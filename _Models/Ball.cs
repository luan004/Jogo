namespace jogo;

public class Ball
{
    Texture2D ballTexture;
    Vector2 ballPosition;
    float ballSpeed;
    
    public Ball()
    {
        ballTexture = Globals.Content.Load<Texture2D>("ball");

        ballPosition = new Vector2(Globals.WindowSize.X / 2, Globals.WindowSize.Y / 2);

        ballSpeed = 500f;
    }

    public void Update(GameTime gameTime)
    {
        // Calcular a velocidade atual com base no tempo
        float deltaSpeed = ballSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Acumular direção de movimento
        Vector2 direction = Vector2.Zero;
        
        var kstate = Keyboard.GetState();
        
        if (kstate.IsKeyDown(Keys.Up))
            direction.Y -= 1;

        if (kstate.IsKeyDown(Keys.Down))
            direction.Y += 1;

        if (kstate.IsKeyDown(Keys.Left))
            direction.X -= 1;

        if (kstate.IsKeyDown(Keys.Right))
            direction.X += 1;

        // Normalizar direção (evita movimentação diagonal mais rápida)
        if (direction != Vector2.Zero)
            direction.Normalize();

        // Atualizar posição
        ballPosition += direction * deltaSpeed;
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(
            ballTexture,
            ballPosition,
            null,
            Color.White,
            0f,
            new Vector2(ballTexture.Width / 2, ballTexture.Height / 2),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
    }
}