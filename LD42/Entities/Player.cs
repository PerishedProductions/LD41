using LD41.Scenes;
using LD41.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD41.Entities
{
    public class Player : Entity
    {

        private int movementSpeed = 3;

        private List<Bullet> bullets = new List<Bullet>();

        public Player(MainGame game, Scene scene) : base(game, scene)
        {

        }

        public override void Init()
        {
            Sprite = Game.Content.Load<Texture2D>("Sprites/32");

            base.Init();
        }

        public override void Update()
        {
            if (Input.IsKeyDown(Keys.W))
            {
                Position -= new Vector2(0, movementSpeed);
            }
            if (Input.IsKeyDown(Keys.S))
            {
                Position += new Vector2(0, movementSpeed);
            }

            if (Input.IsKeyDown(Keys.A))
            {
                Position -= new Vector2(movementSpeed, 0);
            }
            if (Input.IsKeyDown(Keys.D))
            {
                Position += new Vector2(movementSpeed, 0);
            }

            if (Input.IsMouseBtnClicked(Input.MouseButton.LEFT))
            {
                Bullet newBullet = new Bullet(Game, scene, Position);
                newBullet.Init();
                bullets.Add(newBullet);
            }

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();
            }

        }

        public override void Draw()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw();
            }

            base.Draw();
        }
    }
}
