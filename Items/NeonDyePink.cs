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
	public class NeonDyePink : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Neon Pink Dye");
		}
		public override void SetDefaults()
		{
			byte dye = item.dye;
			item.CloneDefaults(ItemID.GelDye);
			item.dye = dye;
		}
	}
}
