using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace VariedVanity.Tiles
{
	public class NeonBlue : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
			//Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			//dustType = mod.DustType("Sparkle");
			drop = mod.ItemType("NeonBlueItem");
			AddMapEntry(new Color(50, 50, 200));
			//SetModTree(new ExampleTree());
			soundType = 21;
			dustType = 109;
		}

		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 0.1f;
			g = 0.1f;
			b = 0.2f;
		}
		
		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
			if (Main.drawToScreen)
			{
				zero = Vector2.Zero;
			}
			int height = tile.frameY == 36 ? 18 : 16;
            int width = tile.frameX == 36 ? 18 : 16;
            if (tile.slope() == 0 && !tile.halfBrick())
            {
                Main.spriteBatch.Draw(mod.GetTexture("Tiles/NeonBlueGlow"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle(tile.frameX, tile.frameY, 16, height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
            else if (tile.halfBrick())
            {
                Main.spriteBatch.Draw(mod.GetTexture("Tiles/NeonBlueGlow"), new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y + 10) + zero, new Rectangle(tile.frameX, tile.frameY + 10, 16, 6), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
            else
            {
                byte b3 = tile.slope();
                int num34 = 1;
                for (int num226 = 0; num226 < 8; num226 = num34 + 1)
                {
                    int num227 = num226 << 1;
                    Microsoft.Xna.Framework.Rectangle value5 = new Microsoft.Xna.Framework.Rectangle(tile.frameX, tile.frameY + num226 * 2, num227, 2);
                    int num228 = 0;
                    switch (b3)
                    {
                        case 2:
                            value5.X = 16 - num227;
                            num228 = 16 - num227;
                            break;
                        case 3:
                            value5.Width = 16 - num227;
                            break;
                        case 4:
                            value5.Width = 14 - num227;
                            value5.X = num227 + 2;
                            num228 = num227 + 2;
                            break;
                    }
                    Main.spriteBatch.Draw(mod.GetTexture("Tiles/NeonBlueGlow"), new Vector2(i * 16 - (int)Main.screenPosition.X + (float)num228, j * 16 - (int)Main.screenPosition.Y + num226 * 2) + zero, value5, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                    num34 = num226;
                }   
            }
        }

		public override void ChangeWaterfallStyle(ref int style)
		{
			style = mod.GetWaterfallStyleSlot("NeonBlueGlowWaterfallStyle");
		}
/*
		public override int SaplingGrowthType(ref int style)
		{
			style = 0;
			return mod.TileType("ExampleSapling");
		}*/
	}
}