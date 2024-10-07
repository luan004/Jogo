namespace jogo;

public class Guria
{
    Texture2D guriaSpriteSheet;
    Vector2 guriaPosition;
    float guriaSpeed;
    
    int frameWidth;
    int frameHeight;
    int currentFrame;
    int direction; // 0: direita 1: esquerda 2: cima 3: baixo
    float timer;
    float interval;

    public Guria()
    {
        guriaSpriteSheet = Globals.Content.Load<Texture2D>("sprites/guria");
        guriaPosition = new Vector2(Globals.WindowSize.X / 2, Globals.WindowSize.Y / 2);
        guriaSpeed = 50f;

        //frameSheet
        frameWidth = 8;
        frameHeight = 8;
        currentFrame = 0;
        direction = 0;
        timer = 0f;
        interval = 150f;
    }

    public void Update(GameTime gameTime)
    {
        float deltaSpeed = guriaSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        Vector2 directionVector = Vector2.Zero;

        var kstate = Keyboard.GetState();

        if (kstate.IsKeyDown(Keys.W))
        {
            directionVector.Y -= 1;
            direction = 0;
        }
        
        if (kstate.IsKeyDown(Keys.S))
        {
            directionVector.Y += 1;
            direction = 1;
        }

        if (kstate.IsKeyDown(Keys.A))
        {
            directionVector.X -= 1;
            direction = 3;
        }

        if (kstate.IsKeyDown(Keys.D))
        {
            directionVector.X += 1;
            direction = 2;
        }

        if (kstate.IsKeyDown(Keys.D) && kstate.IsKeyDown(Keys.W))
        {
            direction = 4;
        }

        if (kstate.IsKeyDown(Keys.A) && kstate.IsKeyDown(Keys.W))
        {
            direction = 5;
        }

        if (directionVector != Vector2.Zero)
        {
            directionVector.Normalize();
            guriaPosition += directionVector * deltaSpeed;

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;
                if (currentFrame > 3) // maximo de 3 frames por linha
                {
                    currentFrame = 0;
                }
                timer = 0f;
            }
        }
        else
        {
            currentFrame = 3; // parado
        }
    }

    public void Draw()
    {
        Rectangle sourceRectangle = new Rectangle(currentFrame * frameWidth, direction * frameHeight, frameWidth, frameHeight);

        Globals.SpriteBatch.Draw(
            guriaSpriteSheet,
            guriaPosition,
            sourceRectangle,
            Color.White,
            0f,
            new Vector2(
                frameWidth / 2,
                frameHeight / 2
            ),
            Vector2.One,
            SpriteEffects.None,
            0f
        );
    }
}