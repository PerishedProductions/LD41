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

		public List<Bullet> bullets = new List<Bullet>();

		private int currentBulletDelay;
		private int bulletDelay = 200;
		private bool canShoot = true;

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

			currentBulletDelay += Game.GameTime.ElapsedGameTime.Milliseconds;

			if (currentBulletDelay >= bulletDelay)
			{
				currentBulletDelay = 0;
                canShoot = true;
			}
			else
			{
				canShoot = false;
			}

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

			if (Input.IsMouseBtnDown(Input.MouseButton.LEFT) && canShoot == true)
			{
				Bullet newBullet = new Bullet(Game, scene, Position, this);
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
