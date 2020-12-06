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
	public class Viewer : ModItem
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Watcher of worlds [ADMIN ITEM]");
			Tooltip.SetDefault("Keeping an eye on things..."
            + "\nLeft click to increase view range"
            + "\nRight click to decrease view range");
        }

		public override void SetDefaults()
		{
			//item.vanity = true;
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
				if (modPlayer.ViewerRange == 0)
				{
                    if (player.altFunctionUse == 2)
                    {
                        player.GetModPlayer<VisualPlayer>().ViewerRange = 7;
                        Main.NewText("View Range: 64x");
                    }
                    else
                    {
                        player.GetModPlayer<VisualPlayer>().ViewerRange = 1;
                        Main.NewText("View Range: 1x");
                    }
                }
				else if (modPlayer.ViewerRange == 1)
                {
                    if (player.altFunctionUse == 2)
                    {
                        player.GetModPlayer<VisualPlayer>().ViewerRange = 0;
                        Main.NewText("View Range: 0x");
                    }
                    else
                    {
                        player.GetModPlayer<VisualPlayer>().ViewerRange = 2;
                        Main.NewText("View Range: 2x");
                    }
                }
                else if (modPlayer.ViewerRange == 2)
                {
                    if (player.altFunctionUse == 2)
                    {
                        player.GetModPlayer<VisualPlayer>().ViewerRange = 1;
                        Main.NewText("View Range: 1x");
                    }
                    else
                    {
                        player.GetModPlayer<VisualPlayer>().ViewerRange = 3;
                        Main.NewText("View Range: 4x");
                    }
                }
                else if (modPlayer.ViewerRange == 3)
                {
                    if (player.altFunctionUse == 2)
                    {
                        player.GetModPlayer<VisualPlayer>().ViewerRange = 2;
                        Main.NewText("View Range: 2x");
                    }
                    else
                    {
                        player.GetModPlayer<VisualPlayer>().ViewerRange = 4;
                        Main.NewText("View Range: 8x");
                    }
                }
                else if (modPlayer.ViewerRange == 4)
                {
                    if (player.altFunctionUse == 2)
                    {
                        player.GetModPlayer<VisualPlayer>().ViewerRange = 3;
                        Main.NewText("View Range: 4x");
                    }
                    else
                    {
                        player.GetModPlayer<VisualPlayer>().ViewerRange = 5;
                        Main.NewText("View Range: 16x");
                    }
                }
                else if (modPlayer.ViewerRange == 5)
                {
                    if (player.altFunctionUse == 2)
                    {
                        player.GetModPlayer<VisualPlayer>().ViewerRange = 4;
                        Main.NewText("View Range: 8x");
                    }
                    else
                    {
                        player.GetModPlayer<VisualPlayer>().ViewerRange = 6;
                        Main.NewText("View Range: 32x");
                    }
                }
                else if (modPlayer.ViewerRange == 6)
                {
                    if (player.altFunctionUse == 2)
                    {
                        player.GetModPlayer<VisualPlayer>().ViewerRange = 5;
                        Main.NewText("View Range: 16x");
                    }
                    else
                    {
                        player.GetModPlayer<VisualPlayer>().ViewerRange = 7;
                        Main.NewText("View Range: 64x");
                    }
                }
                else if (modPlayer.ViewerRange == 7)
                {
                    if (player.altFunctionUse == 2)
                    {
                        player.GetModPlayer<VisualPlayer>().ViewerRange = 6;
                        Main.NewText("View Range: 32x");
                    }
                    else
                    {
                        player.GetModPlayer<VisualPlayer>().ViewerRange = 0;
                        Main.NewText("View Range: 0x");
                    }
                }
            }
			return true;
		}

        public override bool AltFunctionUse(Player player)
        {
            return true;
        }

        /*public override Vector2? HoldoutOffset()
        {
            return new Vector2(100, 100);
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