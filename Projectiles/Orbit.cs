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
	public class Orbit : ModProjectile
	{
        public override void SetDefaults()
		{
            projectile.width = 32;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.tileCollide = false;
			projectile.penetrate = 50;
            projectile.timeLeft = 5500;
            projectile.alpha = 255;
            //projectile.hide = true;

        }

        int distanceChange = 6;//lower is larger

        int speed = 200;//lower is faster
		float spinDirection = 1;
        //float radiusX = 200;
        //float radiusY = 80;
        Vector2 radiusDefault = new Vector2(200, 40);
        Vector2 radius = new Vector2(0, 0);

        bool atDest = false;
        Vector2 RealPos = new Vector2(0, 0);
        Vector2 offsetDefault = new Vector2(0, 0);
        Vector2 offset = new Vector2(0, 0);

        //int tileType = -1;
        Vector2 tileFrame = new Vector2(162, 54);

        public override void AI()
		{
            //Main.NewText("X:" + projectile.position.X + " Y:" + projectile.position.Y);

            if (projectile.ai[0] == 0)//projectile.localAI[0] may also work, first frame of spawning
            {
                speed = Main.rand.Next(180, 200);//random needs to be synced
                offsetDefault.X = Main.rand.Next(-10, 10);
                offsetDefault.Y = Main.rand.Next(-15, 15);
                radiusDefault.X = Main.rand.Next(185, 215);
                radiusDefault.Y = Main.rand.Next(35, 45);
                projectile.ai[0] = Main.rand.Next(100);

                if (Main.tileLighted[(int)projectile.ai[1]])
                {
                    projectile.light = 0.8f;
                }

                //tileType = Main.tile[(int)(projectile.position.X / 16), (int)(projectile.position.Y / 16)].type;

                //tileFrame.X = Main.tile[(int)(projectile.position.X / 16), (int)(projectile.position.Y / 16)].frameX;
                //tileFrame.Y = Main.tile[(int)(projectile.position.X / 16), (int)(projectile.position.Y / 16)].frameY;

                /*if (!Main.tile[(int)(projectile.Center.X / 16), (int)(projectile.Center.Y / 16)].active())
                {
                    projectile.active = false;
                }*/
            }

            Player player = Main.player[projectile.owner];
            radius = (radiusDefault * ((player.ownedProjectileCounts[ModContent.ProjectileType<Orbit>()] * 0.001f) + 1)) * -(float)(Math.Sin(projectile.ai[0]) - 4) / 4;
            offset = (offsetDefault * ((player.ownedProjectileCounts[ModContent.ProjectileType<Orbit>()] * 0.001f) + 1)) * -(float)(Math.Sin(projectile.ai[0]) - distanceChange) / distanceChange;

            if (!atDest)
            {
                /*Main.NewText("pro: " + projectile.position);
                Main.NewText("real: " + RealPos);
                Main.NewText("vel: " + projectile.velocity);*/

                if (Math.Abs(projectile.position.X - RealPos.X) <= 2 && Math.Abs(projectile.position.Y - RealPos.Y) <= 2 )
                {
                    atDest = true;
                    projectile.velocity = Vector2.Zero;
                }
            }

            if (!atDest)
            {
                RealPos.X = (Main.player[projectile.owner].Center.X + offset.X) - (int)(Math.Cos(projectile.ai[0]) * radius.X) - projectile.width / 2;
                RealPos.Y = (Main.player[projectile.owner].Center.Y + offset.Y + 1) - (int)(Math.Sin(projectile.ai[0]) * radius.Y) - projectile.height / 2;
                

                if (Math.Abs(projectile.position.X - RealPos.X) <= 50 && Math.Abs(projectile.position.Y - RealPos.Y) <= 50)
                {
                    projectile.velocity = (RealPos - projectile.position) * 0.6f;
                }
                else if (Math.Abs(projectile.position.X - RealPos.X) <= 20 && Math.Abs(projectile.position.Y - RealPos.Y) <= 20)
                {
                    projectile.velocity = (RealPos - projectile.position) * 0.4f;//0.5
                }
                else
                {
                    projectile.velocity = (RealPos - projectile.position) * 0.2f;//0.1
                }
            }
            else
            {
                projectile.position.X = (Main.player[projectile.owner].Center.X + offset.X) - (int)(Math.Cos(projectile.ai[0]) * radius.X) - projectile.width / 2;
                projectile.position.Y = (Main.player[projectile.owner].Center.Y + offset.Y + 1) - (int)(Math.Sin(projectile.ai[0]) * radius.Y) - projectile.height / 2;
            }



            if (!Main.player[projectile.owner].active)
            {
                projectile.Kill();
            }

            projectile.ai[0] += (float)Math.PI / speed * spinDirection;
        }

        public override void Kill(int timeLeft)
		{
            if (projectile.ai[0] != 0 && projectile.ai[1] >= 0)//projectile.localAI[0] may also work, first frame of spawning
            {
                    WorldGen.PlaceTile((int)(projectile.Center.X / 16), (int)(projectile.Center.Y / 16), (int)projectile.ai[1], false, true);
                    WorldGen.SquareTileFrame((int)(projectile.Center.X / 16), (int)(projectile.Center.Y / 16));
            }
        }



        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.ai[0] != 0 && projectile.ai[1] >= 0)
            {
                spriteBatch.Draw(Main.tileTexture[(int)projectile.ai[1]], projectile.position - Main.screenPosition, new Rectangle((int)tileFrame.X, (int)tileFrame.Y, 16, 16), lightColor, 0f, Vector2.Zero, -(float)(Math.Sin(projectile.ai[0]) - distanceChange) / distanceChange, SpriteEffects.None, 1f);
            }
            /*if ((Math.Sin(projectile.ai[0]) * radiusY) < 0)
            {
                Vector2 zero = Vector2.Zero;
                Texture2D texture = mod.GetTexture("Projectiles/Dirt");
                spriteBatch.Draw(texture, new Vector2(projectile.position.X - (int)Main.screenPosition.X, projectile.position.Y - (int)Main.screenPosition.Y) + zero, new Rectangle(0, 0, texture.Width, texture.Height), lightColor, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }*/
            return true;
        }
    }
}