using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace VariedVanity.Waters
{
	public class NeonWaterStyle : ModWaterStyle
	{
		public override bool ChooseWaterStyle()
		{
			return Main.LocalPlayer.GetModPlayer<VisualPlayer>().NeonWater;
		}

		public override int ChooseWaterfallStyle()
		{
			return mod.GetWaterfallStyleSlot("NeonWaterfallStyle");
		}

		public override int GetSplashDust()
		{
			return mod.DustType("NeonWaterSplash");
		}

		public override int GetDropletGore()
		{
			return mod.GetGoreSlot("Gores/NeonDroplet");
		}

		public override void LightColorMultiplier(ref float r, ref float g, ref float b) //thonk
		{
			r = 0f;
			g = 0f;
			b = 0f;
		}
		
		/*public override Color BiomeHairColor()
		{
			return Color.Green;
		}*/
	}
}