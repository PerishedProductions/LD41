using System;
using Comora;
using LD41.Entities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LD41.Util;

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

            Cam.Zoom = 1;
        }

        public override void Update()
        {
            
            player.Update();
            base.Update();

        }

        public override void Draw()
        {

            player.Draw();

            base.Draw();
        }

    }
}
