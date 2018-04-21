using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LD41.Scenes;
using Comora;
using MonoGame.Extended.Input.InputListeners;

namespace LD41.Entities
{
    public class Entity
    {

        public MainGame game;
        public Scene scene;

        public Texture2D Sprite { get; set; }
        public Vector2 Position { get; set; }

        private KeyboardListener keyboardInput;

        public Vector2 Origin
        {
            get { return new Vector2(Sprite.Width / 2, Sprite.Height / 2); }
        }

        public float Rotation { get; set; }

        public Entity(MainGame game, Scene scene)
        {
            this.game = game;
            this.scene = scene;
        }

        public void Init()
        {
            keyboardInput = new KeyboardListener();
            keyboardInput.KeyTyped += HandleKeyboardInfo;
        }

        private void HandleKeyboardInfo(object sender, KeyboardEventArgs e)
        {
            if (e.Key == Microsoft.Xna.Framework.Input.Keys.A)
            {
                Position -= new Vector2(100, 0);
            }
        }

        public void Update()
        {
            keyboardInput.Update(game.GameTime);
        }

        public void Draw()
        {
            if (Sprite != null)
            {
                game.spriteBatch.Begin(scene.Cam);
                game.spriteBatch.Draw(Sprite, new Rectangle((int)Position.X, (int)Position.Y, Sprite.Width, Sprite.Height), null, Color.White, Rotation, Origin, SpriteEffects.None, 0);
                game.spriteBatch.End();
            }
        }
    }
}
