using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace VariedVanity.Walls
{
	public class purpleLightWall : ModWall
	{
		public override void SetDefaults()
		{
			Main.wallHouse[Type] = true;
			drop = mod.ItemType("purpleLightWallItem");
			//AddMapEntry(new Color(150, 150, 150));
		}
	}
}