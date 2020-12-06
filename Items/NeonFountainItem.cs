using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VariedVanity.Items
{
	public class NeonFountainItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Neon Fountain");
		}
		
		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 32;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			//item.rare = 10;
			item.value = Item.buyPrice(0, 0, 400, 0);
			item.createTile = mod.TileType("NeonFountain");
		}
	}
}