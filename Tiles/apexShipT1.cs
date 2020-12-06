using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;
using Terraria.DataStructures;
using Terraria.GameContent.UI;
using System;


namespace VariedVanity.Tiles
{
    public class apexShipT1 : ModTile
	{
		
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = false;
			Main.tileMergeDirt[Type] = false;
			drop = mod.ItemType("apexItemT1");
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
                Texture2D texture2 = mod.GetTexture("Tiles/ShipOverlay"); //Overlay

                Main.spriteBatch.Draw(texture2, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(0, 0, texture2.Width, texture2.Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			}
			
            Texture2D texture = mod.GetTexture("Tiles/apexT1"); //Ship Sprite
			Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X - 552, (j * 16 - (int)Main.screenPosition.Y) - 42) + zero, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);//X minus is left, Y minus is up

        }
	}
}