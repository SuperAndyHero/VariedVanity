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
    /*public class GravelEntity : ModTileEntity
    {
        internal Vector2 TileEntPos() //Only have to use if using ModWorld to draw at entity
        {
            return new Vector2(Position.X, Position.Y);
        }

        public override bool ValidTile(int i, int j)
        {
            Tile tile = Main.tile[i, j];
            //Main.NewText("ValidTile" + i + j);
			//ErrorLogger.Log("Tile");
            return tile.active() && tile.type == mod.TileType<Gravel>();// && tile.frameX == 0 && tile.frameY == 0
        }
		
		public override int Hook_AfterPlacement(int i, int j, int type, int style, int direction)
		{
            //Main.NewText("place" + Position.X + Position.Y);
			if (Main.netMode == 1)
			{
				NetMessage.SendTileSquare(Main.myPlayer, i, j, 3);
				NetMessage.SendData(87, -1, -1, null, i, j, Type, 0f, 0, 0, 0);
				return -1;
			}
			return Place(i, j);
		}
    }*/

	public class Gravel : ModTile
	{
		
		public override void SetDefaults()
		{
			//Main.tileFrameImportant[Type] = false;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(ModContent.GetInstance<GravelEntity>().Hook_AfterPlacement, -1, 0, true);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.None, 0, 0);
            Main.tileBlockLight[Type] = true;
            TileObjectData.addTile(Type);
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			drop = mod.ItemType("GravelItem");
            AddMapEntry(new Color(200, 200, 200));
            dustType = 53;
            soundType = 38;
            //minPick = 40;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 1;
        }

        /*public override void NearbyEffects(int i, int j, bool closer)
        {
            //Checks if within world bounds
            if (i > 10 && i < Main.maxTilesX - 10 && j > 10 && j < Main.maxTilesY - 10)
            {
                //Down
                if (WorldGen.EmptyTileCheck((int)i, (int)i, (int)j + 1, (int)j + 1))
                {
                    WorldGen.PlaceTile((int)i, (int)j + 1, mod.TileType<Tiles.Gravel>(), true, true);
                    

                    WorldGen.KillTile((int)i, (int)j, false, false, true); //sound is the break sound for tile, use custom
                }
                else //If now down then this
                {
                    switch (WorldGen.genRand.Next(2)) //choose to fall downleft or down right
                    {
                        case 0://Down left, and then down right if fail
                            if (WorldGen.EmptyTileCheck((int)i - 1, (int)i - 1, (int)j + 1, (int)j + 1))
                            {
                                WorldGen.PlaceTile((int)i - 1, (int)j + 1, mod.TileType<Tiles.Gravel>(), true, true);
                                

                                WorldGen.KillTile((int)i, (int)j, false, false, true);
                            }
                            else if (WorldGen.EmptyTileCheck((int)i + 1, (int)i + 1, (int)j + 1, (int)j + 1))
                            {
                                WorldGen.PlaceTile((int)i + 1, (int)j + 1, mod.TileType<Tiles.Gravel>(), true, true);
                                

                                WorldGen.KillTile((int)i, (int)j, false, false, true);
                            }
                            break;
                        case 1://Down right, and then down left if fail
                            if (WorldGen.EmptyTileCheck((int)i + 1, (int)i + 1, (int)j + 1, (int)j + 1))
                            {
                                WorldGen.PlaceTile((int)i + 1, (int)j + 1, mod.TileType<Tiles.Gravel>(), true, true);
                                

                                WorldGen.KillTile((int)i, (int)j, false, false, true);
                            }
                            else if (WorldGen.EmptyTileCheck((int)i - 1, (int)i - 1, (int)j + 1, (int)j + 1))
                            {
                                WorldGen.PlaceTile((int)i - 1, (int)j + 1, mod.TileType<Tiles.Gravel>(), true, true);
                                

                                WorldGen.KillTile((int)i, (int)j, false, false, true);
                            }
                            break;
                    }
                }
                //else
                //{
                //Main.NewText("Occupied (Y - 1)" + (int)i + ", " + (int)j);
                //}
            }
        }*/

        public override void KillTile (int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
		{
			if(!fail)
			{
                //Main.NewText("test");
                ModContent.GetInstance<GravelEntity>().Kill(i, j);
			}
		}
	}
}