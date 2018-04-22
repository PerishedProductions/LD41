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


        private int movementSpeed = 10;
        private Vector2 dir;

        public Bullet(MainGame game, Scene scene) : base(game, scene)
        {

        }

        public Bullet(MainGame game, Scene scene, Vector2 positon) : base(game, scene)
        {
            this.Position = positon;
        }

        public override void Init()
        {
            base.Init();

            Sprite = Game.Content.Load<Texture2D>("Sprites/32");

            var screenPosition = Input.GetMousePosition();
            var worldPosition = Vector2.Zero;

            scene.Cam.ToWorld(ref screenPosition, out worldPosition);
            worldPosition = Vector2.Transform(screenPosition, Matrix.Invert(scene.Cam.Transform.Local));


            Console.WriteLine($"Mouse Screen: {screenPosition}");
            Console.WriteLine($"Mouse World: {worldPosition}");

            dir = worldPosition - Position;
            if (dir != Vector2.Zero)
            {
                dir.Normalize();
            }
            
        }

        public override void Update()
        {
            Position += dir * movementSpeed;

            base.Update();
        }

    }
}
