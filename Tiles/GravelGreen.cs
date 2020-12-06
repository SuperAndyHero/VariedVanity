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

    public class GravelGreen : ModTile
    {
        int delay = 0;
        public override void SetDefaults()
        {
            //Main.tileFrameImportant[Type] = false;
            //TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            //TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(mod.GetTileEntity<GravelEntity>().Hook_AfterPlacement, -1, 0, true);
            //TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.None, 0, 0);
            Main.tileBlockLight[Type] = true;
            //TileObjectData.addTile(Type);
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            drop = mod.ItemType("GravelGreenItem");
            AddMapEntry(new Color(200, 200, 200));
            dustType = 53;
            soundType = 38;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 1;
        }

        /*public override void NearbyEffects(int i, int j, bool closer)
        {
            delay = 0;
        }*/

        public override bool TileFrame(int i, int j, ref bool resetFrame, ref bool noBreak)
        {
            //if(delay == 0)
            //{
                /*if (delay == 1)
                {
                    return true;
                }*/
                if (WorldGen.noTileActions)
                {
                    return true;
                }
                delay = 1;
                Tile above = Main.tile[i, j - 1];//checks for chests / other tiles that need tiles below them
                Tile below = Main.tile[i, j + 1];
                Tile belowLeft = Main.tile[i - 1, j + 1];
                Tile belowRight = Main.tile[i + 1, j + 1];

                bool canFall = true;//desides if the below 3 bools matter
                bool canFallDown = true;//falldown overrides the below 2
                bool canFallLeft = true;
                bool canFallRight = true;

                if (below == null || below.active())
                {
                    canFallDown = false;
                }
                if (belowLeft == null || belowLeft.active())
                {
                    canFallLeft = false;
                }
                if (belowRight == null || belowRight.active())
                {
                    canFallRight = false;
                }
                if (above.active() && (TileID.Sets.BasicChest[above.type] || TileID.Sets.BasicChestFake[above.type] || TileLoader.IsDresser(above.type)))
                {
                    canFall = false;
                }
                if (canFall)
                {
                    if (canFallDown)
                    {
                        Main.tile[i, j].ClearTile();
                        WorldGen.PlaceTile(i, j + 1, ModContent.TileType<Tiles.GravelGreen>(), true, true);
                        //if (Main.netMode == 2)
                        //{
                        WorldGen.SquareTileFrame(i, j, true);
                        NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
                        //}
                    }
                    else
                    {
                        switch (WorldGen.genRand.Next(1)) //choose to fall down left or down right
                        {
                            case 0:
                                if (canFallLeft)
                                {
                                    Main.tile[i, j].ClearTile();
                                    WorldGen.PlaceTile(i - 1, j + 1, ModContent.TileType<Tiles.GravelGreen>(), true, true);
                                    //if (Main.netMode == 2)
                                    //{
                                    WorldGen.SquareTileFrame(i, j, true);
                                    NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
                                    //}
                                }
                                else if (canFallRight)
                                {
                                    Main.tile[i, j].ClearTile();
                                    WorldGen.PlaceTile(i + 1, j + 1, ModContent.TileType<Tiles.GravelGreen>(), true, true);
                                    //if (Main.netMode == 2)
                                    //{
                                    WorldGen.SquareTileFrame(i, j, true);
                                    NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
                                    //}
                                }
                                break;

                            case 1:
                                if (canFallRight)
                                {
                                    Main.tile[i, j].ClearTile();
                                    WorldGen.PlaceTile(i + 1, j + 1, ModContent.TileType<Tiles.GravelGreen>(), true, true);
                                    //if (Main.netMode == 2)
                                    //{
                                    WorldGen.SquareTileFrame(i, j, true);
                                    NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
                                    //}
                                }
                                else if (canFallLeft)
                                {
                                    Main.tile[i, j].ClearTile();
                                    WorldGen.PlaceTile(i - 1, j + 1, ModContent.TileType<Tiles.GravelGreen>(), true, true);
                                    //if (Main.netMode == 2)
                                    //{
                                    WorldGen.SquareTileFrame(i, j, true);
                                    NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
                                    //}
                                }
                                break;

                        }
                    }
                    /*if(canFallDown || canFallLeft || canFallRight)
                    {
                        WorldGen.KillTile(i, j, false, false, true);
                        if (Main.netMode == 2)
                        {
                            WorldGen.SquareTileFrame(i, j, true);
                            NetMessage.SendTileSquare(-1, i, j, 1, TileChangeType.None);
                        }
                    }*/
                    //return false;
                }
            //}

            //delay = 0;
            //return true;
            return false;//disabled cus annoying
            //}
            /*else
            {
                delay += 1;
                return true;
            }*/
        }
    }
}