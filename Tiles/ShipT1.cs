using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using System.IO;
using Terraria.ModLoader.IO;
using System.Linq;


namespace VariedVanity.Tiles
{
    public class EntityT1 : ModTileEntity
    {
        internal Vector2 TileEntPos()
        {
            return new Vector2(Position.X, Position.Y);
        }

        public override bool ValidTile(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            Main.NewText("ValidTile" + i + j);
			ErrorLogger.Log("Tile");
            return tile.active() && tile.type == ModContent.TileType<ShipT1>() && tile.frameX == 0 && tile.frameY == 0;
        }
		
		public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction)
		{
			//Main.NewText("place");
			if (Main.netMode == 1)
			{
				NetMessage.SendTileSquare(Main.myPlayer, i, j, 3);
				NetMessage.SendData(87, -1, -1, null, i, j, Type, 0f, 0, 0, 0);
				return -1;
			}
			return Place(i, j);
		}
    }

	public class ShipT1 : ModTile
	{
		
		public override void SetDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(ModContent.GetInstance<EntityT1>().Hook_AfterPlacement, -1, 0, true);
			TileObjectData.addTile(Type);
			Main.tileSolid[Type] = false;
			Main.tileMergeDirt[Type] = false;
			drop = mod.ItemType("ItemT1");
			minPick = 40;
		}

		
		public override bool CanExplode(int i, int j)
		{
			return false;
		}
		
		public override void KillTile (int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
		{
			if(!fail)
			{
				//Main.NewText("test");
				ModContent.GetInstance<EntityT1>().Kill(i, j);
			}
		}
		
		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			VisualPlayer modPlayer = Main.LocalPlayer.GetModPlayer<VisualPlayer>();
			Tile tile = Main.tile[i, j];
            Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);



            if (modPlayer.ShowBlocks)
			{
                Texture2D texture2 = mod.GetTexture("Tiles/ShipOverlay"); //Overlay

                Main.spriteBatch.Draw(texture2, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(0, 0, texture2.Width, texture2.Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			}
			
            /* texture = mod.GetTexture("Tiles/T1"); //Ship Sprite
			Main.spriteBatch.Draw(texture, new Vector2(i * 16 - (int)Main.screenPosition.X - 544, (j * 16 - (int)Main.screenPosition.Y) - 72) + zero, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);*/

        }
	}
}