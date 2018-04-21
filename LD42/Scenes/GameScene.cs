using System;
using Comora;
using LD41.Entities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LD41.Scenes
{
    public class GameScene : Scene
    {
        
        public Entity player { get; set; }

        public GameScene(MainGame game, string name) : base(game, name)
        {
            
        }

        public override void Init()
        {

            base.Init();

            player = new Player(this.Game, this);
            player.Position = new Vector2(0, 0);
            player.Init();
            
        }

        public override void Update()
        {
            
            player.Update();
            base.Update();

            var screenPosition = Vector2.Zero;
            var worldPosition = Vector2.Zero;
            Cam.ToWorld(ref screenPosition, out worldPosition);


            Console.WriteLine($"Mouse Screen: {screenPosition}");
            Console.WriteLine($"Mouse World: {worldPosition}");
        }

        public override void Draw()
        {

            player.Draw();

            base.Draw();
        }

    }
}
