using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _texture;
        private Vector2 _position;

        private Texture2D _texture2;
        private Vector2 _position2;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public Rectangle BoundingBox => new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
        public Rectangle BoundingBox2 => new Rectangle((int)_position2.X, (int)_position2.Y, _texture2.Width, _texture2.Height);
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 1800;
            _graphics.PreferredBackBufferHeight = 900;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _texture = Content.Load<Texture2D>("car");
            _position = new Vector2(0, 0);

            _texture2 = Content.Load<Texture2D>("car2");
            _position2 = new Vector2(800, 400);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            // Exit();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                _position.Y -= 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                _position.X -= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                _position.Y += 3;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                _position.X += 5;
            }
            if (BoundingBox.Intersects(BoundingBox2))
            {
                _position.X = 0;
                _position.Y = 0;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_texture, _position, Color.White);
            _spriteBatch.End();

            _spriteBatch.Begin();
            _spriteBatch.Draw(_texture2, _position2, Color.White);
            _spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
