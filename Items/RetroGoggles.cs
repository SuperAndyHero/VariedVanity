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
	public class RetroGoggles : ModItem
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gameboy Goggles");
			Tooltip.SetDefault("Limits the screen colors to the gameboy palette");
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
				if (!modPlayer.useRetroEffect)
				{
					player.GetModPlayer<VisualPlayer>().useRetroEffect = true;
					Main.NewText("Retro effect enabled");
                }
				else
				{
					player.GetModPlayer<VisualPlayer>().useRetroEffect = false;
					Main.NewText("Retro effect disabled");
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