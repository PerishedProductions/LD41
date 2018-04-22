using LD41.Scenes;
using LD41.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD41.Entities
{
    public class Bullet : Entity
    {

        public Player Parent { get; set; }

        private int movementSpeed = 10;
        private Vector2 dir;

        private int currentDelay;
        private int delay = 2000;

        public Bullet(MainGame game, Scene scene, Player parent) : base(game, scene)
        {
            this.Parent = parent;
        }

        public Bullet(MainGame game, Scene scene, Vector2 positon, Player parent) : base(game, scene)
        {
            this.Position = positon;
            this.Parent = parent;
        }

        public override void Init()
        {
            base.Init();

            Sprite = Game.Content.Load<Texture2D>("Sprites/16");

            Vector2 screenPosition = Input.GetMousePosition();
            Vector2 worldPosition = Vector2.Zero;

            worldPosition = Vector2.Transform(screenPosition, scene.Cam.ViewportOffset.Absolute);

            dir = worldPosition - Position;
            if (dir != Vector2.Zero)
            {
                dir.Normalize();
            }
            
        }

        public override void Update()
        {
            Position += dir * movementSpeed;

            currentDelay += Game.GameTime.ElapsedGameTime.Milliseconds;

            if (currentDelay >= delay)
            {
                Parent.bullets.Remove(this);
            }



            base.Update();
        }

    }
}
