using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace VariedVanity.Tiles
{
	public class crystalBrick : ModTile
	{
		public override void SetDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = false;
			Main.tileBlockLight[Type] = false;
			drop = mod.ItemType("crystalBrickItem");
			AddMapEntry(new Color(80, 20, 80));
			soundType = 21;
			//dustType = 78;
		}
	}
}