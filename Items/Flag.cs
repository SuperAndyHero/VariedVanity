using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VariedVanity.Items
{
	[AutoloadEquip(EquipType.Head)]
	public class Flag : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Flag");
			Tooltip.SetDefault("Alternative to the invisible helmet"
			+ "\nHelps show your player position on the map to other players"
			+ "\nDyeing works best with Color/Silver dye, for example: [i:1051]");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.rare = 2;
			item.vanity = true;
			//item.accessory = true;
		}
		
		public override bool DrawHead()
		{
			return false;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}