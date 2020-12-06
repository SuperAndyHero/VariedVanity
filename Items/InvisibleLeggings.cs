using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VariedVanity.Items
{
	[AutoloadEquip(EquipType.Legs)]
	public class InvisibleLeggings : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			Tooltip.SetDefault("Invisible Leggings");
			Tooltip.SetDefault("Hides your current leggings");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.rare = 2;
			item.vanity = true;
		}

		public override bool DrawLegs()
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