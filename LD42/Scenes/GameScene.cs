using System;
using LD41.Entities;
using Microsoft.Xna.Framework;
using LD41.Util;

namespace LD41.Scenes
{
    public class GameScene : Scene
    {
        
        public Entity player { get; set; }

        private TileMap map;

        public GameScene(MainGame game, string name) : base(game, name)
        {
            
        }

        public override void Init()
        {

            base.Init();

            player = new Player(this.Game, this);
            player.Position = new Vector2(0, 0);
            player.Init();
            map = new TileMap(Game, this);
            map.LoadMap();

            
        }

        public override void Update()
        {

            map.Update();
            player.Update();
            Cam.Position = player.Position;
            base.Update();

        }

        public override void Draw()
        {

            player.Draw();
            map.Draw();
            base.Draw();
        }

    }
}
