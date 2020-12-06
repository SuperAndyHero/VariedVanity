using System; 
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ObjectData;

namespace VariedVanity.Items
{
	[AutoloadEquip(EquipType.Shield)]
	public class FennixCostume : ModItem
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fennix Costume");
			Tooltip.SetDefault("Goes in a accessory slot"
			+ "\nWorks best with invisible armor");
		}

		public override void SetDefaults()
		{
			item.vanity = true;
			item.accessory = true;
			item.width = 46;
			item.height = 36;
			item.rare = 2;
		}

		public override void UpdateVanity(Player player, EquipType type)
		{
            player.GetModPlayer<VisualPlayer>().fennix = true;
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