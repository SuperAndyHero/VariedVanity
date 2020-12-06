using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace VariedVanity.Tiles
{
	public class Barrier : ModTile
	{
		
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
			drop = mod.ItemType("BarrierItem");
			minPick = 40;
		}
		
		public override bool CanExplode(int i, int j)
		{
			return false;
		}
		
		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			
			Tile tile = Main.tile[i, j];
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
			
			VisualPlayer modPlayer = Main.LocalPlayer.GetModPlayer<VisualPlayer>();
			
			if(modPlayer.ShowBlocks)
			{
                Texture2D texture2 = mod.GetTexture("Tiles/BarrierOverlay"); //Overlay

                Main.spriteBatch.Draw(texture2, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(0, 0, texture2.Width, texture2.Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			}
        }
	}
}