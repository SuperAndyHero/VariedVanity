using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace VariedVanity.Tiles
{
	public class purpleDark : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
			Main.tileBlockLight[Type] = false;
			 TileID.Sets.DrawsWalls[Type] = true;
			drop = mod.ItemType("purpleDarkItem");
			AddMapEntry(new Color(200, 50, 100));
			soundType = 21;
			dustType = 109;
		}
	}
}