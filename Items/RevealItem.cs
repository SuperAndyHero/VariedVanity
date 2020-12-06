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
using Terraria.Graphics.Effects;

namespace VariedVanity.Items
{
	public class RevealItem : ModItem
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Revealing lens");
			Tooltip.SetDefault("Reveals all invisible blocks");
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
		}
		
		public override bool UseItem(Player player)//one of the messages shows for everyone in multiplayer
		{
			VisualPlayer modPlayer = Main.LocalPlayer.GetModPlayer<VisualPlayer>();
			if (Main.netMode == 1 || Main.netMode == 0)
			{
                if (Main.myPlayer == player.whoAmI)
                {
                    if (!modPlayer.ShowBlocks)
                    {
                        player.GetModPlayer<VisualPlayer>().ShowBlocks = true;
                        Main.NewText("Invisible blocks shown");
                        if (!Filters.Scene["WaterFilter"].IsActive())
                        {
                            //Texture2D texture2 = mod.GetTexture("Tiles/testDraw2"); //Overlay
                            //Filters.Scene.Activate("AuraFilter", player.Center).GetShader().UseImage(texture2).UseTargetPosition(player.Center).UseIntensity(8f); //For UseProgress (Opacity) lower is stronger, For UseIntensity higher is stronger
                            //Filters.Scene.Activate("ZoomFilter", player.Center).GetShader().UseDirection(new Vector2(8f, 2f)).UseImageOffset(new Vector2(0.4375f, 0.25f));

                            Texture2D texture3 = mod.GetTexture("Effects/Glass4"); //Overlay
                            Texture2D texture4 = mod.GetTexture("Effects/Glass4O"); //Overlay
																				   // color1: max for distortion. color2: amount of distortion. color3: minimum for shine. SecondaryColors: shine color. UseImageOffset: zoom out mult. UseIntensity: height scale. UseProgress: shine strength. UseDirection: speed for both layers.

							Filters.Scene.Activate("RefractionFilter", player.Center).GetShader()
									.UseImage(texture3, 0)
									.UseImage(texture4, 1)
									.UseIntensity(0.05f);                     //y stretch for both layers, lower is more


                            /*Filters.Scene.Activate("WaterFilter", player.Center).GetShader()
                                .UseImage(texture3)                     //texture
                                .UseColor(0.25f, 0.3f, 1.5f)            //maximim for distortion, amount of distort, 
                                .UseSecondaryColor(0.7f, 0.95f, 1f)     //shine color and distort color (if used)
                                .UseImageOffset(new Vector2(5f, 6f))    //zoom out mult for layer 1 and 2
                                .UseIntensity(0.8f)                     //y stretch for both layers, lower is more
                                .UseDirection(new Vector2(0.50f, 0.44f)) //
                                .UseProgress(8f)                        //mult for shine 2 (change to color blue value later)
                                .Shader.Parameters["uSpeed"].SetValue(new Vector4(6.33f, 4.7f, 3.2f, 7f));//speed for both layers, (x, y), (x2, y2) lower is faster
                               */

                            /*Filters.Scene["WaterFilter"].GetShader().UseTargetPosition(player.Center);
                            Filters.Scene["WaterFilter"].GetShader().UseImage(texture3);
                            Filters.Scene["WaterFilter"].GetShader().UseColor(0.25f, 0.3f, 1.5f);
                            Filters.Scene["WaterFilter"].GetShader().UseSecondaryColor(0.7f, 0.95f, 1f);
                            Filters.Scene["WaterFilter"].GetShader().UseImageOffset(new Vector2(5f, 6f));
                            Filters.Scene["WaterFilter"].GetShader().UseIntensity(0.8f);
                            Filters.Scene["WaterFilter"].GetShader().UseDirection(new Vector2(0.50f, 0.44f));
                            Filters.Scene["WaterFilter"].GetShader().UseProgress(8f);
                            Filters.Scene["WaterFilter"].GetShader().Shader.Parameters["uSpeed"].SetValue(new Vector4(6.33f, 4.7f, 3.2f, 7f));
                            Filters.Scene["WaterFilter"].GetShader().Apply();*/



                            //Filters.Scene.Activate("AuraFilter", player.Center).GetShader().UseProgress(1.5f).UseImageOffset(new Vector2(2, 1.15f)).UseIntensity(-0.02f).UseTargetPosition(player.Center).UseOpacity(1.0f).UseColor(new Vector3(0.4f, 0.4f, 0.4f));
                            //UseProgress = size. UseImageOffset = X/Y scale correction. UseIntensity = distortion scale. UseTargetPosition = Position in world for aura. UseOpacity = Desaturation. UseColor = Brightness.
                        }
                    }
                    else
                    {
                        if (Filters.Scene["RefractionFilter"].IsActive())
                        {
                            //Filters.Scene["BlurFilter"].GetShader().UseOpacity(a).UseIntensity(b); //to update the shader
                            Filters.Scene.Deactivate("RefractionFilter");
                        }
                        player.GetModPlayer<VisualPlayer>().ShowBlocks = false;
                        Main.NewText("Invisible blocks hidden");
                    }
                }
			}
			return true;
		}
		
		/*public override bool UseItem(Player player)
		{
			VisualPlayer modPlayer = Main.LocalPlayer.GetModPlayer<VisualPlayer>();
			if (Main.netMode == 1 || Main.netMode == 0)
			{
				if (player.altFunctionUse == 2)
				{
					player.GetModPlayer<VisualPlayer>(mod).ShowBlocks = false;
					Main.NewText("Invisible blocks shown");
				}
				else
				{
					player.GetModPlayer<VisualPlayer>(mod).ShowBlocks = true;
					Main.NewText("Invisible blocks hidden");
				}
			}
			return true;
		}*/
		
		/*public override bool AltFunctionUse(Player player) not used?
		{
			return true;
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