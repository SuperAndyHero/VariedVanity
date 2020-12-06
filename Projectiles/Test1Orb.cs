using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace VariedVanity.Projectiles //Rando: 10 20 50 NonRandom: 10 20 50 change with right click
{
	public class Test1Orb : ModProjectile
	{
        public int red = 0;
        public int green = 0;
        public int blue = 0;


        public override void SetDefaults()
		{
            projectile.width = 32;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 50;
			projectile.timeLeft = 2000;
			projectile.tileCollide = false;
		}
        int speed = 100;
		float spinDirection = 1;
        float radius = 40;
        public override void AI() //ai 0 = needed for random, ai 1 for keeping track, bool used for wether to spawn a new projectile
		{
            if(projectile.ai[0] == 0)//projectile.localAI[0] would also work
            {
                //projectile.ai[0] = Main.rand.Next(100);
                switch (WorldGen.genRand.Next(2))
                {
                    case 0:
                        spinDirection = -1;
                        break;
                    case 1:
                        spinDirection = 1;
                        break;
                }
                red = Main.rand.Next(100, 255);
                green = Main.rand.Next(100, 255);
                blue = Main.rand.Next(100, 255);
                radius = Main.rand.Next(10, 80);
                speed = Main.rand.Next(30, 400);
            }

            if (projectile.ai[1] == 0)
            {
                projectile.position.X = Main.player[projectile.owner].Center.X - (int)(Math.Cos(projectile.ai[0]) * radius) - projectile.width / 2;
                projectile.position.Y = Main.player[projectile.owner].Center.Y - (int)(Math.Sin(projectile.ai[0]) * radius) - projectile.height / 2;
                if (!Main.player[projectile.owner].active)
                {
                    projectile.active = false;
                }
            }
            else
            {
                projectile.position.X = Main.projectile[(int)projectile.ai[1]].Center.X - (int)(Math.Cos(projectile.ai[0]) * radius) - projectile.width / 2;
                projectile.position.Y = Main.projectile[(int)projectile.ai[1]].Center.Y - (int)(Math.Sin(projectile.ai[0]) * radius) - projectile.height / 2;
                if (projectile.ai[1] == 49)
                {
                    //Projectile.NewProjectile(new Vector2(projectile.position.X, projectile.position.Y), Vector2.Zero, 94, 0, 0, Main.myPlayer, 0, 0);//spawns the trail
                }
                if (!Main.projectile[(int)projectile.ai[1]].active)
                {
                    projectile.active = false;
                }
            }

            projectile.ai[0] += (float)Math.PI / speed * spinDirection;
        }

        /*public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X * 4;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y * 4;
				}
				Main.PlaySound(SoundID.Item10, projectile.position);
			}
			return false;
		}*/

        public override Color? GetAlpha(Color lightColor)
		{
			
			return new Color(red, green, blue);
			
		}

		public override void Kill(int timeLeft)
		{
			for (int k = 0; k < 5; k++)
			{
				//Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sparkle"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 15, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f, 150, default(Color), 1.5f);
			}
			Main.PlaySound(SoundID.Item30 , projectile.position);
		}
	}
}