using Terraria.ID;
using Terraria.ModLoader;

namespace VariedVanity.Items
{
	public class NeonRedGraniteItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Neon Red Granite Tiles");
			Tooltip.SetDefault("Glows in the dark"
			+ "\nChanges the color of any waterfalls that pass over it");
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
			item.createTile = mod.TileType("NeonRedGranite");
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
