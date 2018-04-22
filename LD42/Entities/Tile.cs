using LD41.Scenes;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD41.Entities
{
    public class Tile : Entity
    {

        

        public Tile(MainGame game, Scene scene) : base(game, scene)
        {

        }

        public override void Init()
        {
            base.Init();

            Sprite = Game.Content.Load<Texture2D>("Sprites/32");

        }

    }
}
