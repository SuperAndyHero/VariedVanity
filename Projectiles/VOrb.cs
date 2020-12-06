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

namespace VariedVanity.Projectiles
{
	public class VOrb : ModProjectile
	{
		private bool Toggle = false;
		public int waveTime = 30;
		public int red = 0;
		public int green = 0;
		public int blue = 0;
		
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 50;
			projectile.timeLeft = 2000;
		}

		public override void AI()
		{
            if (projectile.ai[0] == 0)
            {
                red = Main.rand.Next(100, 255);
                green = Main.rand.Next(100, 255);
                blue = Main.rand.Next(100, 255);
                projectile.ai[0] = 1;
            }
        }

		public override bool OnTileCollide(Vector2 oldVelocity)
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
					projectile.velocity.X = -oldVelocity.X;
				}
				
				Main.PlaySound(SoundID.Item10, projectile.position);
			}
			return false;
		}
		
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