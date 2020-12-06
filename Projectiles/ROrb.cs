using System; 
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ObjectData;

namespace VariedVanity.Projectiles
{
	public class ROrb : ModProjectile
	{
		public float OldXVel = 0f;
		public float OldYVel = 0f;
		public int red = 0;
		public int green = 0;
		public int blue = 0;

        public override string Texture
        {
            get
            {
                return "VariedVanity/Projectiles/crystalAni2";
            }
        }

        public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 3;
        }
		
		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 26;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.penetrate = 50;
			projectile.timeLeft = 800;
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
            //Main.NewText(projectile.velocity.X);
            //Main.NewText(projectile.velocity.Y);

            if (projectile.velocity.Y >= 8)
            {
                projectile.velocity.Y -= 1;
            }

            if (projectile.velocity.X >= 8)
            {
                projectile.velocity.X -= 1;
            }

            projectile.frameCounter += Convert.ToInt32(Math.Abs(projectile.velocity.Y) + Math.Abs(projectile.velocity.X));
				if (projectile.frameCounter >= 20)
				{
					projectile.frameCounter = 0;
					projectile.frame++;
					projectile.frame %= 3;
				}
				
			//projectile.rotation += ((projectile.velocity.Y + projectile.velocity.X) / 10);
			if(projectile.ai[0] >= (Main.rand.Next(40) + 10))
			{
				OldYVel = projectile.velocity.Y;
				OldXVel = projectile.velocity.X;
              
                //if rand
                switch (WorldGen.genRand.Next(7))
                        {
                            case 0:
                                projectile.velocity.Y = OldXVel;
								projectile.velocity.X = OldYVel;
                                break;
                            case 1:
                                projectile.velocity.Y = -OldXVel;
								projectile.velocity.X = -OldYVel;
                                break;
							case 2:
								projectile.velocity.Y = OldXVel;
								projectile.velocity.X = -OldYVel;
                                break;
							case 3:
								projectile.velocity.Y = -OldXVel;
								projectile.velocity.X = OldYVel;
                                break;
							case 4:
								projectile.velocity.Y = -OldYVel;
								projectile.velocity.X = -OldXVel;
                                break;
							case 5:
								projectile.velocity.Y = -OldYVel;
                                break;
							case 6:
								projectile.velocity.X = -OldXVel;
                                break;
							case 7:
                                break;
                        }
						
				switch (WorldGen.genRand.Next(4))
                        {
                            case 0:
                                projectile.velocity.X -= (Main.rand.Next(30) / 10);
                                break;
                            case 1:
                                projectile.velocity.X += (Main.rand.Next(30) / 10);
                                break;
							case 2:
                                projectile.velocity.Y -= (Main.rand.Next(30) / 10);
                                break;
							case 3:
                                projectile.velocity.Y += (Main.rand.Next(30) / 10);
                                break;
							case 4:
                                break;
						}
						
				projectile.ai[0] = 0; //reset timer
			}
				
			projectile.ai[0]++;
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
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				Main.PlaySound(SoundID.Item9, projectile.position);
			}
			return false;
		}
		
		public override Color? GetAlpha(Color lightColor)
		{
			
			return new Color(red, green, blue);
			
		}

		public override void Kill(int timeleft)
		{
			for (int k = 0; k < 5; k++)
			{
				//dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, mod.DustType("Sparkle"), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
				Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, 15, projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f, 150, default(Color), 1.5f);
			}
			Main.PlaySound(SoundID.Item27, projectile.position);
		}
	}
}