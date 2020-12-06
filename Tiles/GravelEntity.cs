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
    public class GravelEntity : ModTileEntity
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
            return tile.active() && tile.type == ModContent.TileType<Gravel>() || tile.active() && tile.type == ModContent.TileType<SandRed>();// && tile.frameX == 0 && tile.frameY == 0
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
    }
}
