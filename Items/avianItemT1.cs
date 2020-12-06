using Terraria.ID;
using Terraria.ModLoader;

namespace VariedVanity.Items
{
	public class avianItemT1 : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Avian Teir 1 Ship");
			Tooltip.SetDefault("A ship right from starbound"
				+ "\nPlaces a overlay of a ship, use barrier blocks to give it collision"
					+ "\nUse a revealing lens to view origin block"
						+ "\nNeeds a iron pickaxe or above to mine");
		}
		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.createTile = mod.TileType("avianShipT1");
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GrayBrick, 1);
			//recipe.AddIngredient(ItemID.RedBrick, 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
