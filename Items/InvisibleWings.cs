using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace VariedVanity.Items
{
	[AutoloadEquip(EquipType.Wings)]
	public class InvisibleWings : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Invisible Wings");
			Tooltip.SetDefault("Hides your current wings"
			+ "\nDoes not allow flight");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 20;
			item.rare = 2;
			item.accessory = true;
			item.vanity = true;
        }
		
		//these wings use the same values as the solar wings
		public override void UpdateAccessory(Player player, bool hideVisual)
		{
            player.wingsLogic = 0;
        }
		public override void UpdateVanity(Player player, EquipType type)
		{
			
		}

		/*public override void VerticalWingSpeeds(Player player, ref float ascentWhenFalling, ref float ascentWhenRising,
			ref float maxCanAscendMultiplier, ref float maxAscentMultiplier, ref float constantAscend)
		{
			ascentWhenFalling = 0f;
			ascentWhenRising = 0f;
			maxCanAscendMultiplier = 0f;
			maxAscentMultiplier = 0f;
			constantAscend = 0f;
		}

		public override void HorizontalWingSpeeds(Player player, ref float speed, ref float acceleration)
		{
			speed = 1f;
			acceleration *= 1f;
		}*/
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.StoneBlock);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}