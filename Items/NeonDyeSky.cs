using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;

namespace VariedVanity.Items
{
	public class NeonDyeSky : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Neon Sky Blue Dye");
			/*Tooltip.SetDefault("Escape Escape Escape Escape"
				+ "\nA key right off someones keyboard!"
				+ "\nCloses the game"
				+ "\nMake sure your progress has been saved first");*/
		}
		public override void SetDefaults()
		{
			byte dye = item.dye;
			item.CloneDefaults(ItemID.GelDye);
			item.dye = dye;
		}
	}
}
