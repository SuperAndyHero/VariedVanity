using Terraria.ID;
using Terraria.ModLoader;

namespace VariedVanity.Items
{
	public class BarrierItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Barrier Item");
			Tooltip.SetDefault("A completely invisible block"
				+ "\nUse a revealing lens to view block"
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
			item.createTile = mod.TileType("Barrier");
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
