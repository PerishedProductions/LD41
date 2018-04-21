using Comora;
using Microsoft.Xna.Framework;
using System;

namespace LD41.Scenes
{
    public class Scene
    {
        
        public MainGame Game { get; set; }
        public string Name { get; set; }

        public Camera Cam { get; set; }

        public Scene(MainGame game, string name)
        {
            this.Name = name;
            this.Game = game;
        }

        public virtual void Init()
        {
            Cam = new Camera(Game.GraphicsDevice);
            Console.WriteLine($"The scene {Name} has been initialized.");
        }

        public virtual void Update()
        {
            Cam.Update(Game.GameTime);
        }

        public virtual void Draw()
        {
            Game.spriteBatch.Begin();
            Game.spriteBatch.DrawString(Game.defaultFont, $"Current scene: {Name}", new Vector2(0, 0), Color.White);
            Game.spriteBatch.End();
        }

    }
}
