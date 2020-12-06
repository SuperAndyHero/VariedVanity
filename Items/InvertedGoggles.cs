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
	public class InvertedGoggles : ModItem
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Inverted Goggles");
			Tooltip.SetDefault("Inverts the all colors on the screen");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.rare = 2;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 4; 
			item.noUseGraphic = true;
		}

		public override bool UseItem(Player player)
		{
			VisualPlayer modPlayer = Main.LocalPlayer.GetModPlayer<VisualPlayer>();
			if (Main.netMode == 1 || Main.netMode == 0)
			{
				if (!modPlayer.useInvert)
				{
					player.GetModPlayer<VisualPlayer>().useInvert = true;
					Main.NewText("Invert effect enabled");
                }
				else
				{
					player.GetModPlayer<VisualPlayer>().useInvert = false;
					Main.NewText("Invert effect disabled");
                }
			}
			return true;
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