using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LD41.Scenes;
using Comora;
using LD41.Util;
using Microsoft.Xna.Framework.Input;

namespace LD41.Entities
{
    public class Entity
    {

        public MainGame Game;
        public Scene scene;

        public Texture2D Sprite { get; set; }
        public Vector2 Position { get; set; }
        public float Rotation { get; set; }

        public Vector2 Origin
        {
            get { return new Vector2(Sprite.Width / 2, Sprite.Height / 2); }
        }

       

        public Entity(MainGame game, Scene scene)
        {
            this.Game = game;
            this.scene = scene;
        }

        public virtual void Init()
        {
        }

        public virtual void Update()
        {

            
        }

        public virtual void Draw()
        {
            if (Sprite != null)
            {
                Game.spriteBatch.Begin(scene.Cam);
                Game.spriteBatch.Draw(Sprite, new Rectangle((int)Position.X, (int)Position.Y, Sprite.Width, Sprite.Height), null, Color.White, Rotation, Origin, SpriteEffects.None, 0);
                Game.spriteBatch.End();
            }
        }
    }
}
