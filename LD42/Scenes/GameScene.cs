using System;
using Comora;
using LD41.Entities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LD41.Scenes
{
    public class GameScene : Scene
    {
        
        public Entity ent { get; set; }

        public GameScene(MainGame game, string name) : base(game, name)
        {
            
        }

        public override void Init()
        {

            base.Init();

            ent = new Entity(this.Game, this);
            ent.Sprite = Game.Content.Load<Texture2D>("Sprites/32");
            ent.Position = new Vector2(100, 100);
            ent.Init();
        }

        public override void Update()
        {

            ent.Update();
            base.Update();
        }

        public override void Draw()
        {

            ent.Draw();

            base.Draw();
        }

    }
}
