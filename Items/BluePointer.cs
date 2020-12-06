using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using System.Linq;

namespace VariedVanity.Items
{
	public class BluePointer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blue Laser Pointer");
			Tooltip.SetDefault("Do not stare directly into beam");
			//+ "\nMade from 100% synthetic materials!");
		}

		public override void SetDefaults()
		{
			//item.vanity = true;
			item.damage = 1;
			item.noMelee = true;
			//item.magic = true;
			item.channel = true; //Channel so that you can held the weapon [Important]
			item.mana = 0;
			item.rare = 5;
			item.width = 6;
			item.height = 18;
			item.useTime = 20;
			//item.UseSound = SoundID.Item13;
			item.useStyle = 5;
			item.shootSpeed = 14f;
			item.useAnimation = 20;
			item.shoot = mod.ProjectileType("BlueLaser");
			item.value = Item.sellPrice(silver: 3);
		}

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.RemoveAll(x => x.Name == "" || x.Name == "Damage" || x.Name == "CritChance" || x.Name == "Knockback" || x.Name == "Speed");
        }
		
		public override void AutoLightSelect (ref bool dryTorch, ref bool wetTorch, ref bool glowstick)
		{
			glowstick = true;
		}
		
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.IronBar, 20);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LeadBar, 20);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
    }
}
