using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace VariedVanity.Waters
{
	public class NeonPurpleGlowWaterfallStyle : ModWaterfallStyle
	{
		public override void ColorMultiplier(ref float r, ref float g, ref float b, float a)
		{
			r = 150f;
			g = 50f;
			b = 150f;
			//a = 100f;
		}
	}
}